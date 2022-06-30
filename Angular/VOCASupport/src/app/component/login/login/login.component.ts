import { HttpClient, HttpHandler } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { NgxSpinnerService } from 'ngx-spinner';
import { LoginController, LoginModel } from 'src/app/shared/service-proxies/service-proxies';
import { SubjectService } from 'src/app/shared/subject-service/subject.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [LoginController, HttpClient]
})
export class LoginComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private roter: Router,
    private loginController: LoginController,
    private subjectService: SubjectService,
    private spinner: NgxSpinnerService) { }

  loginmodel!: LoginModel;
  showSpinner = false;
  loginfrm!: FormGroup;
  Err_!: string
  invalidlogin!: boolean;

  ngOnInit(): void {
    this.loginfrm = this.fb.group({
      userName: [''],
      password: [''],
    })
  }
  loggggg(loginfrm: FormGroup) {
    this.spinner.show();
    this.loginmodel = this.loginfrm.value;
    this.showSpinner = true;
    this.loginController.getUsrLogin(this.loginmodel).subscribe(res => {
      localStorage.setItem("jwtVOCA", <any>res.token)

      let JwtHelper = new JwtHelperService();
      let token = localStorage.getItem("jwtVOCA");

      if (token != null) {
        this.spinner.hide();
        this.invalidlogin = false;

        let jj = JwtHelper.decodeToken(token);
        this.subjectService.changeMessege(jj.nameid)
        this.roter.navigate(["/"])
        if (JwtHelper.isTokenExpired(token)) {
        }
      }
      else {
        this.spinner.hide();
        this.invalidlogin = true;
      }
    },
      err => {
        this.spinner.hide();
        this.invalidlogin = true;
        this.showSpinner = false;
        this.Err_ = err.message
        if (err.status == 401) { this.Err_ = "Invalid User Name Or Password" } else if (err.status == 0) { this.Err_ = "Service Down" }
        this.invalidlogin = true;
        //this.AuthStat = false;
      })
  }
}
