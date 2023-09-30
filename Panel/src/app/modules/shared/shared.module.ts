import { NgModule } from "@angular/core";
import { MaterialModule } from "./material.module";
import { ToolbarComponent } from "./toolbar/toolbar.component";

const components = [
  ToolbarComponent,
]

@NgModule({
  declarations: components,
  imports: [
    MaterialModule,
  ],
  providers: [],
  exports: components,
})
export class SharedModule { }
