import {AuthHttpService, Constants} from "Services";

export class ProductsService {
    authHttpService = new AuthHttpService();

    getProducts = (request) => {
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.PRODUCTS_LIST, request)
            .then(resp => resp.data);
    };
    
    getProduct = (productGuid) => {
        return this.authHttpService
            .get(Constants.ApiRoutes.Admin.PRODUCTS_GET + productGuid)
            .then(resp => resp.data);
    }
    
    createProduct = (request) => {
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.PRODUCTS_CREATE, request)
            .then(resp => resp.data);
    }

    updateProduct = (request) => {
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.PRODUCTS_UPDATE, request)
            .then(resp => resp.data);
    }
}