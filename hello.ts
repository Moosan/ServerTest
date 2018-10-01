class Hello{
    private Message: string;
    constructor(message: string) {
        this.Message = message;
    }
    public say() {
        console.log("Hello, " + this.Message+"!");
    }
}
var hello = new Hello("TypeScript");
hello.say();