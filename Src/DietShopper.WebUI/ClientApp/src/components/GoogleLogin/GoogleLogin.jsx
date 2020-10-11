import React, {useState} from "react";
import {GoogleLogin} from "react-google-login";
import {ConfigService, AuthService} from "Services";
import {Icon, Loader} from "components/common"
import "./GoogleLogin.scss";

function LoginWithGoogle(props) {
    const configService = new ConfigService();
    const authService = new AuthService();
    const [showLoader, toggleLoader] = useState(false);

    function onLogin(response) {
        authService
            .loginWithGoogle(response.tokenId)
            .then(props.onLoggedIn)
            .catch(onLoginFail);
    }

    function onLoginFail(response) {
        props.onError(response);
        toggleLoader(false);
    }

    function onClick(renderProps) {
        renderProps.onClick();
        toggleLoader(true);
        props.onLogin();
    }

    const renderLoader = () => (<Loader size="xs"/>);

    return (
        <React.Fragment>
            <GoogleLogin clientId={configService.GoogleClientId}
                         onSuccess={onLogin}
                         onFailure={onLoginFail}
                         disabled={props.isLoading}

                         render={renderProps => (
                             <button className="button is-primary"
                                     disabled={props.isLoading}
                                     onClick={() => onClick(renderProps)}><Icon name="google"/><span
                                 className="button-text">Sign in with Google</span>
                                 {showLoader ? <span className="button-loader">{renderLoader()}</span> : ""}
                             </button>
                         )}/>
        </React.Fragment>
    )
}

export {LoginWithGoogle as GoogleLogin};