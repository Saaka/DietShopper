import React from "react";
import {Route, Redirect} from "react-router-dom";
import {RouteNames} from "routes/names";
import {Constants} from "Services";

function AdminRoute(
    {
        component: Component,
        user,
        ...data
    }) {

    function isUserAdmin(user) {
        return user.roles.includes(Constants.UserRoles.ADMIN);
    }

    return (
        <Route {...data}
               render={props => {
                   if (user && user.isLoggedIn && isUserAdmin(user))
                       return (<Component {...props} user={user}/>);
                   else if (user && user.isLoggedIn && !isUserAdmin(user))
                       return (<Redirect to={{
                               pathname: RouteNames.Unauthorized
                           }}/>
                       );
                   else return (
                           <Redirect to={{
                               pathname: RouteNames.Login,
                               search: `?redirect=${props.location.pathname}`,
                               state: {
                                   from: props.location
                               }
                           }}/>
                       );
               }}/>
    );
}

export {AdminRoute};