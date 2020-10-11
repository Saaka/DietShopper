import React, {useEffect, useState} from "react";
import {GoogleLogin} from "components/auth";
import {Loader} from "components/common";
import "./Login.scss";

function Login(props) {

    const [isLoading, setLoading] = useState(false);

    function onLoggedIn(userData) {
        var user = userData;
    }

    function onError(err) {
        setLoading(false);
    }

    const renderLoader = () => (<Loader/>);

    return (
        <div className="section is-fullheight">
            <div className="container login-container center">
                <div className="login-block center">
                    <h1 className="is-size-4 login-title">Login using options below</h1>
                    <GoogleLogin onLoggedIn={onLoggedIn} onError={onError} onLogin={() => setLoading(true)} isLoading={isLoading}/>
                </div>
            </div>
        </div>
    );
}

export {Login};
