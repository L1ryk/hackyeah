import { Component } from '@angular/core';
import { FormBuilder, FormControl } from "@angular/forms";
import { QuestionInterface } from "../../../../interfaces/question.interface";
import { AnswerInterface } from "../../../../interfaces/answer.interface";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.sass']
})
export class QuestionComponent {
  form = this.fb.group({
    answer: new FormControl<string>('')
  })

  answers: AnswerInterface[] = []

  previousNotFilterAnswer: string | boolean | undefined
  currentIndex = 0

  readonly questions: QuestionInterface[] = [
    {
      text: 'Czy wiesz jaki zawód chciałbyś wykonywać po studiach?',
      isYesNoQuestion: true,
    },
    {
      text: 'Kim chcesz zostać w przyszłości?',
      filter: 'profession',
      previousHasToBeTruthy: true,
    },
    {
      text: 'Czy chcesz się kształcić w kierunku zgodnym ze swoimi zainteresowaniami?',
      isYesNoQuestion: true,
    },
    {
      text: 'Czym się interesujesz?',
      filter: 'interests',
      previousHasToBeTruthy: true,
    },
    {
      text: 'Czy interesują Cię uczelnie poza Twoim miejscem zamieszkania?',
      isYesNoQuestion: true,
    },
    {
      text: 'Jak daleko chciałbyś dojeżdżać?',
      filter: 'distance',
      previousHasToBeTruthy: true,
    },
    {
      text: 'Gdzie mieszkasz?',
      filter: 'city'
    },
    {
      text: 'Czy interesuje Cię odpłatne kształcenie?',
      filter: 'hasToBeFree',
      isYesNoQuestion: true,
    },
    {
      text: 'Jaki tytuł chciałbyś otrzymać po ukończeniu studiów?',
      filter: 'title'
    }
  ]

  constructor(
    private fb: FormBuilder
  ) {
  }

  onSubmitQuestion() {
    let answer: string | boolean = this.form.value.answer as string

    if (!answer) return

    const currentQuestion = this.questions[this.currentIndex]

    if (currentQuestion.isYesNoQuestion) {
      answer = answer === 'Tak'
    }

    if (currentQuestion.filter) {
      this.answers.push({
        filter: currentQuestion.filter,
        answer,
      })
    } else {
      this.previousNotFilterAnswer = answer
    }

    if (this.currentIndex < this.questions.length - 1) {
      if (typeof answer === 'boolean') {
        this.currentIndex += this.getNextQuestionJump(answer)
      } else {
        this.currentIndex += 1
      }

      this.form.reset()
    } else {
      console.warn(this.answers)
    }
  }

  private getNextQuestionJump(answer: boolean, jump = 1): number {
    if (!this.questions[this.currentIndex + jump].previousHasToBeTruthy) {
      return jump
    }

    if (this.questions[this.currentIndex + jump].previousHasToBeTruthy && answer) return jump

    return this.getNextQuestionJump(answer, jump + 1)
  }
}
