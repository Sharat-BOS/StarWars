import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <ul className="nav flex-column">
                    <li className="nav-item">
                        <NavLink to={'/'} exact activeClassName='active' className='nav-link'>
                            <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink to={'/counter'} activeClassName='active' className='nav-link'>
                            <span className='glyphicon glyphicon-education'></span> Counter
                            </NavLink>
                    </li>
                    <li className="nav-item">
                        <NavLink to={'/fetchdata'} activeClassName='active' className='nav-link'>
                            <span className='glyphicon glyphicon-th-list'></span> Fetch data
                            </NavLink>
                    </li>
                    <li className="nav-item">                      
                        <NavLink to={'/starwars/episodes'} activeClassName='active' className='nav-link'>
                            <span className='glyphicon glyphicon-th-list'></span> Episodes
                            </NavLink>
                     </li>
                    <li className="nav-item">
                        <NavLink to={'/starwars/factions'} activeClassName='active' className='nav-link'>
                            <span className='glyphicon glyphicon-th-list'></span> Factions
                                    </NavLink>
                    </li>
                </ul>  
    }
}
//<div className='navbar-collapse collapse'>
                //    <ul className='nav navbar-nav'>
                //        <li>
                //            <NavLink to={ '/' } exact activeClassName='active'>
                //                <span className='glyphicon glyphicon-home'></span> Home
                //            </NavLink>
                //        </li>
                //        <li>
                //            <NavLink to={ '/counter' } activeClassName='active'>
                //                <span className='glyphicon glyphicon-education'></span> Counter
                //            </NavLink>
                //        </li>
                //        <li>
                //            <NavLink to={ '/fetchdata' } activeClassName='active'>
                //                <span className='glyphicon glyphicon-th-list'></span> Fetch data
                //            </NavLink>
                //        </li>
                //        <li>
                //            <NavLink to={'/starwars/episodes'} activeClassName='active'>
                //                <span className='glyphicon glyphicon-th-list'></span> Episodes
                //            </NavLink>
                //        </li>
                //    </ul>
                //</div>