import { Component } from '@angular/core';
import { ApiService } from "../../services/api.service";
import { environment } from 'src/environment/environment';
import { FormBuilder, FormControl } from "@angular/forms";

@Component({
  selector: 'app-test-api',
  templateUrl: './test-api.component.html',
  styleUrls: ['./test-api.component.sass']
})
export class TestApiComponent {
  readonly environment = environment

  constructor(
    private apiService: ApiService,
    private fb: FormBuilder,
  ) {
  }

  form = this.fb.group({
    endpoint: new FormControl(),
    method: new FormControl('get'),
    body: new FormControl(),
  })

  res: any

  apiGet() {
    if (this.form.value.method === 'get') {
      this.apiService.get$(this.form.value.endpoint).subscribe({
        next: res => {
          this.res = res
        },
        error: err => {
          this.res = err
        }
      })
    } else {
      this.apiService.post$(this.form.value.endpoint, JSON.parse(this.form.value.body)).subscribe({
        next: res => {
          this.res = res
        },
        error: err => {
          this.res = err
        }
      })
    }
  }
}
