import { Component, Input, OnInit, Self } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.css']
})
export class TextInputComponent implements ControlValueAccessor {

    @Input() label: string;
    @Input() type = 'text';

  /* Inject the control into this component */

  constructor(@Self() public ngControl: NgControl) 
  { console.log("text-input component - constructor() ");
    this.ngControl.valueAccessor = this;

  }

  writeValue(obj: any): void 
  { console.log("text-input component - writeValue() ");
    console.log("text-input component - writeValue() -  obj: " + JSON.stringify(obj) );
    
  }
  
  registerOnChange(fn: any): void 
  { console.log("text-input component - registerOnChange() ");
  console.log("text-input component - registerOnChange() -  fn: " + JSON.stringify(fn) );
  }

  registerOnTouched(fn: any): void 
  { console.log("text-input component - registerOnTouched() ");
    
  }
  

  

}
