let RouteNames = class RouteNames {};

RouteNames.Root = "/";

RouteNames.Auth = "/auth";
RouteNames.Logout = "/auth/logout";

RouteNames.App = "/app";
RouteNames.Home = "/app/home";
RouteNames.Login = "/app/login";
RouteNames.Dashboard = "/app/dashboard";
RouteNames.Unauthorized = "/app/unauthorized";
RouteNames.About = "/app/about";

RouteNames.Admin = "/app/admin";
RouteNames.AdminProductCategories = "/app/admin/productCategories";
RouteNames.AdminUnitsOfMeasures = "/app/admin/unitsOfMeasures";
RouteNames.AdminProductEdit = "/app/admin/products/edit/";
RouteNames.AdminProductEdit_Id = RouteNames.AdminProductEdit + ":productGuid";
RouteNames.AdminProductCreate = "/app/admin/products/create";
RouteNames.AdminProducts = "/app/admin/products";

export {RouteNames};