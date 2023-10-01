import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from "@angular/router";
import { map, Observable, Subscription } from "rxjs";
import { ApiService } from "../../services/api.service";
import { ResultMany } from "../../interfaces/api.interface";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.sass']
})
export class SearchComponent implements OnInit, OnDestroy {
  courses: Observable<any>
  paramsSub: Subscription

  constructor(
    private activatedRoute: ActivatedRoute,
    private api: ApiService,
  ) {
  }

  ngOnInit() {
    this.paramsSub = this.activatedRoute.queryParams.subscribe(params => {
      const filters = (JSON.parse(params['data']) as Array<{ filter: string, answer: any }>)
        .map(filter => ({property: filter.filter, value: filter.answer}))

      this.courses = this.api.post$<ResultMany<any>>('/api/university/courses', {filters})
        .pipe(
          map(res => (res.items))
        )
    })
  }

  ngOnDestroy() {
    this.paramsSub.unsubscribe()
  }
}
