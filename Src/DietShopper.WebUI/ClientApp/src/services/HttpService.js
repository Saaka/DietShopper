import {ConfigService} from "Services";
import Axios from "axios";

class HttpService {

    constructor(baseAddress, baseTenant) {
        this.configService = new ConfigService();
        this.baseAddress = baseAddress || this.configService.ApiUrl;
        this.baseTenant = baseTenant;
    };

    get = (address) => {
        let baseAddress = this.getAddress();

        return Axios({
            method: "get",
            url: `${baseAddress}` + address,
            headers: this.getHeaders()
        }).catch(err => {
            if (err.response)
                throw err.response.data;
            else
                throw err.message;
        });
    };

    post = (address, data) => {
        let baseAddress = this.getAddress();

        return Axios({
            method: "post",
            url: `${baseAddress}` + address,
            data: data,
            headers: this.getHeaders()
        }).catch(err => {
            if (err.response)
                throw err.response.data;
            else
                throw err.message;
        });
    };

    getAddress = () => {
        if(this.baseAddress.endsWith("/"))
            return this.baseAddress;

        return this.baseAddress + "/";
    };

    getHeaders() {
        return { };
    }
}

export {HttpService}
