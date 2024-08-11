// class User{
//     private name: string;
//     constructor(name: string){
//         this.name = name;
//     }
//     sayHello (){
//         return `${this.name} says hi!`;
//     }
// }
// const user = new User('Pesho');
// console.log(user.sayHello());
var Data = /** @class */ (function () {
    function Data(methodInput, uriInput, versionInput, messageInput) {
        this.method = methodInput;
        this.uri = uriInput;
        this.version = versionInput;
        this.message = messageInput;
        this.response = undefined;
        this.fulfilled = false;
    }
    return Data;
}());
var myData = new Data('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(myData);
