import React, {useState} from "react";
import {Link} from "react-router-dom";
import "./AppNavbar.scss";
import {RouteNames} from "routes/names";

function AppNavbar(props) {
    const [isMenuActive, setActiveMenu] = useState(false);

    function logout() {
        props.history.replace(RouteNames.Logout)
    }

    const toggleNavbarMenu = () => setActiveMenu(prevState => !prevState);

    const menuClasses = () => isMenuActive ? "navbar-menu is-active": "navbar-menu";
    const burgerClasses = () => isMenuActive ? "navbar-burger burger is-active": "navbar-burger burger";

    return (
        <nav className="navbar is-primary" role="navigation" aria-label="main site navigation">
            <div className="container">
                <div className="navbar-brand">
                    <a className="navbar-item has-text-weight-bold">DietShopper</a>

                    <a className={burgerClasses()}
                       onClick={toggleNavbarMenu}
                       role="button" aria-label="dropdown menu" aria-expanded="false">
                        <span aria-hidden="true"/>
                        <span aria-hidden="true"/>
                        <span aria-hidden="true"/>
                    </a>
                </div>
                <div className={menuClasses()} id="app-navbar-menu">
                    <div className="navbar-start">
                        <Link className="navbar-item" to={RouteNames.Home} onClick={() => toggleNavbarMenu()}>Dashboard</Link>
                        <Link className="navbar-item" to={RouteNames.About} onClick={() => toggleNavbarMenu()}>About</Link>
                    </div>
                    <div className="navbar-end">
                        <div className="navbar-item">
                            <a className="button is-primary is-inverted is-outlined" onClick={logout}>Log out</a>
                        </div>
                    </div>
                </div>
            </div>
        </nav>
    );
}

export {AppNavbar};