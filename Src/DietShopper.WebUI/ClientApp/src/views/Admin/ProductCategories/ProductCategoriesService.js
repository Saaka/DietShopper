import {AuthHttpService, Constants} from "Services";

export class ProductCategoriesService {
    authHttpService = new AuthHttpService();

    createProductCategory = (productCategory) => {
        return this.authHttpService
            .put(Constants.ApiRoutes.Admin.PUT_PRODUCT_CATEGORY, productCategory)
            .then(response => response.data);
    };
    
    getProductCategories = () => {
      return this.authHttpService
          .get(Constants.ApiRoutes.Admin.GET_PRODUCT_CATEGORIES)
          .then(resp => resp.data);
    };
}