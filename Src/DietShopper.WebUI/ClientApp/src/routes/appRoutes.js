import {Dashboard, Unauthorized, About, Login} from "views/exports";
import {RouteNames} from "./names";

const appRoutes = [
    {
        requireAuth: true,
        requireAdmin: false,
        path: RouteNames.Dashboard,
        component: Dashboard,
        name: "Dashboard",
        icon: "home"
    },
    {
        requireAuth: false,
        requireAdmin: false,
        path: RouteNames.About,
        component: About,
        name: "About",
        icon: "about"
    }, 
    {
        requireAuth: false,
        requireAdmin: false,
        path: RouteNames.Login,
        component: Login,
        name: "Login"
    },
    {
        requireAuth: false,
        path: RouteNames.Unauthorized,
        component: Unauthorized,
        name: "Unauthorized"
    },
    {
        redirect: true,
        path: RouteNames.App,
        to: RouteNames.About,
    }
];

export default appRoutes;