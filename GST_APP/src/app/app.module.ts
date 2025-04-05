import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { RegistrationComponent } from './components/registration/registration.component';

import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { PublicRegistrationComponent } from './components/public-registration/public-registration.component';
import { NgOtpInputModule } from 'ng-otp-input';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { B2bComponent } from './components/gstr1/save/b2b/b2b.component';
import { B2baComponent } from './components/gstr1/save/b2ba/b2ba.component';
import { B2csComponent } from './components/gstr1/save/b2cs/b2cs.component';
import { B2csaComponent } from './components/gstr1/save/b2csa/b2csa.component';
import { CdnrComponent } from './components/gstr1/save/cdnr/cdnr.component';
import { CdnraComponent } from './components/gstr1/save/cdnra/cdnra.component';
import { CdnurComponent } from './components/gstr1/save/cdnur/cdnur.component';
import { CdnuraComponent } from './components/gstr1/save/cdnura/cdnura.component';
import { NilComponent } from './components/gstr1/save/nil/nil.component';
import { ExpComponent } from './components/gstr1/save/exp/exp.component';
import { ExpaComponent } from './components/gstr1/save/expa/expa.component';
import { AtComponent } from './components/gstr1/save/at/at.component';
import { AtaComponent } from './components/gstr1/save/ata/ata.component';
import { TxpdComponent } from './components/gstr1/save/txpd/txpd.component';
import { TxpdaComponent } from './components/gstr1/save/txpda/txpda.component';
import { SupecoComponent } from './components/gstr1/save/supeco/supeco.component';
import { SupecoaComponent } from './components/gstr1/save/supecoa/supecoa.component';
import { EcomComponent } from './components/gstr1/save/ecom/ecom.component';
import { EcomaComponent } from './components/gstr1/save/ecoma/ecoma.component';
import { HsnComponent } from './components/gstr1/save/hsn/hsn.component';
import { DocIssueComponent } from './components/gstr1/save/doc-issue/doc-issue.component';
import { AddEditGstr1Component } from './components/gstr1/save/add-edit-gstr1/add-edit-gstr1.component';
import { ItemB2bComponent } from './components/gstr1/save/b2b/item-b2b/item-b2b.component';
import { InvoiceB2bComponent } from './components/gstr1/save/b2b/invoice-b2b/invoice-b2b.component';
import { MaterialModules } from './material.module';
import { InvoiceB2baComponent } from './components/gstr1/save/b2ba/invoice-b2ba/invoice-b2ba.component';
import { ItemB2baComponent } from './components/gstr1/save/b2ba/item-b2ba/item-b2ba.component';
import { B2claComponent } from './components/gstr1/save/b2cla/b2cla.component';
import { B2clComponent } from './components/gstr1/save/b2cl/b2cl.component';
import { ItemB2clComponent } from './components/gstr1/save/b2cl/item-b2cl/item-b2cl.component';
import { InvoiceB2clComponent } from './components/gstr1/save/b2cl/invoice-b2cl/invoice-b2cl.component';
import { ItemB2claComponent } from './components/gstr1/save/b2cla/item-b2cla/item-b2cla.component';
import { InvoiceB2claComponent } from './components/gstr1/save/b2cla/invoice-b2cla/invoice-b2cla.component';
import { UploadGstr1Component } from './components/gstr1/upload-gstr1/upload-gstr1.component';
import { Gsrt1ListComponent } from './components/gstr1/gsrt1-list/gsrt1-list.component';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    PublicRegistrationComponent,
    LoginComponent,
    DashboardComponent,
    B2bComponent,
    B2baComponent,
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
    ItemB2bComponent,
    InvoiceB2bComponent,
    InvoiceB2baComponent,
    ItemB2baComponent,
    B2clComponent,
    InvoiceB2clComponent,
    ItemB2clComponent,
    InvoiceB2claComponent,
    ItemB2claComponent,
    UploadGstr1Component,
    Gsrt1ListComponent,
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule,
    NgOtpInputModule,
    ...MaterialModules,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
