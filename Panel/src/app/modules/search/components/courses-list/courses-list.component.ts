import { Component, Input } from "@angular/core";

@Component({
  selector: 'app-courses-list',
  templateUrl: './courses-list.component.html',
  styleUrls: ['./courses-list.component.sass']
})
export class CoursesListComponent {
  @Input() coursesList: any[]
}
