import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('src/app/modules/search/search.module').then(m => m.SearchModule),
  },
  {
    path: 'api',
    loadChildren: () => import('src/app/modules/test-api/test-api.module').then(m => m.TestApiModule),
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
export class AppRoutingModule { }
