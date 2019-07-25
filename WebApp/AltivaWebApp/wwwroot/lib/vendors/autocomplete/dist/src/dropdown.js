/*
 *	Dropdown class. Manages the dropdown drawing
 */
var Dropdown = /** @class */ (function () {
    function Dropdown(e, formatItemCbk, autoSelect, noResultsText) {
        this.initialized = false;
        this.shown = false;
        this.items = [];
        this._$el = e;
        this.formatItem = formatItemCbk;
        this.autoSelect = autoSelect;
        this.noResultsText = noResultsText;
        // initialize it in lazy mode to deal with glitches like modals
        // this.init();
    }
    Dropdown.prototype.init = function () {
        var _this = this;
        // Initialize dropdown
        var pos = $.extend({}, this._$el.position(), {
            height: this._$el[0].offsetHeight
        });
        // create element
        this._dd = $('<ul />');
        // add our class and basic dropdown-menu class
        this._dd.addClass('bootstrap-autocomplete dropdown-menu');
        this._dd.insertAfter(this._$el);
        this._dd.css({ top: pos.top + this._$el.outerHeight(), left: pos.left, width: this._$el.outerWidth() });
        // click event on items
        this._dd.on('click', 'li', function (evt) {
            // console.log('clicked', evt.currentTarget);
            //console.log($(evt.currentTarget));
            var item = $(evt.currentTarget).data('item');
            _this.itemSelectedLaunchEvent(item);
        });
        this._dd.on('keyup', function (evt) {
            if (_this.shown) {
                switch (evt.which) {
                    case 27:
                        // ESC
                        _this.hide();
                        _this._$el.focus();
                        break;
                }
                return false;
            }
        });
        this._dd.on('mouseenter', 'li', function (evt) {
            if (_this.haveResults) {
                $(evt.currentTarget).closest('ul').find('li.active').removeClass('active');
                $(evt.currentTarget).addClass('active');
                _this.mouseover = true;
            }
        });
        this._dd.on('mouseleave', 'li', function (evt) {
            _this.mouseover = false;
        });
        this.initialized = true;
    };
    Dropdown.prototype.checkInitialized = function () {
        // Lazy init
        if (!this.initialized) {
            // if not already initialized
            this.init();
        }
    };
    Object.defineProperty(Dropdown.prototype, "isMouseOver", {
        get: function () {
            return this.mouseover;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(Dropdown.prototype, "haveResults", {
        get: function () {
            return (this.items.length > 0);
        },
        enumerable: true,
        configurable: true
    });
    Dropdown.prototype.focusNextItem = function (reversed) {
        if (this.haveResults) {
            // get selected
            var currElem = this._dd.find('li.active');
            var nextElem = reversed ? currElem.prev() : currElem.next();
            if (nextElem.length == 0) {
                // first 
                nextElem = reversed ? this._dd.find('li').last() : this._dd.find('li').first();
            }
            currElem.removeClass('active');
            nextElem.addClass('active');
        }
    };
    Dropdown.prototype.focusPreviousItem = function () {
        this.focusNextItem(true);
    };
    Dropdown.prototype.selectFocusItem = function () {
        this._dd.find('li.active').trigger('click');
    };
    Object.defineProperty(Dropdown.prototype, "isItemFocused", {
        get: function () {
            if (this._dd.find('li.active').length > 0) {
                return true;
            }
            return false;
        },
        enumerable: true,
        configurable: true
    });
    Dropdown.prototype.show = function () {
        if (!this.shown) {
            this._dd.dropdown().show();
            this.shown = true;
        }
    };
    Dropdown.prototype.isShown = function () {
        return this.shown;
    };
    Dropdown.prototype.hide = function () {
        if (this.shown) {
            this._dd.dropdown().hide();
            this.shown = false;
        }
    };
    Dropdown.prototype.updateItems = function (items, searchText) {
        // console.log('updateItems', items);
        this.items = items;
        this.searchText = searchText;
        this.refreshItemList();
    };
    Dropdown.prototype.showMatchedText = function (text, qry) {
        var startIndex = text.toLowerCase().indexOf(qry.toLowerCase());
        if (startIndex > -1) {
            var endIndex = startIndex + qry.length;
            return text.slice(0, startIndex) + '<b>'
                + text.slice(startIndex, endIndex) + '</b>'
                + text.slice(endIndex);
        }
        return text;
    };
    Dropdown.prototype.refreshItemList = function () {
        var _this = this;
        this.checkInitialized();
        this._dd.empty();
        var liList = [];
        if (this.items.length > 0) {
            this.items.forEach(function (item) {
                var itemFormatted = _this.formatItem(item);
                if (typeof itemFormatted === 'string') {
                    itemFormatted = { text: itemFormatted };
                }
                var itemText;
                var itemHtml;
                itemText = _this.showMatchedText(itemFormatted.text, _this.searchText);
                if (itemFormatted.html !== undefined) {
                    itemHtml = itemFormatted.html;
                }
                else {
                    itemHtml = itemText;
                }
                var disabledItem = itemFormatted.disabled;
                var li = $('<li >');
                li.append($('<a>').attr('href', '#!').html(itemHtml))
                    .data('item', item);
                if (disabledItem) {
                    li.addClass('disabled');
                }
                liList.push(li);
            });
        }
        else {
            // No results
            var li = $('<li >');
            li.append($('<a>').attr('href', '#!').html(this.noResultsText))
                .addClass('disabled');
            liList.push(li);
        }
        this._dd.append(liList);
    };
    Dropdown.prototype.itemSelectedLaunchEvent = function (item) {
        // launch selected event
        // console.log('itemSelectedLaunchEvent', item);
        this._$el.trigger('autocomplete.select', item);
    };
    return Dropdown;
}());
export { Dropdown };
var DropdownV4 = /** @class */ (function () {
    function DropdownV4(e, formatItemCbk, autoSelect, noResultsText) {
        this.initialized = false;
        this.shown = false;
        this.items = [];
        this._$el = e;
        this.formatItem = formatItemCbk;
        this.autoSelect = autoSelect;
        this.noResultsText = noResultsText;
        // initialize it in lazy mode to deal with glitches like modals
        // this.init();
    }
    DropdownV4.prototype.getElPos = function () {
        var pos = $.extend({}, this._$el.position(), {
            height: this._$el[0].offsetHeight
        });
        return pos;
    };
    DropdownV4.prototype.init = function () {
        var _this = this;
        // console.log('UIUIUIUIUIUIUII');
        // Initialize dropdown
        var pos = this.getElPos();
        // create element
        this._dd = $('<div />');
        // add our class and basic dropdown-menu class
        this._dd.addClass('bootstrap-autocomplete dropdown-menu');
        this._dd.insertAfter(this._$el);
        this._dd.css({ top: pos.top + this._$el.outerHeight(), left: pos.left, width: this._$el.outerWidth() });
        // click event on items
        this._dd.on('click', '.dropdown-item', function (evt) {
            // console.log('clicked', evt.currentTarget);
            // console.log($(evt.currentTarget));
            var item = $(evt.currentTarget).data('item');
            _this.itemSelectedLaunchEvent(item);
        });
        this._dd.on('keyup', function (evt) {
            if (_this.shown) {
                switch (evt.which) {
                    case 27:
                        // ESC
                        _this.hide();
                        _this._$el.focus();
                        break;
                }
                return false;
            }
        });
        this._dd.on('mouseenter', '.dropdown-item', function (evt) {
            if (_this.haveResults) {
                $(evt.currentTarget).closest('div').find('.dropdown-item.active').removeClass('active');
                $(evt.currentTarget).addClass('active');
                _this.mouseover = true;
            }
        });
        this._dd.on('mouseleave', '.dropdown-item', function (evt) {
            _this.mouseover = false;
        });
        this.initialized = true;
    };
    DropdownV4.prototype.checkInitialized = function () {
        // Lazy init
        if (!this.initialized) {
            // if not already initialized
            this.init();
        }
    };
    Object.defineProperty(DropdownV4.prototype, "isMouseOver", {
        get: function () {
            return this.mouseover;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(DropdownV4.prototype, "haveResults", {
        get: function () {
            return (this.items.length > 0);
        },
        enumerable: true,
        configurable: true
    });
    DropdownV4.prototype.focusNextItem = function (reversed) {
        if (this.haveResults) {
            // get selected
            var currElem = this._dd.find('.dropdown-item.active');
            var nextElem = reversed ? currElem.prev() : currElem.next();
            if (nextElem.length == 0) {
                // first 
                nextElem = reversed ? this._dd.find('.dropdown-item').last() : this._dd.find('.dropdown-item').first();
            }
            currElem.removeClass('active');
            nextElem.addClass('active');
        }
    };
    DropdownV4.prototype.focusPreviousItem = function () {
        this.focusNextItem(true);
    };
    DropdownV4.prototype.selectFocusItem = function () {
        this._dd.find('.dropdown-item.active').trigger('click');
    };
    Object.defineProperty(DropdownV4.prototype, "isItemFocused", {
        get: function () {
            if (this._dd && (this._dd.find('.dropdown-item.active').length > 0)) {
                return true;
            }
            return false;
        },
        enumerable: true,
        configurable: true
    });
    DropdownV4.prototype.show = function () {
        if (!this.shown) {
            var pos = this.getElPos();
            // this._dd.css({ top: pos.top + this._$el.outerHeight(), left: pos.left, width: this._$el.outerWidth() });
            this._dd.addClass('show');
            this.shown = true;
        }
    };
    DropdownV4.prototype.isShown = function () {
        return this.shown;
    };
    DropdownV4.prototype.hide = function () {
        if (this.shown) {
            this._dd.removeClass('show');
            this.shown = false;
        }
    };
    DropdownV4.prototype.updateItems = function (items, searchText) {
        // console.log('updateItems', items);
        this.items = items;
        this.searchText = searchText;
        this.refreshItemList();
    };
    DropdownV4.prototype.showMatchedText = function (text, qry) {
        var startIndex = text.toLowerCase().indexOf(qry.toLowerCase());
        if (startIndex > -1) {
            var endIndex = startIndex + qry.length;
            return text.slice(0, startIndex) + '<b>'
                + text.slice(startIndex, endIndex) + '</b>'
                + text.slice(endIndex);
        }
        return text;
    };
    DropdownV4.prototype.refreshItemList = function () {
        var _this = this;
        this.checkInitialized();
        this._dd.empty();
        var liList = [];
        if (this.items.length > 0) {
            this.items.forEach(function (item) {
                var itemFormatted = _this.formatItem(item);
                if (typeof itemFormatted === 'string') {
                    itemFormatted = { text: itemFormatted };
                }
                var itemText;
                var itemHtml;
                itemText = _this.showMatchedText(itemFormatted.text, _this.searchText);
                if (itemFormatted.html !== undefined) {
                    itemHtml = itemFormatted.html;
                }
                else {
                    itemHtml = itemText;
                }
                var disabledItem = itemFormatted.disabled;
                var li = $('<a >');
                li.attr('href', '#!')
                    .addClass('dropdown-item')
                    .html(itemHtml)
                    .data('item', item);
                if (disabledItem) {
                    li.addClass('disabled');
                }
                liList.push(li);
            });
        }
        else {
            // No results
            var li = $('<a >');
            li.attr('href', '#!')
                .addClass('dropdown-item disabled')
                .html(this.noResultsText);
            liList.push(li);
        }
        this._dd.append(liList);
    };
    DropdownV4.prototype.itemSelectedLaunchEvent = function (item) {
        // launch selected event
        // console.log('itemSelectedLaunchEvent', item);
        this._$el.trigger('autocomplete.select', item);
    };
    return DropdownV4;
}());
export { DropdownV4 };
