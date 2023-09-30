import { NgModule } from "@angular/core";
import { MatToolbarModule } from "@angular/material/toolbar";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatCheckboxModule } from "@angular/material/checkbox";
import { MatRadioModule } from '@angular/material/radio';

const imports = [
  MatToolbarModule,
  MatInputModule,
  MatButtonModule,
  MatCheckboxModule,
  MatRadioModule,
]

@NgModule({
  imports,
  exports: imports,
})
export class MaterialModule {
}
