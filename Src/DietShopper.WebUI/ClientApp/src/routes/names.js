let RouteNames = class RouteNames {};

RouteNames.Root = "/";

RouteNames.Auth = "/auth";
RouteNames.Login = "/auth/login";
RouteNames.Logout = "/auth/logout";

RouteNames.App = "/app";
RouteNames.Unauthorized = "/app/unauthorized";
RouteNames.Home = "/app/home";
RouteNames.About = "/app/about";

export {RouteNames};