import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../_models/user';


@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = 'https://localhost:5001/api/';
  
  // save current user
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();


  constructor(private http: HttpClient) { }

  login(model: any)
  { console.log("account service login module - login - start");
   
  return this.http.post(this.baseUrl + 'account/login', model).pipe
    (
      map( (response: User) => 
        {
            const user = response;
            if (user)  
            { 
              localStorage.setItem('user', JSON.stringify(user));
              this.currentUserSource.next(user);
              console.log("  account service login module - Login - user: " + JSON.stringify(user.username) );
            }
        }
      )
    ) ;
    console.log("account service login module - login - done");
  }


  register(model: any)
  { console.log("account service register - start - model:" + JSON.stringify(model)); 
    return this.http.post( this.baseUrl + 'account/register', model ).pipe
    (
      map( (user: User) => 
                  { if(user) 
                    { localStorage.setItem('user', JSON.stringify(user));
                      this.currentUserSource.next(user);
                    }
                  } 
        )
    )
    
  }
  setCurrentUser(user: User)
  {
    this.currentUserSource.next(user);
  }

  logout() {
    console.log("  account service login module - Logout - start");
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    console.log("  account service login module - Logout - stop");
  }
}
