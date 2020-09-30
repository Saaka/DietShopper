import React from "react";
import {GoogleLogin} from "react-google-login";
import {ConfigService} from "Services";
import {Icon} from "components/common"
import "./GoogleLogin.scss";

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
                         <button className="button is-primary"
                                 onClick={renderProps.onClick}><Icon name="google"/><span className="button-text">Sign in with Google</span></button>
                     )}/>
    )
}

export {LoginWithGoogle as GoogleLogin};