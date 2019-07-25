var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var BaseResolver = /** @class */ (function () {
    function BaseResolver(options) {
        this._settings = $.extend(true, {}, this.getDefaults(), options);
    }
    BaseResolver.prototype.getDefaults = function () {
        return {};
    };
    BaseResolver.prototype.getResults = function (limit, start, end) {
        return this.results;
    };
    BaseResolver.prototype.search = function (q, cbk) {
        cbk(this.getResults());
    };
    return BaseResolver;
}());
export { BaseResolver };
var AjaxResolver = /** @class */ (function (_super) {
    __extends(AjaxResolver, _super);
    function AjaxResolver(options) {
        return _super.call(this, options) || this;
        // console.log('resolver settings', this._settings);
    }
    AjaxResolver.prototype.getDefaults = function () {
        return {
            url: '',
            method: 'get',
            queryKey: 'q',
            extraData: {},
            timeout: undefined,
        };
    };
    AjaxResolver.prototype.search = function (q, cbk) {
        var _this = this;
        if (this.jqXHR != null) {
            this.jqXHR.abort();
        }
        var data = {};
        data[this._settings.queryKey] = q;
        $.extend(data, this._settings.extraData);
        this.jqXHR = $.ajax(this._settings.url, {
            method: this._settings.method,
            data: data,
            timeout: this._settings.timeout
        });
        this.jqXHR.done(function (result) {
            cbk(result);
        });
        this.jqXHR.fail(function (err) {
            // console.log(err);
        });
        this.jqXHR.always(function () {
            _this.jqXHR = null;
        });
    };
    return AjaxResolver;
}(BaseResolver));
export { AjaxResolver };
