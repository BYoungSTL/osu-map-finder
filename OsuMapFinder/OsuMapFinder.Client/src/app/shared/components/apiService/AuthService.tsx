import {
  MutationFunction,
  UseMutationResult,
  useMutation,
} from "@tanstack/react-query";
import FetchService from "../FetchService";
import RequestMethod from "../../consts/enums/RequestMethod";
import RequestData from "../../consts/models/request/RequestData";

export const LOGIN_KEY = "login";
export const LoginUrl = "https://localhost:7107/api/Login";

interface UseLoginBody {
  username: string | null;
  password: string | null;
}

const UseLogin = (): UseMutationResult<
  string | null,
  unknown,
  UseLoginBody
> => {
  return useMutation<string | null, unknown, UseLoginBody>({
    mutationFn: async ({ username, password }: UseLoginBody) =>
      (await FetchService(
        LoginUrl,
        RequestMethod.POST,
        new RequestData(
          RequestMethod.POST,
          JSON.stringify({ username: username, password: password })
        )
      )) as Promise<string | null>,
  });
};

export default UseLogin;

//username: string | null, password: string | null
