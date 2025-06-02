import { HttpInterceptorFn } from '@angular/common/http';

export const tokenInterceptor: HttpInterceptorFn = (req, next) => {
  const token = localStorage.getItem('token');
  const cleanToken = token?.replace(/^"(.+)"$/, '$1'); // Quita comillas del token

  const authReq = token
    ? req.clone({ setHeaders: { Authorization: `Bearer ${cleanToken}` } })
    : req;
  return next(authReq);
};
