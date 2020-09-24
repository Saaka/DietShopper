import React, {useState, useEffect} from 'react';
import {Route, Redirect} from "react-router-dom";
// import {Loader} from "components/common";
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
    const onLogout = () => {
        setUser({
            isLoggedIn: false
        });
    };

    const hideLoader = () => setIsLoading(false);

    function renderApp() {
        return (
            <div className="hero has-background-gradient is-fullheight">
                <div className="hero-body center">
                    Test
                </div>
            </div>
        );
    }

    function renderLoader() {
        return (
            <div className="hero has-background-gradient is-fullheight">
                <div className="hero-body center">
                    TEST
                    {/*<Loader/>*/}
                </div>
            </div>
        );
    }

    return isLoading ? renderLoader() : renderApp();
}

export {Index};