import React from "react";
import {GoogleLogin} from "react-google-login";
import {ConfigService} from "Services";

function LoginWithGoogle(props) {
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
                     
                     render={renderProps => (
                         <button onClick={renderProps.onClick}>Sign in with Google</button>
                     )}/>
    )
}

export {LoginWithGoogle as GoogleLogin};