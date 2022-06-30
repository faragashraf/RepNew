import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
// Import library module
import { NgxSpinnerModule } from "ngx-spinner";
import { LoginComponent } from './component/login/login/login.component';

const appRoutes: Routes = [

  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: '', redirectTo: '', pathMatch: 'full' },

  
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,
    NgxSpinnerModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  exports: [RouterModule]
})
export class AppRoutingModule { }
