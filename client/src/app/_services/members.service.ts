import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of, pipe } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { PaginatedResult } from '../_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from './account.service';
import { take } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;
  members: Member[] = []; // initialize to an empty array
  memberCache = new Map();
  userParams: UserParams;
  user: User;

  // paginatedResult: PaginatedResult<Member[]> = new PaginatedResult<Member[]>();

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  constructor(private http: HttpClient, private accountService: AccountService ) { 
    console.log("["+ new Date().toISOString() + "] client app - member.service.ts - constructor");
    this.accountService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.user = user;
      this.userParams = new UserParams(user);
      } ) ;
  }

  getUserParams() {
    return this.userParams;
  }
  setUserParams(params:UserParams) {
    this.userParams = params;
 }
 resetUserParams() {
  this.userParams = new UserParams(this.user);
  return this.userParams;
}

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  getMember(username: string){
    console.log("["+ new Date().toISOString() + "] client app - member.service.ts - getMember - >>> memberCache:" );    
    console.log(  this.memberCache);    
    const member  = [...this.memberCache.values()]
    .reduce((arr, elem) => arr.concat(elem.result), [] ) 
    .find((member: Member) => member.username ===  username)  ;
    console.log("["+ new Date().toISOString() + "] client app - member.service.ts - getMember - >>> member:" );   
    console.log( member);    
    
    if(member) {
       return of(member);
    }
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
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - setMainPhoto " );
    return this.http.put(this.baseUrl + 'users/set-main-photo/' + photoId , {});
  }
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  deletePhoto(photoId: number) {
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - deletePhoto " );
    return this.http.delete(this.baseUrl + 'users/delete-photo/' + photoId );
  }

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  addLike(username: string) {
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - addLike " );
    return this.http.post(this.baseUrl + 'likes/' + username , {} );
  }
  
/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  getLikes(predicate: string, pageNumber, pageSize,) {
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getLikes + predicate: " );

    let params = this.getPaginationHeaders(pageNumber, pageSize);
    params = params.append('predicate',predicate);
    //return this.http.get<Partial<Member[]>>(this.baseUrl + 'likes?predicate=' + predicate );
    return this.getPaginatedResult<Partial<Member[]>>(this.baseUrl + 'likes', params);
}

/* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */
  getMembers(userParams: UserParams) {
    
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getMembers - >>> userParams: " + Object.values(userParams).join('-') );

    // if the query results are in cache, then return what's in cache
    var response = this.memberCache.get(Object.values(userParams).join('-'));
    if (response){
      console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getMembers Found in Cache!!! " + Object.values(userParams).join('-') );
      return of(response);
    }


    let params = this.getPaginationHeaders(userParams.pageNumber, userParams.pageSize);

    params = params.append('minAge',userParams.minAge.toString() );
    params = params.append('maxAge',userParams.maxAge.toString() );
    params = params.append('gender',userParams.gender );          
    params = params.append('orderBy',userParams.orderBy );  

    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getMembers - page: " + JSON.stringify(userParams.pageNumber) + "    itemsPerPage: " + JSON.stringify( userParams.pageSize )  + "  >>  caching: " )+ Object.values(userParams).join('-');
       
    // this will store the response in cache, and then return the response;
    return this.getPaginatedResult<Member[]>(this.baseUrl + 'users',  params)
      .pipe(map(response => {
        this.memberCache.set(Object.values(userParams).join('-'), response);
        return response;
      }));
   
  }

  private getPaginatedResult<T>(url, params) {
    
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getPaginatedResult: " );
    const paginatedResult: PaginatedResult<T> = new PaginatedResult<T>();

    return this.http.get<T>(url , { observe: 'response', params }).pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') !== null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      } )
    );
  }

  private getPaginationHeaders( pageNumber: number, pageSize: number) {
    
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - getPaginationHeaders " );
    
    let params = new HttpParams();
    
      params = params.append('pageNumber', pageNumber.toString());
      params = params.append('pageSize'  , pageSize.toString());
  
    return params;
  }   

} // end class
