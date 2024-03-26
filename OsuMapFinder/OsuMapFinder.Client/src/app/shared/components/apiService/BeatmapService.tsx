import { UseQueryResult, useQuery } from "@tanstack/react-query";
import OsuBeatmap from "../../consts/models/beatmaps/OsuBeatmap";
import FetchService from "../FetchService";
import RequestMethod from "../../consts/enums/RequestMethod";

export const GET_BEATMAP_KEY = 'get_beatmap' 
export const GetBeatmapUrl = 'https://localhost:7107/api/OsuBeatmaps/beatmap/'

export const UseBeatmap = (id: number | null): UseQueryResult<OsuBeatmap | null> => {
    return useQuery<OsuBeatmap | null>({
        queryKey: [GET_BEATMAP_KEY, id],
        enabled: !!id,
        queryFn: async () => await FetchService(GetBeatmapUrl + id, RequestMethod.GET)
    });
};