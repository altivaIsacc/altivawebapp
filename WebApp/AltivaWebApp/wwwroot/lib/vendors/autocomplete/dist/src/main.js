/* =============================================================
 * bootstrap-autocomplete.js v2.0.0
 * https://github.com/xcash/bootstrap-autocomplete
 * =============================================================
 * Forked from bootstrap3-typeahead.js v3.1.0
 * https://github.com/bassjobsen/Bootstrap-3-Typeahead
 * =============================================================
 * Original written by @mdo and @fat
 * =============================================================
 * Copyright 2018 Paolo Casciello @xcash666 and contributors
 *
 * Licensed under the MIT License (the 'License');
 * you may not use this file except in compliance with the License.
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an 'AS IS' BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * ============================================================ */
import { AjaxResolver } from './resolvers';
import { Dropdown, DropdownV4 } from './dropdown';
var AutoCompleteNS;
(function (AutoCompleteNS) {
    var AutoComplete = /** @class */ (function () {
        function AutoComplete(element, options) {
            this._selectedItem = null;
            this._defaultValue = null;
            this._defaultText = null;
            this._isSelectElement = false;
            this._settings = {
                resolver: 'ajax',
                resolverSettings: {},
                minLength: 3,
                valueKey: 'value',
                formatResult: this.defaultFormatResult,
                autoSelect: true,
                noResultsText: 'No results',
                events: {
                    typed: null,
                    searchPre: null,
                    search: null,
                    searchPost: null,
                    select: null,
                    focus: null,
                }
            };
            this._el = element;
            this._$el = $(this._el);
            // element type
            if (this._$el.is('select')) {
                this._isSelectElement = true;
            }
            // inline data attributes
            this.manageInlineDataAttributes();
            // constructor options
            if (typeof options === 'object') {
                this._settings = $.extend(true, {}, this.getSettings(), options);
            }
            if (this._isSelectElement) {
                this.convertSelectToText();
            }
            // console.log('initializing', this._settings);
            this.init();
        }
        AutoComplete.prototype.manageInlineDataAttributes = function () {
            // updates settings with data-* attributes
            var s = this.getSettings();
            if (this._$el.data('url')) {
                s['resolverSettings'].url = this._$el.data('url');
            }
            if (this._$el.data('default-value')) {
                this._defaultValue = this._$el.data('default-value');
            }
            if (this._$el.data('default-text')) {
                this._defaultText = this._$el.data('default-text');
            }
            if (this._$el.data('noresults-text')) {
                s['noResultsText'] = this._$el.data('noresults-text');
            }
        };
        AutoComplete.prototype.getSettings = function () {
            return this._settings;
        };
        AutoComplete.prototype.getBootstrapVersion = function () {
            // @ts-ignore
            var version_string = $.fn.button.Constructor.VERSION;
            var version_array = version_string.split('.');
            return version_array;
        };
        AutoComplete.prototype.convertSelectToText = function () {
            // create hidden field
            var hidField = $('<input>');
            hidField.attr('type', 'hidden');
            hidField.attr('name', this._$el.attr('name'));
            if (this._defaultValue) {
                hidField.val(this._defaultValue);
            }
            this._selectHiddenField = hidField;
            hidField.insertAfter(this._$el);
            // create search input element
            var searchField = $('<input>');
            // copy all attributes
            searchField.attr('type', 'text');
            searchField.attr('name', this._$el.attr('name') + '_text');
            searchField.attr('id', this._$el.attr('id'));
            searchField.attr('disabled', this._$el.attr('disabled'));
            searchField.attr('placeholder', this._$el.attr('placeholder'));
            searchField.attr('autocomplete', 'off');
            searchField.addClass(this._$el.attr('class'));
            if (this._defaultText) {
                searchField.val(this._defaultText);
            }
            // attach class
            searchField.data(AutoCompleteNS.AutoComplete.NAME, this);
            // replace original with searchField
            this._$el.replaceWith(searchField);
            this._$el = searchField;
            this._el = searchField.get(0);
        };
        AutoComplete.prototype.init = function () {
            // bind default events
            this.bindDefaultEventListeners();
            // RESOLVER
            if (this._settings.resolver === 'ajax') {
                // configure default resolver
                this.resolver = new AjaxResolver(this._settings.resolverSettings);
            }
            // Dropdown
            if (this.getBootstrapVersion()[0] == 4) {
                // v4
                this._dd = new DropdownV4(this._$el, this._settings.formatResult, this._settings.autoSelect, this._settings.noResultsText);
            }
            else {
                this._dd = new Dropdown(this._$el, this._settings.formatResult, this._settings.autoSelect, this._settings.noResultsText);
            }
        };
        AutoComplete.prototype.bindDefaultEventListeners = function () {
            var _this = this;
            this._$el.on('keydown', function (evt) {
                // console.log('keydown', evt.which, evt);
                switch (evt.which) {
                    case 9: // TAB
                        if (_this._settings.autoSelect) {
                            // if autoSelect enabled selects on blur the currently selected item
                            _this._dd.selectFocusItem();
                        }
                        break;
                    case 13: // ENTER
                        if (_this._dd.isItemFocused) {
                            _this._dd.selectFocusItem();
                        }
                        else {
                            if (_this._$el.val() !== '') {
                                _this._$el.trigger('autocomplete.freevalue', _this._$el.val());
                            }
                        }
                        _this._dd.hide();
                        break;
                }
            });
            this._$el.on('keyup', function (evt) {
                // console.log('keyup', evt.which, evt);
                // check key
                switch (evt.which) {
                    case 16: // shift
                    case 17: // ctrl
                    case 18: // alt
                    case 39: // right
                    case 37: // left 
                        break;
                    case 40:
                        // arrow DOWN
                        _this._dd.focusNextItem();
                        break;
                    case 38: // up arrow
                        _this._dd.focusPreviousItem();
                        break;
                    case 13:
                        // ENTER
                        _this._dd.hide();
                        break;
                    case 27:
                        // ESC
                        _this._dd.hide();
                        break;
                    default:
                        var newValue = _this._$el.val();
                        _this.handlerTyped(newValue);
                }
            });
            this._$el.on('blur', function (evt) {
                // console.log(evt);
                if (!_this._dd.isMouseOver) {
                    if (_this._isSelectElement) {
                        // if it's a select element you must
                        if (_this._dd.isItemFocused) {
                            _this._dd.selectFocusItem();
                        }
                        else if ((_this._selectedItem !== null) && (_this._$el.val() !== '')) {
                            // reselect it
                            _this._$el.trigger('autocomplete.select', _this._selectedItem);
                        }
                        else if ((_this._$el.val() !== '') && (_this._defaultValue !== null)) {
                            // select Default
                            _this._$el.val(_this._defaultText);
                            _this._selectHiddenField.val(_this._defaultValue);
                            _this._selectedItem = null;
                        }
                        else {
                            // empty the values
                            _this._$el.val('');
                            _this._selectHiddenField.val('');
                            _this._selectedItem = null;
                        }
                    }
                    else {
                        // It's a text element, we accept custom value.
                        // Developers may subscribe to `autocomplete.freevalue` to get notified of this
                        if ((_this._selectedItem === null) && (_this._$el.val() !== '')) {
                            _this._$el.trigger('autocomplete.freevalue', _this._$el.val());
                        }
                    }
                    _this._dd.hide();
                }
            });
            // selected event
            // @ts-ignore - Ignoring TS type checking
            this._$el.on('autocomplete.select', function (evt, item) {
                _this._selectedItem = item;
                _this.itemSelectedDefaultHandler(item);
            });
        };
        AutoComplete.prototype.handlerTyped = function (newValue) {
            // field value changed
            // custom handler may change newValue
            if (this._settings.events.typed !== null) {
                newValue = this._settings.events.typed(newValue);
                if (!newValue)
                    return;
            }
            // if value >= minLength, start autocomplete
            if (newValue.length >= this._settings.minLength) {
                this._searchText = newValue;
                this.handlerPreSearch();
            }
            else {
                this._dd.hide();
            }
        };
        AutoComplete.prototype.handlerPreSearch = function () {
            // do nothing, start search
            // custom handler may change newValue
            if (this._settings.events.searchPre !== null) {
                var newValue = this._settings.events.searchPre(this._searchText);
                if (!newValue)
                    return;
                this._searchText = newValue;
            }
            this.handlerDoSearch();
        };
        AutoComplete.prototype.handlerDoSearch = function () {
            var _this = this;
            // custom handler may change newValue
            if (this._settings.events.search !== null) {
                this._settings.events.search(this._searchText, function (results) {
                    _this.postSearchCallback(results);
                });
            }
            else {
                // Default behaviour
                // search using current resolver
                if (this.resolver) {
                    this.resolver.search(this._searchText, function (results) {
                        _this.postSearchCallback(results);
                    });
                }
            }
        };
        AutoComplete.prototype.postSearchCallback = function (results) {
            // console.log('callback called', results);
            // custom handler may change newValue
            if (this._settings.events.searchPost) {
                results = this._settings.events.searchPost(results);
                if ((typeof results === 'boolean') && !results)
                    return;
            }
            this.handlerStartShow(results);
        };
        AutoComplete.prototype.handlerStartShow = function (results) {
            // console.log("defaultEventStartShow", results);
            // for every result, draw it
            this._dd.updateItems(results, this._searchText);
            this._dd.show();
        };
        AutoComplete.prototype.itemSelectedDefaultHandler = function (item) {
            // console.log('itemSelectedDefaultHandler', item);
            // default behaviour is set elment's .val()
            var itemFormatted = this._settings.formatResult(item);
            if (typeof itemFormatted === 'string') {
                itemFormatted = { text: itemFormatted };
            }
            this._$el.val(itemFormatted.text);
            // if the element is a select
            if (this._isSelectElement) {
                this._selectHiddenField.val(itemFormatted.value);
            }
            // save selected item
            this._selectedItem = item;
            // and hide
            this._dd.hide();
        };
        AutoComplete.prototype.defaultFormatResult = function (item) {
            if (typeof item === 'string') {
                return { text: item };
            }
            else if (item.text) {
                return item;
            }
            else {
                // return a toString of the item as last resort
                // console.error('No default formatter for item', item);
                return { text: item.toString() };
            }
        };
        AutoComplete.prototype.manageAPI = function (APICmd, params) {
            // manages public API
            if (APICmd === 'set') {
                this.itemSelectedDefaultHandler(params);
            }
        };
        AutoComplete.NAME = 'autoComplete';
        return AutoComplete;
    }());
    AutoCompleteNS.AutoComplete = AutoComplete;
})(AutoCompleteNS || (AutoCompleteNS = {}));
(function ($, window, document) {
    // @ts-ignore
    $.fn[AutoCompleteNS.AutoComplete.NAME] = function (optionsOrAPI, optionalParams) {
        return this.each(function () {
            var pluginClass;
            pluginClass = $(this).data(AutoCompleteNS.AutoComplete.NAME);
            if (!pluginClass) {
                pluginClass = new AutoCompleteNS.AutoComplete(this, optionsOrAPI);
                $(this).data(AutoCompleteNS.AutoComplete.NAME, pluginClass);
            }
            pluginClass.manageAPI(optionsOrAPI, optionalParams);
        });
    };
})(jQuery, window, document);
