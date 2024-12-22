import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { PublicRegistrationComponent } from './components/public-registration/public-registration.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { authGuard } from './auth.guard';
import { Dashboard2Component } from './components/dashboard2/dashboard2.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'public/register', component: PublicRegistrationComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canMatch: [authGuard], // Applying the new guard
  },
  {
    path: 'dashboard2',
    component: Dashboard2Component,
    canMatch: [authGuard], // Applying the new guard
  },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
