import { NgModule } from "@angular/core";
import { MaterialModule } from "./material.module";
import { ToolbarComponent } from "./toolbar/toolbar.component";
import { RouterModule } from "@angular/router";
import { CommonModule } from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { NgSelectModule } from '@ng-select/ng-select';

const components = [
  ToolbarComponent,
]

const imports = [
  CommonModule,
  MaterialModule,
  RouterModule,
  ReactiveFormsModule,
  NgSelectModule,
]

@NgModule({
  declarations: components,
  imports,
  providers: [],
  exports: [
    ...components,
    ...imports,
  ],
})
export class SharedModule {
}
