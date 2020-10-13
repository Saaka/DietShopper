import React from 'react';
import {Switch, Route, Redirect} from "react-router";
import {AuthRoute, AdminRoute, RegularRoute} from "components/routing";
import appRoutes from "routes/appRoutes";
import "./App.scss";
import {RouteNames} from "../../routes/names";

function App(props) {

    return (
        <div className="app-container has-background-gradient">
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
                        return <RegularRoute path={prop.path} component={prop.component} name={prop.name} key={key}
                                      user={props.user}/>;
                })}
            </Switch>
        </div>
    );
}

export {App};