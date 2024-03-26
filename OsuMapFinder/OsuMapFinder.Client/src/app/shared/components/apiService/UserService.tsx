import { UseQueryResult, useQuery } from "@tanstack/react-query";
import OsuUserExtended from "../../consts/models/osuUser/OsuUserExtended";
import FetchService from "../FetchService";
import RequestMethod from "../../consts/enums/RequestMethod";

export const GET_USER_KEY = 'get_user'
export const GetUserUrl = 'https://localhost:7107/api/OsuUserInfo/'

export const UseUser = (id: number | null): UseQueryResult<OsuUserExtended | null> => {
    return useQuery<OsuUserExtended | null>({
        queryKey: [GET_USER_KEY, id],
        enabled: !!id,
        queryFn: async () => await FetchService(GetUserUrl + id, RequestMethod.GET)
    });
};