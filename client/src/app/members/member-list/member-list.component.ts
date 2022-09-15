import { Component, OnInit } from '@angular/core';
//import { Console } from 'console';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  members: Member[];
  
  constructor(private memberService: MembersService ) { }

  ngOnInit(): void {
    //console.log( ">>> MemberListComponent.ts - ngOnInit");   
    this.loadMembers();
  }

  loadMembers() {
        //console.log( ">>> MemberListComponent.ts - loadMembers");   
        this.memberService.getMembers().subscribe(members => {this.members = members;
      })
  }

  ngAfterContentInit(): void {
    //console.log( ">>> MemberListComponent.ts - ngAfterContentInit");   
  }


}
