export class ToasterInter {
    public toaster;
    constructor(toaster) {
        this.toaster = toaster;
    }

    public alert() {
        console.log("alerting...");
        this.toaster.pop({
            type: 'info',
            body: 'info-toast-directive',
            text: 'Hello from toaster'
        });
    }
}

