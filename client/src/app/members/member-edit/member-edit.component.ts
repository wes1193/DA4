import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  
  // class properties
  @ViewChild('editForm') editForm: NgForm;
  member: Member;
  user:User;
  @HostListener('window:beforeunload',['$event']) unloadNotification($event:any) {
    if(this.editForm.dirty)
      $event.returnValue = true;
  };
  
  constructor(private accountService: AccountService
              , private memberService: MembersService 
              , private toastr: ToastrService) 
  {
      console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - Constructor - start");
      this.accountService.currentUser$.pipe(take(1)).subscribe(user => this.user = user);
      // this.toastr.info('MemberEditComponent.ts - Constructor');
  }

  ngOnInit(): void {
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - ngOnInit - start");
    this.loadMember();
    //console.log("["+ new Date().toISOString() + "] "MemberEditComponent.ts - ngOnInit - member : " + this.member.username);
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - ngOnInit - stop");
    
  }

  loadMember(){
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - loadMember - start");
    this.memberService.getMember(this.user.username).subscribe(member => {
            this.member =  member;        
          }      
        )        
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - loadMember - this.member.description: " );
  }

  updateMember(){
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - updateMember - START -this.member.description: " + this.member );
    
    this.memberService.updateMember(this.member).subscribe(() => {
        this.toastr.success('Profile updated successfully');
        this.editForm.reset(this.member); 
    })
    
    console.log("["+ new Date().toISOString() + "] MemberEditComponent.ts - updateMember - STOP -this.member.description: " + this.member );
    
  }
}
