import { NgModule } from '@angular/core'
import { RouterModule } from '@angular/router'
import { MainComponent } from './main.component'
import {SharedModule} from "../shared/shared.module";

@NgModule({
  imports: [
    RouterModule,
    SharedModule,
  ],
  declarations: [
    MainComponent,
  ],
  exports: [
    MainComponent
  ],
})
export class MainModule { }
