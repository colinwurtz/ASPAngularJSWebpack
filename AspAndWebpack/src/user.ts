export class User {
    name: string;
    address: string;

    constructor(name:string) {  
        this.name = name;
        this.address = "";
    }

    sayHello() {
        return "Hello my name is" + this.name;
    }
}
