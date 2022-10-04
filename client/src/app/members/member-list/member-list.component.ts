import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
//import { Console } from 'console';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit {

  members$: Observable< Member[]>;
  
  constructor(private memberService: MembersService ) { }

  ngOnInit(): void {
    console.log( "\n ["+ new Date().toISOString() + "] >>> MemberListComponent.ts - ngOnInit (load members)");   
    //this.loadMembers();
    this.members$= this.memberService.getMembers();
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
