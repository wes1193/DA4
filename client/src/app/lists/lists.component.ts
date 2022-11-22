import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { Pagination } from '../_models/pagination';
import { MembersService } from '../_services/members.service';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {

  members: Partial<Member[]>;
  predicate = 'liked';
  pageNumber = 1;
  pageSize =  5;
  pagination: Pagination;

  constructor(private memberService: MembersService) { 
     console.log( "["+ new Date().toISOString() + "] ListsComponent.ts - Constructor" );
     this.loadLikes();
  }

  
  ngOnInit(): void {
    console.log( "["+ new Date().toISOString() + "] ListsComponent.ts - ngOnInit" );
  }

  loadLikes() {
    console.log( "["+ new Date().toISOString() + "] ListsComponent.ts - loadLikes" );
    this.memberService.getLikes(this.predicate, this.pageNumber, this.pageSize).subscribe(response => {
      this.members = response.result;
      this.pagination = response.pagination;
    })
  }

  pageChanged(event:any){

    console.log( "["+ new Date().toISOString() + "] ListsComponent.ts - pageChanged" );
    this.pageNumber = event.page;
     this.loadLikes();
  }
}
