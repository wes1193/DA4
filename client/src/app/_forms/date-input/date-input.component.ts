import { Component, OnInit, Input , Self} from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-date-input',
  templateUrl: './date-input.component.html',
  styleUrls: ['./date-input.component.css']
})
export class DateInputComponent implements ControlValueAccessor {

    @Input() label: string;
    @Input() maxDate:  Date;
    bsConfig: Partial<BsDatepickerConfig>;

    colorTheme = 'theme-red';

  constructor(@Self()  public ngControl: NgControl ) {
    console.log("date-input component - constructor() ");
    this.ngControl.valueAccessor = this;
    this.bsConfig =  { containerClass: this.colorTheme ,
                      dateInputFormat: 'DD MMMM YYYY' } ;
      
     
  }  
   writeValue(obj: any): void {
    console.log("date-input component - writeValue() ");
  
  }
  
  registerOnChange(fn: any): void {
    console.log("date-input component - registerOnChange() ");
  
  }
  
  registerOnTouched(fn: any): void {
    console.log("date-input component - registerOnTouched() ");
  
  }
 
  
}
