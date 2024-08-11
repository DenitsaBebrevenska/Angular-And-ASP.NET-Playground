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

class Data{
    public method: string;
    public uri: string;
    public version: string;
    public message: string;
    public response: string | undefined;
    public fulfilled: boolean;
    constructor(methodInput: string, uriInput: string, versionInput: string, messageInput: string){
        this.method = methodInput;
        this.uri = uriInput;
        this.version = versionInput;
        this.message = messageInput;
        this.response = undefined;
        this.fulfilled = false;
    }
}

let myData : Data = new Data('GET', 'http://google.com', 'HTTP/1.1', '');

console.log(myData);