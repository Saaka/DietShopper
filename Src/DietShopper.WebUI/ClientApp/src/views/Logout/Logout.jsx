import React, {useEffect} from "react";
import {AuthService} from "services/AuthService";
import {Loader} from "components/common";

function Logout(props) {
    useEffect(() => {
        if (props.onLogout)
            props.onLogout();

        new AuthService().logout();
        props.history.replace('/');
    });

    return (
        <section className="hero has-background-gradient is-fullheight">
            <div className="hero-body login-body">
                <div className="container center login-container">
                    <Loader/>
                </div>
            </div>
        </section>
    );
}

export {Logout};