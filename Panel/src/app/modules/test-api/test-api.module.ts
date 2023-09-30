import { NgModule } from '@angular/core';
import { TestApiComponent } from "./test-api.component";
import { SharedModule } from "../shared/shared.module";
import { TestApiRoutingModule } from "./test-api-routing.module";

@NgModule({
  declarations: [
    TestApiComponent,
  ],
  imports: [
    SharedModule,
    TestApiRoutingModule,
  ]
})
export class TestApiModule { }
