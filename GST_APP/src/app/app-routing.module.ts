import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './registration/registration.component';
import { PublicRegistrationComponent } from './public-registration/public-registration.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'register' },
  { path: 'register', component: RegistrationComponent },
  { path: 'public/register', component: PublicRegistrationComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
