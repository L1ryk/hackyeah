import { Component } from '@angular/core';
import { ApiService } from "../../services/api.service";
import { environment } from 'src/environment/environment';
import {FormBuilder, FormControl} from "@angular/forms";

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
  ) {}

  form = this.fb.group({
    endpoint: new FormControl(),
  })

  res: any

  apiGet() {
    this.apiService.get$(this.form.value.endpoint).subscribe({
      next: res => {
        this.res = res
      },
      error: err => {
        this.res = err
      }
    })
  }
}
