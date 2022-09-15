import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';


@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { 
    //console.log("member.service.ts - constructor");
  }

  getMembers(){
    //console.log("member.service.ts - getMembers");
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }
  getMember(username: string){
   // console.log("member.service.ts - getMember");
    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

} // end class
