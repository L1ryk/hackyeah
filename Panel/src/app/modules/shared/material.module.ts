import { NgModule } from "@angular/core";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";

const imports = [
  MatToolbarModule,
  MatInputModule,
  MatButtonModule,
]

@NgModule({
  imports,
  exports: imports,
})
export class MaterialModule { }
