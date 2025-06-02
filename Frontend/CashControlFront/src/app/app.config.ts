import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';

import { tokenInterceptor } from './core/middleware/token.interceptor'; 
import { loadingInterceptor } from './core/middleware/loading.interceptor'; 

export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(withFetch(),withInterceptors([tokenInterceptor, loadingInterceptor])),
    provideRouter(routes)
  ]
};
