import { Dropdown, Space } from 'antd';
import type { MenuProps } from 'antd';
import './Header.scss'

const Header = () => {
    const items: MenuProps['items'] = [
        {
          label: <a className='underline-none' href="https://www.antgroup.com">Saved playlists</a>,
          key: '0',
        }];
    return(
        <header className="header">
            <div className='header-row'>
                <div className='col-1'>
                    <img className='image' src='/src/assets/github-mark.svg'></img>
                </div>
                <a href='https://github.com/BYoungSTL/osu-map-finder' className='username underline-none'>Github</a>
                <div className='col-1'>
                    <img className='image' src='https://a.ppy.sh/15290612?1617472628.jpeg'></img>
                </div>
                <Dropdown menu={{items}} trigger={['click']}>
                    <a onClick={(e) => e.preventDefault()}>
                        <Space>
                            BYoung
                        </Space>
                    </a>
                </Dropdown>
            </div>
        </header>
    )
}

export default Header;