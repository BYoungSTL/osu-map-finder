import RequestMethod from "../../enums/RequestMethod";

class RequestData {
    method: RequestMethod;
    body: string;

    constructor (method: RequestMethod, body: string){
        this.body = body;
        this.method = method;
    }
}

export default RequestData;