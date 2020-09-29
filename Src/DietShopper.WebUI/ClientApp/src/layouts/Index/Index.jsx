import React, {useState, useEffect} from 'react';
import {Route, Redirect} from "react-router-dom";
import {Loader} from "components/common";
import {RouteNames} from "routes/names";
import {Login, Logout} from "views/exports";
import {App} from "layouts/exports";
import "./Index.scss";

function Index(props) {
    const [isLoading, setIsLoading] = useState(true);
    const [user, setUser] = useState({isLoggedIn: false});

    useEffect(() => {
        hideLoader();
    }, []);

    function updateUser(user) {
        setUser({
            ...user,
            isLoggedIn: true
        });
    }

    function onError(err) {
        console.error(err);
    }

    const onLogin = (user) => {
        hideLoader();
        updateUser(user);
    };

    const onLogout = () => {
        setUser({
            isLoggedIn: false
        });
    };

    const hideLoader = () => setIsLoading(false);

    function renderApp() {
        return (
            <React.Fragment>
                <Route exact
                       path={RouteNames.Root}
                       render={(renderProps) => <Redirect to={RouteNames.App}
                                                          from={renderProps.path}
                                                          {...renderProps}
                                                          user={user}/>}/>
                <Route path={RouteNames.Login}
                       render={(renderProps) => <Login {...renderProps}
                                                       onLogin={onLogin}
                                                       user={user}/>}/>
                <Route path={RouteNames.Logout}
                       render={(renderProps) => <Logout {...renderProps}
                                                        onLogout={onLogout}/>}/>
                <Route path={RouteNames.App}
                       render={(props) => <App {...props} user={user}/>}/>
            </React.Fragment>
        );
    }

    function renderLoader() {
        return (
            <div className="hero has-background-gradient is-fullheight">
                <div className="hero-body center">
                    <Loader/>
                </div>
            </div>
        );
    }

    return isLoading ? renderLoader() : renderApp();
}

export {Index};