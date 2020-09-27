import React, {useEffect, useState} from "react";
import {GoogleLogin} from "components/auth";

function Login(props){

    const [isLoading, setLoading] = useState(false);
    
    function onLoggedIn(userData) {

    }
    
    function onError(err) {

    }

    const renderLoader = () => (<Loader/>);
    
    return (
        <section className="hero has-background-gradient is-fullheight">
            <div className="hero-body login-body">
                <div className="container center login-container">
                    <h1 className="is-size-4 login-title">Login to Identity Issuer</h1>
                    <div>
                        <GoogleLogin onLoggedIn={onLoggedIn} onError={onError}/>
                    </div>
                </div>
            </div>
        </section>
    );
}

export {Login};
