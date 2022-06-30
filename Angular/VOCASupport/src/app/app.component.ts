import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import Swal from 'sweetalert2';
import { SubjectService } from './shared/subject-service/subject.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'VOCASupport';
  UserName_: string = "";


  AuthStat!: string;
  UserRole!: string;
  messege: string = "";

  ngOnInit(): void {
    this.subjectService.currentmessege.subscribe(messege => this.UserName_ = messege)
  }
  constructor(private subjectService: SubjectService,
    private roter: Router) { }

  logout() {
    Swal.fire({
      title: 'هل تريد الاستمرار؟',
      icon: 'question',
      iconHtml: '؟',
      confirmButtonText: 'نعم',
      cancelButtonText: 'لا',
      showCancelButton: true,
      //showCloseButton: true
    }).then((result) => {
      if (result.isConfirmed) {
        this.subjectService.changeMessege("")
        localStorage.removeItem("jwtVOCA");
        this.roter.navigate(["/login"])
      }
      else {
        Swal.fire('Any fool can use a computer')
      }
    })

  }
}
