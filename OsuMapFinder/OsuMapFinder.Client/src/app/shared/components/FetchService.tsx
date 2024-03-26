import RequestMethod from '../consts/enums/RequestMethod';
import RequestData from '../consts/models/request/RequestData';

const FetchService = async (ApiUrl: string, requestMethod: RequestMethod, requestInit?: RequestData) => {
    const response = await fetch(ApiUrl, {
        method: requestMethod.toString(),
        mode: "cors",
        body: requestInit?.body
    });
    if (!response.ok) {
      throw new Error('Network response was not ok');
    }
    return response.json();
}

export default FetchService;