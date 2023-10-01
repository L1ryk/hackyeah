import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from "@angular/forms";
import { QuestionInterface } from "../../../../interfaces/question.interface";
import { AnswerInterface } from "../../../../interfaces/answer.interface";
import { ApiService } from "../../../../services/api.service";
import { map, Observable, of, Subscription } from "rxjs";
import { ResultMany } from "../../../../interfaces/api.interface";
import { Router } from "@angular/router";

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.sass']
})
export class QuestionComponent implements OnInit, OnDestroy {
  form: FormGroup
  answers: AnswerInterface[] = []

  previousNotFilterAnswer: string | boolean | undefined
  currentIndex = 0

  autocompleteOptions: Observable<{ id: string, name: string }[]>
  textControlSub: Subscription

  readonly questions: QuestionInterface[] = [
    {
      text: 'Czy wiesz jaki zawód chciałbyś wykonywać po studiach?',
      isYesNoQuestion: true,
    },
    {
      text: 'Kim chcesz zostać w przyszłości?',
      filter: 'occupation',
      previousHasToBeTruthy: true,
      autocompleteEndpoint: '/api/occupations/search'
    },
    {
      text: 'Czy chcesz się kształcić w kierunku zgodnym ze swoimi zainteresowaniami?',
      isYesNoQuestion: true,
    },
    {
      text: 'Czym się interesujesz?',
      filter: 'tags',
      previousHasToBeTruthy: true,
      autocompleteEndpoint: '/api/tags/search',
    },
    {
      text: 'Czy chcesz studiować niestacjonarnie/weekendowo?',
      filter: 'isStationary',
      isYesNoQuestion: true,
    },
    // {
    //   text: 'Czy interesują Cię uczelnie poza Twoim miejscem zamieszkania?',
    //   isYesNoQuestion: true,
    // },
    // {
    //   text: 'Jak daleko chciałbyś dojeżdżać?',
    //   filter: 'distance',
    //   previousHasToBeTruthy: true,
    // },
    {
      text: 'Gdzie mieszkasz?',
      filter: 'city',
      previousHasToBeTruthy: true,
    },
    {
      text: 'Czy interesuje Cię odpłatne kształcenie?',
      filter: 'brand',
      // isYesNoQuestion: true,
    },
    // {
    //   text: 'Jaki tytuł chciałbyś otrzymać po ukończeniu studiów?',
    //   filter: 'title',
    //   autocompleteEndpoint: '/api/title/search'
    // }
  ]

  constructor(
    private fb: FormBuilder,
    private api: ApiService,
    private router: Router,
  ) {
  }

  ngOnInit() {
    this.form = this.fb.group({
      textAnswer: new FormControl<string>(''),
      booleanAnswer: new FormControl<boolean>(true),
    })

    this.textControlSub = this.form.controls['textAnswer'].valueChanges.subscribe(value => this.updateAutoComplete(value))
  }

  ngOnDestroy() {
    this.textControlSub.unsubscribe()
  }

  onSubmitQuestion() {
    let answer: string | boolean

    const currentQuestion = this.questions[this.currentIndex]

    if (currentQuestion.isYesNoQuestion) {
      answer = this.form.value.booleanAnswer as boolean
    } else {
      answer = this.form.value.textAnswer as string

      if (!answer) return
    }

    if (currentQuestion.filter) {
      this.answers.push({
        filter: currentQuestion.filter,
        answer: answer,
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
      this.router.navigate(['/search'], {queryParams: {data: JSON.stringify(this.answers)}})
    }
  }

  updateAutoComplete(inputValue: string) {
    const body = {
      part: inputValue,
      limit: 10,
    }

    const autocompleteEndpoint = this.questions[this.currentIndex].autocompleteEndpoint

    if (!autocompleteEndpoint || !inputValue || inputValue.length < 3) {
      this.autocompleteOptions = of([])
      return
    }

    this.autocompleteOptions = this.api
      .post$<ResultMany<{
        id: string,
        name: string
      }>>(autocompleteEndpoint, body)
      .pipe(
        map(res => (res.items))
      )
  }

  reset() {
    this.currentIndex = 0
    this.answers = []
    this.previousNotFilterAnswer = undefined
    this.form.reset()
  }

  private getNextQuestionJump(answer: boolean, jump = 1): number {
    if (!this.questions[this.currentIndex + jump].previousHasToBeTruthy) {
      return jump
    }

    if (this.questions[this.currentIndex + jump].previousHasToBeTruthy && answer) return jump

    return this.getNextQuestionJump(answer, jump + 1)
  }
}
