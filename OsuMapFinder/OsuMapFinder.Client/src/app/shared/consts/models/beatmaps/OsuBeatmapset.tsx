import Covers from "./Covers";

interface OsuBeatmapset {
    id: number;
    artist: string;
    creator: string;
    title: string;
    covers: Covers;
}

export default OsuBeatmapset;