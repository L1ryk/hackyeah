import { NgModule } from '@angular/core';
import { SharedModule } from "../shared/shared.module";
import { QuizComponent } from "./quiz.component";
import { QuizRoutingModule } from "./quiz-routing.module";
import { QuestionComponent } from './components/question/question.component';

@NgModule({
  declarations: [
    QuizComponent,
    QuestionComponent,
  ],
  imports: [
    SharedModule,
    QuizRoutingModule,
  ]
})
export class QuizModule {
}
