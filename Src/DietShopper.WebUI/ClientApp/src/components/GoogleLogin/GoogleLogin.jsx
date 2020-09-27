import React from "react";
import {GoogleLogin} from "react-google-login";
import {ConfigService} from "Services";

function GoogleLogin(props) {
    const configService = new ConfigService();

    function onLogin(response) {
        props.showLoader();

    }

    function onLoginFail(response) {
        props.onError(response);
    }

    return (
        <GoogleLogin clientId={configService.GoogleClientId}
                     onSuccess={onLogin}
                     onFailure={onLoginFail}
                     render={props => (
                         <button>Sign in with Google</button>
                     )}/>
    )
}

export {GoogleLogin};