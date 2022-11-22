import { Component, OnInit, Input } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-card',
  templateUrl: './member-card.component.html',
  styleUrls: ['./member-card.component.css'],
})
export class MemberCardComponent implements OnInit {
  @Input() member: Member;

  constructor(private memberService : MembersService, private toastr: ToastrService) { 
    //console.log( "["+ new Date().toISOString() + "] client app - member-MemberCardComponent.ts - constructor "  );
  }

  ngOnInit(): void {
    //console.log( "["+ new Date().toISOString() + "] client app - member-MemberCardComponent.ts - ngOnInit " );
  }

  /* - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - */

  addLike(member: Member) {
    console.log( "["+ new Date().toISOString() + "] client app - member.service.ts - addLike " );
    this.memberService.addLike(member.username).subscribe( () => {
      this.toastr.success('You have liked ' + member.knownAs);
    }) 
  } 

}