import { Component } from '@angular/core';
import { FormBuilder, FormControl } from "@angular/forms";
import { QuestionInterface } from "../../../../interfaces/question.interface";
import { AnswerInterface } from "../../../../interfaces/answer.interface";
import { ApiService } from "../../../../services/api.service";
import { map, Observable, of } from "rxjs";
import { ResultMany } from "../../../../interfaces/api.interface";
import { Router } from "@angular/router";
import { SearchItemInterface } from 'src/app/interfaces/search-item.interface';

@Component({
  selector: 'app-question',
  templateUrl: './question.component.html',
  styleUrls: ['./question.component.sass']
})
export class QuestionComponent {
  form = this.fb.group({
    textAnswer: new FormControl<SearchItemInterface | SearchItemInterface[] | null>(null),
    booleanAnswer: new FormControl<boolean | null>(true),
  })
  answers: AnswerInterface[] = []
  currentIndex = 0
  autocompleteOptions: Observable<SearchItemInterface[]>

  readonly searchFn = () => {
    return true
  }

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
      multiple: true,
    },
    {
      text: 'Czy chcesz studiować stacjonarnie?',
      filter: 'isStationary',
      isYesNoQuestion: true,
      hasNullOption: true,
    },
    {
      text: 'Czy wiesz w jakim mieście chciałbyś studiować?',
      previousHasToBeTruthy: true,
      isYesNoQuestion: true,
    },
    {
      text: 'Jakie to miasto?',
      filter: 'city',
      previousHasToBeTruthy: true,
      autocompleteEndpoint: '/api/location/search_cities'
    },
    {
      text: 'Jaki rodzaj uczelni Cię interesuje?',
      filter: 'brand',
      multiple: true,
      staticValues: [
        {
          id: 'Uczelnia publiczna',
          name: 'Uczelnia publiczna',
        },
        {
          id: 'Uczelnia niepubliczna',
          name: 'Uczelnia niepubliczna',
        },
        {
          id: 'Uczelnia kościelna',
          name: 'Uczelnia kościelna',
        },
      ],
      hasNullOption: true,
    },
    {
      text: 'Na jaki poziom studiów chciałbyś pójść',
      filter: 'level',
      multiple: true,
      staticValues: [
        {
          id: 'I stopnia',
          name: 'I stopnia',
        },
        {
          id: 'Jednolite magisterskie',
          name: 'Jednolite magisterskie',
        },
      ],
      hasNullOption: true,
    },
  ]

  constructor(
    private fb: FormBuilder,
    private api: ApiService,
    private router: Router,
  ) {
  }

  onSubmitQuestion(allowNull = false) {
    let answer: string | boolean | string[]

    const currentQuestion = this.questions[this.currentIndex]

    if (currentQuestion.isYesNoQuestion) {
      answer = this.form.value.booleanAnswer as boolean
    } else {
      const textAnswer = this.form.value.textAnswer

      if (Array.isArray(textAnswer)) {
        answer = textAnswer.map(a => a.id)
      } else {
        answer = textAnswer?.id as string
      }

      if (!allowNull && (!answer || !answer.length)) return
    }

    if (currentQuestion.filter && answer) {
      this.answers.push({
        filter: currentQuestion.filter,
        answer,
      })
    }

    if (this.currentIndex < this.questions.length - 1) {
      if (typeof answer === 'boolean') {
        this.currentIndex += this.getNextQuestionJump(answer)
      } else {
        this.currentIndex += 1
      }

      this.updateAutoComplete('')
      this.form.reset({
        textAnswer: null,
        booleanAnswer: true,
      })
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
    this.form.reset({
      textAnswer: null,
      booleanAnswer: true,
    })
  }

  private getNextQuestionJump(answer: boolean, jump = 1): number {
    if (!this.questions[this.currentIndex + jump].previousHasToBeTruthy) {
      return jump
    }

    if (this.questions[this.currentIndex + jump].previousHasToBeTruthy && answer) return jump

    return this.getNextQuestionJump(answer, jump + 1)
  }
}
