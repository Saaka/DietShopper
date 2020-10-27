import {AuthHttpService, Constants} from "Services";

export class ProductCategoriesService {
    authHttpService = new AuthHttpService();

    createProductCategory = (productCategory) => {
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.PRODUCT_CATEGORIES, productCategory)
            .then(response => response.data);
    };
    
    updateProductCategory = (productCategory) => {
        return this.authHttpService
            .put(`${Constants.ApiRoutes.Admin.PRODUCT_CATEGORIES}/${productCategory.productCategoryGuid}`, productCategory)
            .then(response => response.data);
    };

    removeProductCategory = (productCategoryGuid) => {
        return this.authHttpService
            .delete(`${Constants.ApiRoutes.Admin.PRODUCT_CATEGORIES}/${productCategoryGuid}`)
            .then(response => response.data);
    };
    
    getProductCategories = () => {
      return this.authHttpService
          .get(Constants.ApiRoutes.Admin.PRODUCT_CATEGORIES)
          .then(resp => resp.data);
    };
}