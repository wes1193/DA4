import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';


@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = environment.apiUrl;
  members: Member[] = []; // initialize to an empty array

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  constructor(private http: HttpClient) { 
    console.log("["+ new Date().toISOString() + "] client app - member.service.ts - constructor");
  }

    /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
    getMembers(){
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getMembers");
    
    /*  if we already have the members, return them.  "of()"" is an observable*/
    if (this.members.length > 0) 
      return of(this.members);

    /* "map" returns an observable */
    return this.http.get<Member[]>(this.baseUrl + 'users').pipe(
      map(members => {
            this.members = this.members;
            return members;
            }
          )
      );
  
  }
  
  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  getMember(username: string){
    console.log("["+ new Date().toISOString() + "] client app - member.service.ts - getMember");    

    const member = this.members.find(x => x.username === username);
    if(member != undefined) 
       return of(member);

    return this.http.get<Member>(this.baseUrl + 'users/' + username);
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  updateMember(member: Member){
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - updateMember " + member.username);
    return this.http.put(this.baseUrl + 'users',  member).pipe(
      map(() => {
            const index = this.members.indexOf(member);
            this.members[index] = member;
        }
      )
    );
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  setMainPhoto(photoId: number) {

    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId , {});
  }
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
deletePhoto(photoId: number) {

  return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId );
}

} // end class
