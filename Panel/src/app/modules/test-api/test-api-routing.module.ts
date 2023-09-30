import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import {TestApiComponent} from "./test-api.component";

const routes: Routes = [{
  path: '',
  component: TestApiComponent,
}]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TestApiRoutingModule { }
