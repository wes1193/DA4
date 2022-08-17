import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { User } from '../_models/user';
import { pathToFileURL } from 'url';

//import { readFileSync, writeFileSync, promises as fsPromises } from 'fs';
//import { fs } from 'fs';

//import * as fs from 'fs';
//declare var fs: any;

//import { readFileSync } from 'fs'; 
//import { promises as fsPromises } from 'fs';
//const fs  = require("fs");
//import * as path from 'path';

@Component(//
            { selector: 'app-nav',
              templateUrl: './nav.component.html',
              styleUrls: ['./nav.component.css']
            }
          )

export class NavComponent implements OnInit {
  model: any = {};
  //loggedIn: boolean;
  //currentUser$: Observable<User>;

  //constructor(private accountService: AccountService) { }
  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
    // this.getCurrentUser();
    // this.currentUser$ =  this.accountService.currentUser$;
  }

  
  Tm() : string 
  { var dt = new Date();
    var s = "["+dt.getHours() + ":" + dt.getMinutes()  + ":" + dt.getSeconds()  + "." + dt.getMilliseconds()+"]";
    return s;
  } 
  

  login() 
  {
      console.log(this.Tm() + " - nav.component.ts - login");      
      console.log(this.Tm() + " - nav.component.ts - model = " + JSON.stringify( this.model) );
      
      this.accountService.login(this.model)
        .subscribe(response => 
                    { console.log(this.Tm() + " - nav.component.ts - login - response = " + JSON.stringify( response) );
                      // this.loggedIn =  true;

                      console.log(this.Tm() + " - nav.component.ts - login -  ");
                    } , error => {  console.log(this.Tm() + " - nav.component.ts - login - ERROR = " + JSON.stringify(error) ) ;
                                    console.log(this.Tm() + " - more info") ;
                                    var ans  = confirm("Login ERROR: \n \n info: \n" + JSON.stringify(error) );
                                    console.log(this.Tm() + " - nav.component.ts - login - ERROR response = " + JSON.stringify(ans) ) ;
                                 }
                  )

        console.log(this.Tm() + " - nav.component.ts - login - done");
        //FileSaver.saveAs("info goes here", 'DatingApp.log'); 
  }

  logout() 
  {
    console.log(this.Tm() + " - nav.component.ts - logout - start");
    this.accountService.logout();
    //this.loggedIn =  false;
    console.log(this.Tm() + " - nav.component.ts - logout - stop");
  }

  /*
  getCurrentUser()
  {
    console.log(this.Tm() + " - \n\nnav.component.ts - getCurrentUser - start");
    this.accountService.currentUser$
    .subscribe(user => 
                {  // this.loggedIn = !!user;     double exclamation marks turn it into a boolean 
                  console.log(this.Tm() + " - nav.component.ts - getCurrentUser() - user : " + JSON.stringify(user) );
                }, 
                error => 
                { console.log(this.Tm() + " - nav.component.ts - getCurrentUser() - error : " + JSON.stringify(error) );
                }
              )
    console.log(this.Tm() + " - nav.component.ts - getCurrentUser - stop");
  }
  */

}
