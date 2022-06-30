import { NgModule } from '@angular/core';
import { MatButtonModule } from '@Angular/material/button'
import { MatButtonToggleModule } from '@Angular/material/button-toggle'
import { MatIconModule } from '@Angular/material/icon'
import { MatBadgeModule } from '@Angular/material/badge'
import { MatProgressSpinnerModule } from '@Angular/material/progress-spinner'
import { MatToolbarModule } from '@angular/material/toolbar'
import { MatSidenavModule } from '@angular/material/sidenav'
import { FormsModule } from '@angular/forms';
import { MatMenuModule } from '@angular/material/menu'
import { MatExpansionModule } from '@angular/material/expansion';
import { MatProgressBarModule } from '@angular/material/progress-bar'

const material = [
  MatButtonModule,
  MatButtonToggleModule,
  MatIconModule,
  MatBadgeModule,
  MatProgressSpinnerModule,
  MatToolbarModule,
  MatSidenavModule,
  MatMenuModule,
  MatExpansionModule,
  MatProgressBarModule,
  FormsModule
]


@NgModule({
  declarations: [],
  imports: [material],
  exports: [material]

})
export class MaterialModule { }
