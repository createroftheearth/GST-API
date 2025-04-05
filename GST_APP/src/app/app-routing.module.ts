import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from './components/registration/registration.component';
import { PublicRegistrationComponent } from './components/public-registration/public-registration.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { authGuard } from './auth.guard';
import { AddEditGstr1Component } from './components/gstr1/save/add-edit-gstr1/add-edit-gstr1.component';
import { UploadGstr1Component } from './components/gstr1/upload-gstr1/upload-gstr1.component';
import { Gsrt1ListComponent } from './components/gstr1/gsrt1-list/gsrt1-list.component';

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
    path: 'gstr1/add',
    component: AddEditGstr1Component,
    canMatch: [authGuard], // Applying the new guard
    data: { title: 'GSTR1' },
  },
  {
    path: 'gstr1/list',
    component: Gsrt1ListComponent,
    canMatch: [authGuard], // Applying the new guard
    data: { title: 'GSTR1' },
  },
  {
    path: 'gstr1/upload',
    component: UploadGstr1Component,
    canMatch: [authGuard],
    data: { title: 'Upload GSTR1' },
  },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
