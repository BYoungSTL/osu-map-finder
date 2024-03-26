import './Home.scss'
import Beatmaps from './Maps/Beatmaps';
import User from './User/User';

const Home = () => {
    return (
        <div className='home-page'>
            <User/>
            <Beatmaps/>
        </div>
    );
}

export default Home;