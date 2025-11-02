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
import { GenerateOtpComponent } from './components/generate-otp/generate-otp.component';
import { ViewSummaryComponent } from './components/gstr1/view-summary/view-summary.component';
import { ViewListItemsComponent } from './components/gstr1/view-list-items/view-list-items.component';
import { Gstr3bListComponent } from './components/gstr3b/gstr3b-list/gstr3b-list.component';
import { Gstr3bComponent } from './components/gstr3b/gstr3b/gstr3b.component';
import { Gstr9aComponent } from './components/gstr9/gstr9a/gstr9a.component';
import { Gstr9cComponent } from './components/gstr9/gstr9c/gstr9c.component';
import { NilReturnComponent } from './components/gstr1/nil-return/nil-return.component';
import { Gstr3bNilReturnComponent } from './components/gstr3b/gstr3b-nil-return/gstr3b-nil-return.component';
const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'generate-otp', component: GenerateOtpComponent },
  { path: 'register', component: RegistrationComponent },
  { path: 'public/register', component: PublicRegistrationComponent },
  {
    path: 'dashboard',
    component: DashboardComponent,
    canMatch: [authGuard], // Applying the new guard
    data: { title: 'Dashboard' },
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
  {
    path: 'gstr1/viewSummary',
    component: ViewSummaryComponent,
    canMatch: [authGuard],
    data: { title: 'View Summary' },
  },
  {
    path: 'gstr1/viewItemList',
    component: ViewListItemsComponent,
    canMatch: [authGuard],
    data: { title: 'View Item Details' },
  },
  {
    path: 'gstr1/nilreturn',
    component: NilReturnComponent,
    canMatch: [authGuard],
    data: { title: 'Nil Return' },
  },
  {
    path: 'gstr3b/gstr3b',
    component: Gstr3bComponent,
    canMatch: [authGuard],
    data: { title: 'GSTR 3B' },
  },
  {
    path: 'gstr3b/gstr3b-nil-return',
    component: Gstr3bNilReturnComponent,
    canMatch: [authGuard],
    data: { title: 'GSTR 3B - NIL Return' },
  },
  {
    path: 'gstr9/gstr9a',
    component: Gstr9aComponent,
    canMatch: [authGuard],
    data: { title: 'GSTR 9A' },
  },
  {
    path: 'gstr9/gstr9c',
    component: Gstr9cComponent,
    canMatch: [authGuard],
    data: { title: 'GSTR 9C' },
  },
  { path: '**', redirectTo: 'login' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
