import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit 
{

  // class variables
  registerMode = false;
  // users: any;

  // methods - constructor
  //constructor(private http: HttpClient) { }
  constructor() { }

  // methods
  ngOnInit(): void {
    console.log("HomeComponent - ngOnInit - start");
    //console.log("HomeComponent - ngOnInit - calling getUsers");
    //this.getUsers();
    console.log("HomeComponent - ngOnInit - start");
  }

  registerToggle() 
  {
    console.log("HomeComponent - registerToggle() - start - this.registerMode: " + JSON.stringify(this.registerMode) + " - !this.registerMode: " + JSON.stringify(!this.registerMode)  );
    this.registerMode = !this.registerMode;
    console.log("HomeComponent - registerToggle() - done");
    
  }
  
 

  /*
  getUsers() {
    console.log("HomeComponent - getUsers method - start ");
    this.http.get('https://localhost:5001/api/users').subscribe(users => this.users = users);
    console.log("HomeComponent - getUsers method - done");
  }
  */

  cancelRegisterMode(event: boolean) {
    //console.log("HomeComponent -  cancelRegisterMode - event:" + JSON.stringify(event) );
    this.registerMode = event;
  }
}
