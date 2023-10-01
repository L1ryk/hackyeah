import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('src/app/modules/quiz/quiz.module').then(m => m.QuizModule),
  },
  {
    path: 'search',
    loadChildren: () => import('src/app/modules/search/search.module').then(m => m.SearchModule),
  },
  {
    path: '**',
    redirectTo: '/',
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
