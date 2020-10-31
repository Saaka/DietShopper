import {AuthHttpService, Constants} from "Services";

export class UnitsOfMeasuresService {
    authHttpService = new AuthHttpService();

    getMeasures = () => {
        return this.authHttpService
            .get(Constants.ApiRoutes.Admin.MEASURES)
            .then(resp => resp.data);
    };

    createMeasure = (measure) => {
        if(!measure.isWeight)
            measure.valueInGrams = null;
        return this.authHttpService
            .post(Constants.ApiRoutes.Admin.MEASURES_CREATE, measure)
            .then(response => response.data);
    };
}