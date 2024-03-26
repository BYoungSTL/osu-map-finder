import { UseMutationResult, useMutation } from "@tanstack/react-query";
import FetchService from "../FetchService";
import RequestMethod from "../../consts/enums/RequestMethod";
import RequestData from "../../consts/models/request/RequestData";

export const LOGIN_KEY = 'login' 
export const LoginUrl = 'https://localhost:7107/api/Login'

const UseLogin = (): UseMutationResult<string | null, unknown, string> => {
    const loginModel = ;
    const requestModel = ;
    return useMutation<string | null, unknown, string>({
        mutationFn: async (username: string | null, password: string | null) => await FetchService(LoginUrl, new RequestData(RequestMethod.POST, JSON.stringify({username: username, password: password})))
    });
};

export default UseLogin;

//username: string | null, password: string | null