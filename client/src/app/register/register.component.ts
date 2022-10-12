
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
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
 
  registerForm: FormGroup ;
  maxDate: Date;
  validationErrors: string[] = [];

  constructor(  private accountService: AccountService ,
                private toastr:ToastrService ,
                private fb: FormBuilder , 
                private router: Router) 
  { console.log("register component - constructor() ");
  }
    

  ngOnInit(): void {
    console.log("register component - ngOnInit() ");
    this.initializeForm();
    this.maxDate = new Date();
    this.maxDate.setFullYear(this.maxDate.getFullYear() -18);
  }
  
  initializeForm(){
    console.log("register component - initializeForm() ");
    this.registerForm = this.fb.group(
      {
        gender:       ['male'] ,
        username:     ['', Validators.required] ,
        knownAs:      ['', Validators.required] ,
        dateOfBirth:  ['', Validators.required] ,
        city:         ['', Validators.required] ,
        country:      ['', Validators.required] ,
        
        password:     ['',[Validators.required, 
                          Validators.minLength(4), 
                          Validators.maxLength(8)
                         ]
                      ],
        confirmPassword: ['',[Validators.required, this.matchValues('password') ]]        
      });

      /* when the password changes, we are checking the validity agaisnt the confirmPassword */
      this.registerForm.controls.password.valueChanges.subscribe(() => {
          this.registerForm.controls.confirmPassword.updateValueAndValidity();
      } )
  }

  matchValues(matchTo: string) : ValidatorFn {
    console.log("register component - matchValues(pswd) ");
    
    /* this control ("matchTo") is going to get the password control
        then compare it , if they don't match return null, 
        if they do match we attach a validator with true in it */

    return (control: AbstractControl) => {
    
      ctrlPswd: new FormControl ;
      ctrlConf: new FormControl ;
      let ctrlPswd = control;
      let ctrlConf = control?.parent?.controls[matchTo];

      return control?.value === control?.parent?.controls[matchTo].value 
              ? null :{isMatching:true}
    }
  }


  register() {
    console.log("register component - register() - this.registerForm.value:" + this.registerForm.value);
    this.accountService.register(this.registerForm.value ).subscribe
      (response => 
        { console.log("register component - register() - response: " + response);
          console.log("register component - register() - route to memebrs page - response: " + JSON.stringify(response));    
          this.toastr.error("routing to memmbers");      
          this.router.navigateByUrl('/members');

        }, error => 
        { console.log("register component - register() ERROR 1" + JSON.stringify(error) );
          console.log("register component - register() ERROR 2" + error) ;          
          this.toastr.error(error.error);
          this.validationErrors = error;
        }
      )       
  }
  
  cancel() {
      console.log("register component - cancel - start" );
      this.cancelRegister.emit(false);
      console.log("register component - cancel - stop" );
    }
  
}
