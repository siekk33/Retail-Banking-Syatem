import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../service/authentication.service';
import { environment } from 'src/environments/environment';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private authenticationService: AuthenticationService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const user = this.authenticationService.userValue;
        const isLoggedIn = user && user.token;
        const isApiUrl = request.url.startsWith(environment.apiUrl);
        ////const iscustomerApiUrl = request.url.startsWith(environment.customerApiUrl);
        ////const isaccountApiUrl = request.url.startsWith(environment.accountApiUrl);
        ////const istransactionApiUrl = request.url.startsWith(environment.transactionApiUrl);
        const isgatewayUrl = request.url.startsWith(environment.gatewayUrl);
        //// iscustomerApiUrl || isaccountApiUrl || istransactionApiUrl ||
        if (isLoggedIn && (isApiUrl || isgatewayUrl)) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${user.token}`
                }
            });
        }

        return next.handle(request);
  }
}
