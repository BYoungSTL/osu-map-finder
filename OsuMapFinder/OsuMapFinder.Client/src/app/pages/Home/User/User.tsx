import { UseUser } from "../../../shared/components/apiService/UserService";
import './User.scss'

const User = () => {
    const userQuery = UseUser(15290612);

    if (userQuery.isError && userQuery.data)
        console.log("бля")

    const user = userQuery.data;
    const userStatistics = user?.statistics;
    const userLink = 'https://osu.ppy.sh/users/' + user?.id;

    return (
        <div className="profile">
            <div className='userinfo row'>
                <div className='userinfo-profile'>
                    <img className='profile-image' src={user?.avatar_url} />
                </div>
                <div className='col row userinfo-col-data'>
                    <a className='link' href={userLink}>{user?.username}</a>
                    <div className='col'>
                        <p className='info'>Country: {user?.country_code}</p>
                        <p className='info'>Performance points: {userStatistics?.pp}</p>
                        <p className='info'>Country Rank: #{userStatistics?.country_rank}</p>
                        <p className='info'>Global Rank: #{userStatistics?.global_rank}</p>
                    </div>
                </div>
            </div>
            <div className="mb-3">
                <input className='input-form' type="user" placeholder="Insert user id" />
            </div>
        </div>
    );
}

export default User;