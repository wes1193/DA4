
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from '../_services/account.service';
//import { EventEmitter } from 'stream';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {
 
  @Output() cancelRegister = new EventEmitter();
   // @Input() usersFromHomeComponent: any;
  model: any = {};

  constructor(private accountService: AccountService ,
              private toastr:ToastrService ) 
  { }
  //constructor( ) { }

  ngOnInit(): void {
    console.log("register component - ngOnInit() ");
  }
  
  register() {
    console.log("register component - register() model: " + this.model);
    console.log("register component - register() model stringify: " + JSON.stringify(this.model));
    this.accountService.register(this.model).subscribe
      (response => 
        { console.log("register component - register() response: " + response);
        console.log("register component - register() response: " + JSON.stringify(response));
          this.cancel();
        }, error => 
        { console.log("register component - register() ERROR 1" + JSON.stringify(error) );
          console.log("register component - register() ERROR 2" + error) ;
          this.toastr.error(error.error);
        }
      )       
  }
  
  cancel() {
      console.log("register component - cancel - start" );
      this.cancelRegister.emit(false);
      console.log("register component - cancel - stop" );
    }
  
}
