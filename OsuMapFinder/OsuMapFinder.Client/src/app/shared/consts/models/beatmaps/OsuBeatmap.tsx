import OsuBeatmapset from "./OsuBeatmapset";

interface OsuBeatmap {
    difficulty_rating: number;
    accuracy: number;
    ar: number;
    bpm: number;
    drain: number;
    url: string;
    version: string;
    beatmapset: OsuBeatmapset;
}

export default OsuBeatmap;
