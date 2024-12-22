import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { LOCAL_STORAGE_KEYS } from '../constants';
import { JSONSafeParse } from '../helpers/util';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor() {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    // Retrieve the token from localStorage or another storage mechanism
    const token = localStorage.getItem(LOCAL_STORAGE_KEYS.INTERNAL_AUTH_TOKEN);
    const gstTokenData = JSONSafeParse(
      localStorage.getItem(LOCAL_STORAGE_KEYS.GST_AUTH_DATA)
    );
    if (token) {
      // Clone the request to add the Authorization header
      let clonedRequest = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
      if (gstTokenData) {
        clonedRequest = request.clone({
          setHeaders: {
            Authorization: `Bearer ${token}`,
            ...gstTokenData,
          },
        });
      }

      // Pass the cloned request instead of the original
      return next.handle(clonedRequest);
    }

    // If no token, pass the original request
    return next.handle(request);
  }
}
