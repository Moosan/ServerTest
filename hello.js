var Hello = /** @class */ (function () {
    function Hello(message) {
        this.Message = message;
    }
    Hello.prototype.say = function () {
        console.log("Hello, " + this.Message + "!");
    };
    return Hello;
}());
var hello = new Hello("TypeScript");
hello.say();
