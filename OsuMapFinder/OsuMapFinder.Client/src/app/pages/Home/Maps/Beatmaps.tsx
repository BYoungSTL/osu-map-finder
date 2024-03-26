import './Beatmaps.scss'
import { UseBeatmap } from "../../../shared/components/apiService/BeatmapService";

const Beatmaps = () => {
    const beatmapQuery = UseBeatmap(4418725);
    const beatmapQuery2 = UseBeatmap(1546350);
    const beatmapQuery3 = UseBeatmap(3487556);
    const beatmapQuery4 = UseBeatmap(4031530);
    const beatmapQuery5 = UseBeatmap(3398420);

    if (beatmapQuery.isError && beatmapQuery.data)
        console.log("бля")

    const beatmaps = [beatmapQuery, beatmapQuery2, beatmapQuery3, beatmapQuery4, beatmapQuery5]

    console.log(beatmapQuery.data)
    return (
        <div className='recommended-maps'>
            {beatmaps.map((beatmap) => (
                <div className="row-extended">
                    <div className="col-2 image-block">
                        <img className='beatmap-image' src={beatmap.data?.beatmapset.covers.list}></img>
                    </div>
                    <div className="col-5 beatmapset-col">
                        <a href={beatmap.data?.url} className='link'>{beatmap.data?.beatmapset.title}</a>
                        <p className='artist'>by {beatmap.data?.beatmapset.artist}</p>
                        <p>{beatmap.data?.version} ({beatmap.data?.difficulty_rating}*)</p>
                        <p className='mapper'>mapped by {beatmap.data?.beatmapset.creator}</p>
                    </div>
                    <div className="col-5 beatmapset-col">
                        <p className='bpm'>BPM: {beatmap.data?.bpm}</p>
                        <p className='data-text'>OD: {beatmap.data?.accuracy} HP: {beatmap.data?.drain} AR: {beatmap.data?.ar}</p>
                        {/* <p className='data-text'>95%: 2000pp 99%: 2000pp</p>
                        <p className='data-text'>98%: 2000pp 100%: 2000pp</p> */}
                    </div>
                </div>
            ))}
        </div>
    )
}

export default Beatmaps;