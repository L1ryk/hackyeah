import { Injectable } from '@angular/core'
import { environment } from 'src/environment/environment'
import { Observable, Subject, throwError } from 'rxjs'
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http'
import { catchError, timeout } from 'rxjs/operators'
import { ApiInterface } from "../interfaces/api.interface";

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private static uri = environment.apiUrl
  private static timeout = environment.timeout

  constructor(
    private http: HttpClient
  ) {
  }

  get$<T>(fn: string, data: { [index: string]: any } = {}): Observable<T> {
    const state = new Subject<T>()
    let params = new HttpParams()

    Object.keys(data).forEach(e => {
      if (typeof data[e] === 'object') {
        Object.keys(data[e]).forEach(x => {
          params = params.append(`${e}.${x}`, data[e][x])
        })
        return
      }

      params = params.append(e, data[e])
    })

    this.http.get<ApiInterface<T>>(ApiService.uri + fn, {
      headers: new HttpHeaders({}),
      params,
    }).subscribe({
      next: (res: ApiInterface<T>) => {
        if (res?.isSuccess) {
          state.next(res.result)
          state.complete()
        } else {
          state.error(res?.error)
        }
      },
      error: err => state.error(err),
    })


    return state
      .pipe(
        timeout(ApiService.timeout),
        catchError(err => {
          if (err) return throwError(err)

          return throwError('unknownError')
        }),
      )
  }

  post$<T>(fn: string, data: any): Observable<T> {
    const state = new Subject<T>()
    let headers = new HttpHeaders()
    headers = headers.append('Content-Type', 'application/json')

    this.http.post<ApiInterface<T>>(ApiService.uri + fn, data, {
      headers,
    }).subscribe({
      next: (res: ApiInterface<T>) => {
        if (res?.isSuccess) {
          state.next(res.result)
          state.complete()
        } else {
          state.error(res?.error)
        }
      },
      error: err => state.error(err),
    })

    return state
      .pipe(
        timeout(ApiService.timeout),
        catchError(err => {
          if (err) return throwError(err)

          return throwError('unknownError')
        }),
      )
  }
}
