"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.SMErrorStateMatcher = void 0;
/** Error when invalid control is dirty or touched*/
var SMErrorStateMatcher = /** @class */ (function () {
    function SMErrorStateMatcher() {
    }
    SMErrorStateMatcher.prototype.isErrorState = function (control, form) {
        return !!(control && control.invalid && (control.dirty || control.touched));
    };
    return SMErrorStateMatcher;
}());
exports.SMErrorStateMatcher = SMErrorStateMatcher;
//# sourceMappingURL=default.error-matcher.js.map