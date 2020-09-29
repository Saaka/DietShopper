import React from 'react';
import {Switch, Route, Redirect} from "react-router";
import {AuthRoute, AdminRoute} from "components/routing";
import appRoutes from "routes/appRoutes";
import "./App.scss";

function App(props) {

    return (
        <div className="app-container has-background-gradient">
            <h1>TITLE</h1>
            <Switch>
                {appRoutes.map((prop, key) => {
                    if (prop.redirect)
                        return (<Redirect from={prop.path} to={prop.to} key={key}/>);
                    else if (prop.requireAuth)
                        if (prop.requireAdmin)
                            return (<AdminRoute path={prop.path} component={prop.component} name={prop.name} key={key}
                                                user={props.user}/>);
                        else
                            return (<AuthRoute path={prop.path} component={prop.component} name={prop.name} key={key}
                                               user={props.user}/>);
                    else
                        return <Route path={prop.path} component={prop.component} name={prop.name} key={key}/>;
                })}
            </Switch>
        </div>
    );
}

export {App};