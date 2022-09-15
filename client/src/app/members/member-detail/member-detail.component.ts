import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { stringify } from 'querystring';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { DatePipe } from '@angular/common';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';


@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit 
{

    member: Member;
    galleryOptions: NgxGalleryOptions[];
    galleryImages: NgxGalleryImage[];


    
    //, private datePipe: DatePipe
    constructor(private memberService: MembersService, private route: ActivatedRoute
              ,private toastr: ToastrService , private datePipe: DatePipe ) { }

    ngOnInit(): void 
    {
      //this.galleryImages = this.getImages();
      this.loadMember();
      this.galleryOptions = [
                              {width:'500px' , 
                                height:'500px' , 
                                imagePercent:100,
                                thumbnailsColumns: 4,
                                imageAnimation: NgxGalleryAnimation.Slide,
                                preview:false
                              }
                            ]        
    }


    transformDate(date: Date) {
      return this.datePipe.transform(date, 'yyyy-MM-dd').toString();
    }

    loadMember()
    {
      msgStr: String;
      dateStr: String;
      myDate: String;
      let myDate = Date.now.toString;
    
      //let dateStr = transformDate(myDate); 

      //let msgStr =   myDate + " >>>>>> loadMember() message \n\n <<<<<<<";
      let msgStr =   " >>>>>> loadMember() message \n\n <<<<<<<";
      this.toastr.info(msgStr, "member-detail-compnent.ts", {  timeOut: 3000, });    
      console.log(msgStr);
      this.memberService.getMember(this.route.snapshot.paramMap.get('username')).subscribe(member => {
            this.member = member ;
            this.galleryImages = this.getImages();
          } );
    }
  
  getImages(): NgxGalleryImage[]
  { const imageUrls = [];
    for (const photo of this.member.photos) 
    {
        imageUrls.push(
                        { small:photo?.url ,
                          medium:photo?.url ,
                          big:photo?.url  
                        }
      ) 
    } // end for

    return imageUrls;

  }   // end method
 
} // end class



