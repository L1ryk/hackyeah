import { NgModule } from '@angular/core';
import { SharedModule } from "../shared/shared.module";
import { SearchComponent } from "./search.component";
import { SearchRoutingModule } from "./search-routing.module";
import { CourseComponent } from "./components/course/course.component";
import { CoursesListComponent } from "./components/courses-list/courses-list.component";

@NgModule({
  declarations: [
    SearchComponent,
    CourseComponent,
    CoursesListComponent,
  ],
  imports: [
    SharedModule,
    SearchRoutingModule,
  ]
})
export class SearchModule {
}
