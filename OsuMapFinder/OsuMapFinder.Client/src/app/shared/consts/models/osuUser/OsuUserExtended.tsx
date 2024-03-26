import OsuUserStatistics from "./OsuUserStatistics";

interface OsuUserExtended {
    avatar_url: string,
    country_code: string,
    id: number,
    is_active: boolean,
    is_bot: boolean,
    is_deleted: boolean,
    username: string
    statistics: OsuUserStatistics
}

export default OsuUserExtended;