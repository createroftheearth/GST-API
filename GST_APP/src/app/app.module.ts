import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { RegistrationComponent } from './components/registration/registration.component';
import { MatCard, MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { PublicRegistrationComponent } from './components/public-registration/public-registration.component';
import { MatGridListModule } from '@angular/material/grid-list';
import { NgOtpInputModule } from 'ng-otp-input';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { B2bComponent } from './components/gstr1/save/add-edit-gstr1/b2b/b2b.component';
import { B2baComponent } from './components/gstr1/save/add-edit-gstr1/b2ba/b2ba.component';
import { B2clComponent } from './components/gstr1/save/add-edit-gstr1/b2cl/b2cl.component';
import { B2claComponent } from './components/gstr1/save/add-edit-gstr1/b2cla/b2cla.component';
import { B2csComponent } from './components/gstr1/save/add-edit-gstr1/b2cs/b2cs.component';
import { B2csaComponent } from './components/gstr1/save/add-edit-gstr1/b2csa/b2csa.component';
import { CdnrComponent } from './components/gstr1/save/add-edit-gstr1/cdnr/cdnr.component';
import { CdnraComponent } from './components/gstr1/save/add-edit-gstr1/cdnra/cdnra.component';
import { CdnurComponent } from './components/gstr1/save/add-edit-gstr1/cdnur/cdnur.component';
import { CdnuraComponent } from './components/gstr1/save/add-edit-gstr1/cdnura/cdnura.component';
import { NilComponent } from './components/gstr1/save/add-edit-gstr1/nil/nil.component';
import { ExpComponent } from './components/gstr1/save/add-edit-gstr1/exp/exp.component';
import { ExpaComponent } from './components/gstr1/save/add-edit-gstr1/expa/expa.component';
import { AtComponent } from './components/gstr1/save/add-edit-gstr1/at/at.component';
import { AtaComponent } from './components/gstr1/save/add-edit-gstr1/ata/ata.component';
import { TxpdComponent } from './components/gstr1/save/add-edit-gstr1/txpd/txpd.component';
import { TxpdaComponent } from './components/gstr1/save/add-edit-gstr1/txpda/txpda.component';
import { SupecoComponent } from './components/gstr1/save/add-edit-gstr1/supeco/supeco.component';
import { SupecoaComponent } from './components/gstr1/save/add-edit-gstr1/supecoa/supecoa.component';
import { EcomComponent } from './components/gstr1/save/add-edit-gstr1/ecom/ecom.component';
import { EcomaComponent } from './components/gstr1/save/add-edit-gstr1/ecoma/ecoma.component';
import { HsnComponent } from './components/gstr1/save/add-edit-gstr1/hsn/hsn.component';
import { DocIssueComponent } from './components/gstr1/save/add-edit-gstr1/doc-issue/doc-issue.component';
import { AddEditGstr1Component } from './components/gstr1/save/add-edit-gstr1/add-edit-gstr1.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    PublicRegistrationComponent,
    LoginComponent,
    DashboardComponent,
    B2bComponent,
    B2baComponent,
    B2clComponent,
    B2claComponent,
    B2csComponent,
    B2csaComponent,
    CdnrComponent,
    CdnraComponent,
    CdnurComponent,
    CdnuraComponent,
    NilComponent,
    ExpComponent,
    ExpaComponent,
    AtComponent,
    AtaComponent,
    TxpdComponent,
    TxpdaComponent,
    SupecoComponent,
    SupecoaComponent,
    EcomComponent,
    EcomaComponent,
    HsnComponent,
    DocIssueComponent,
    AddEditGstr1Component,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatToolbarModule,
    MatSelectModule,
    MatStepperModule,
    MatButtonModule,
    HttpClientModule,
    MatSnackBarModule,
    MatIconModule,
    MatCardModule,
    MatGridListModule,
    NgOtpInputModule,
    MatDividerModule,
    MatSidenavModule,
    MatListModule,
    MatExpansionModule,
    MatMenuModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
