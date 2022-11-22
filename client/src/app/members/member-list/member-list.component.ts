import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
//import { Console } from 'console';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { User } from 'src/app/_models/user';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { take } from 'rxjs/operators';


@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

 
  members:  Member[];
  pagination: Pagination;  
  userParams: UserParams;
  user: User;
  genderList = [{value: 'male', display:'Males'} ,{value: 'female', display:'Females'}];

  //pageNumber = 1;
  //pageSize = 5;
  // members$: Observable< Member[]>;

  
  constructor(private memberService: MembersService   )
  { 
    this.userParams = memberService.getUserParams();    
  }


  ngOnInit(): void {
    console.log( "["+ new Date().toISOString() + "] MemberListComponent.ts - ngOnInit (load members)");   
    //this.loadMembers();
    //this.members$= this.memberService.getMembers();
    this.loadMembers();
  }

  loadMembers() {
      console.log(  "["+ new Date().toISOString() + "]  MemberListComponent.ts - loadMembers");   
      
      this.memberService.setUserParams(this.userParams);

      this.memberService.getMembers(this.userParams).subscribe(response => {
        this.members = response.result;
        this.pagination = response.pagination;
    })
  }

  resetFilters() {
    this.userParams= this.memberService.resetUserParams();
    this.loadMembers();
  }

  pageChanged(event: any ){
    console.log(  "["+ new Date().toISOString() + "] MemberListComponent.ts - pageChanged");   
    this.userParams.pageNumber = event.page;
    this.memberService.setUserParams(this.userParams);
    this.loadMembers();
  }

  /*loadMembers() {
        //console.log( ">>> MemberListComponent.ts - loadMembers");   
        this.memberService.getMembers().subscribe(members => {this.members = members;
      })
  }
  */

  ngAfterContentInit(): void {
    //console.log( ">>> MemberListComponent.ts - ngAfterContentInit");   
  }


}
