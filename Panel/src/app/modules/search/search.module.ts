import { NgModule } from '@angular/core';
import { SharedModule } from "../shared/shared.module";
import { SearchComponent } from "./search.component";
import { SearchRoutingModule } from "./search-routing.module";

@NgModule({
  declarations: [
    SearchComponent,
  ],
  imports: [
    SharedModule,
    SearchRoutingModule,
  ]
})
export class SearchModule { }
