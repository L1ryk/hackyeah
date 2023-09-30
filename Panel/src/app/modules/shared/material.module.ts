import { NgModule } from "@angular/core";
import { MatToolbarModule } from "@angular/material/toolbar";

const imports = [
  MatToolbarModule,
]

@NgModule({
  imports,
  exports: imports,
})
export class MaterialModule { }
