import {Admin, Dashboard, Unauthorized, About, Login} from "views/exports";
import {ProductCategories} from "views/Admin/exports";
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
        requireAuth: true,
        requireAdmin: true,
        path: RouteNames.Admin,
        component: Admin,
        name: "Admin",
        icon: "admin"
    },
    {
        requireAuth: true,
        requireAdmin: true,
        path: RouteNames.AdminProducts,
        component: Admin,
        name: "Admin",
        icon: "admin"
    },
    {
        requireAuth: true,
        requireAdmin: true,
        path: RouteNames.AdminProductCategories,
        component: ProductCategories,
        name: "Product Categories",
        icon: "admin"
    },
    {
        requireAuth: true,
        requireAdmin: true,
        path: RouteNames.AdminUnitsOfMeasures,
        component: Admin,
        name: "Admin",
        icon: "admin"
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