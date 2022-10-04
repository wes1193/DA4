import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { BusyService } from '../_services/busy.service';
import { delay, finalize } from 'rxjs/operators';

@Injectable()
export class LoadingInterceptor implements HttpInterceptor {

  constructor(private busyService: BusyService) {
    console.log( "["+ new Date().toISOString() + "] LoadingInterceptor.ts - Constructor" );
  }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    console.log( "["+ new Date().toISOString() + "] LoadingInterceptor.ts - intercept" );
    this.busyService.busy();
    console.log( "["+ new Date().toISOString() + "] LoadingInterceptor.ts - intercept - request" + JSON.stringify(request ) );
    console.log( "["+ new Date().toISOString() + "] LoadingInterceptor.ts - intercept - next" + JSON.stringify(next ) );
    
    return next.handle(request).pipe(
          delay(1000),  
          finalize(  () => {  this.busyService.idle();
                          }
          )
        ) ;
  }
}
