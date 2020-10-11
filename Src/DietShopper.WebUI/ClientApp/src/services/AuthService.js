import { AuthHttpService, HttpService, Constants, UserTokenService } from 'Services';

export class AuthService {
    httpService = new HttpService();
    authHttpService = new AuthHttpService();
    tokenService = new UserTokenService();

    isLoggedIn = () => this.tokenService.isTokenValid();

    logout = () => this.tokenService.removeToken();

    loginWithGoogle = (token) => {
        return this.httpService
            .post(Constants.ApiRoutes.GOOGLE, {
                googleToken: token
            })
            .then(this.onLogin);
    };
    
    onLogin = (response) => {

        this.tokenService
            .setToken(response.data.token);
        return {
            ...response.data.user,
            token: response.data.token
        };
    };
    
    getUser = () => {
        const token = this.tokenService
            .getToken();
        return this.authHttpService
            .get(Constants.ApiRoutes.GET_USER)
            .then(resp => {
                return {
                    ...resp.data,
                    token: token
                };
            });
    };
}