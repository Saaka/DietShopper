import {AuthHttpService, Constants} from "Services";

export class UnitsOfMeasuresService {
    authHttpService = new AuthHttpService();

    getMeasures = () => {
        return this.authHttpService
            .get(Constants.ApiRoutes.Admin.MEASURES)
            .then(resp => resp.data);
    };
}