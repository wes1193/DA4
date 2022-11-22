import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css']
})
export class TestErrorsComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/';
  validationErrors: string[] = [];


  constructor(private http:HttpClient) {
    console.log( "\n\n["+ new Date().toISOString() + "]  ngOnInit - constructor");
   }

  ngOnInit(): void {
    console.log( "\n\n["+ new Date().toISOString() + "]  ngOnInit - start");
  }

  get404Error()
  {
    console.log( "\n\n["+ new Date().toISOString() + "]  get404Error - start");
    
    this.http.get(this.baseUrl+'buggy/not-found').subscribe(
        response => { console.log("\n\n["+ new Date().toISOString() + "] buggy-not-found 404 - response: " + JSON.stringify(response));
                    } , 
        error =>    { console.log("\n\n["+ new Date().toISOString() + "] buggy-not-found 404 - error: " +  JSON.stringify(error) );
                    }
      )
  }

  get400Error()
  {
    console.log( "\n\n["+ new Date().toISOString() + "]  get400Error - start");
    
    this.http.get(this.baseUrl+'buggy/bad-request').subscribe(
        response => { console.log("\n\n["+ new Date().toISOString() + "] buggy-bad-request 400 - response: " + JSON.stringify(response));
                    } , 
        error =>    {console.log("\n\n["+ new Date().toISOString() + "]  buggy-bad-request 400 - error: " + JSON.stringify(error) );
                    }
      )
  }

  get500Error()
  {
    console.log( "\n\n["+ new Date().toISOString() + "]  get400Validationget500ErrorError - start");
    
    this.http.get(this.baseUrl+'buggy/server-error').subscribe(
        response => { console.log("\n\n["+ new Date().toISOString() + "]  buggy-server-error 500 - response: " + JSON.stringify(response));
                    } , 
        error =>    {console.log("\n\n["+ new Date().toISOString() + "]  buggy-server-error 500 - error: " + JSON.stringify(error) );
                    }
      )
  }

  get401Error()
  {
    console.log( "\n\n["+ new Date().toISOString() + "]  get401Error - start");
    
    this.http.get(this.baseUrl+'buggy/auth').subscribe(
        response => { console.log("\n\n["+ new Date().toISOString() + "]  buggy-auth 401 - response: " + JSON.stringify(response));
                    } , 
        error =>    {console.log("\n\n["+ new Date().toISOString() + "]  buggy-auth 401 - error: " + JSON.stringify(error) );
                    }
      )
  }


  get400ValidationError()
  {
    console.log( "\n\n["+ new Date().toISOString() + "]  get400ValidationError - start");
    
    this.http.post(this.baseUrl + 'account/register', {}).subscribe(
        response => { console.log( "\n\n["+ new Date().toISOString() + "]  get400ValidationError - response: " + JSON.stringify(response) );
                    } , 
           error => {console.log( "\n\n["+ new Date().toISOString() + "]  get400ValidationError - error: " + JSON.stringify(error) );
                      this.validationErrors = error;
                    }
      )
  }

}
