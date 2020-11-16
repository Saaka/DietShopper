import {AuthHttpService, Constants} from "Services";

export class ProductsService {
    authHttpService = new AuthHttpService();

    getProducts = (request) => {
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.PRODUCTS_LIST, request)
            .then(resp => resp.data);
    };
}