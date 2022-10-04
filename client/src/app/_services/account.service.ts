import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})

export class AccountService {

  baseUrl = environment.apiUrl;
  
  // save current user
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();


  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  constructor(private http: HttpClient) 
  {
    console.log("\n\n >>>>> account service constructor");
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  login(model: any)
  { 
      console.log("\n account service login module - login - start");
   
      return this.http.post(this.baseUrl + 'account/login', model).pipe
        (
          map( (response: User) => 
            {
                const user = response;
                if (user)  
                { 
                  this.setCurrentUser(user);
                  console.log("\n >>> account service login module - Login - user: " + JSON.stringify(user.username) );
                }
            }
          )
        ) ;
        console.log("account service login module - login - done");
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

  register(model: any)
  { console.log("account service register - start - model:" + JSON.stringify(model)); 
    return this.http.post( this.baseUrl + 'account/register', model ).pipe
    (
      map( (user: User) => 
                  { if(user)  { 
                      this.setCurrentUser(user);
                    }
                  } 
        )
    )
    
  }
 
  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  setCurrentUser(user: User)
  {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

  logout() {
    console.log("  account service login module - Logout - start");
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    console.log("  account service login module - Logout - stop");
  }
}
