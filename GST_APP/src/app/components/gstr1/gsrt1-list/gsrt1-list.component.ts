import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { GSTR1Service } from 'src/app/services/gstr1.service';

@Component({
  selector: 'app-gsrt1-list',
  templateUrl: './gsrt1-list.component.html',
  styleUrls: ['./gsrt1-list.component.css'],
})
export class Gsrt1ListComponent implements OnInit {
  monthNames = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  public gstr1Data: any[] = [];
  totalRecords = 0;
  page = 1;
  pageSize = 10;
  constructor(
    private gstr1Service: GSTR1Service,
    private snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.loadData();
  }

  loadData() {
    this.gstr1Service
      .getAllGSTR1(this.page, this.pageSize)
      .subscribe((response) => {
        this.gstr1Data = this.transformData(response.gstr1Data);
        this.totalRecords = response.totalRecords;
      });
  }

  transformData(gstr1Data: any[]) {
    const transformedData = [];
    for (const data of gstr1Data) {
      const fpDatas = data.financialPeriod.split('-');
      data.financialPeriod = `${this.monthNames[+fpDatas[1] - 1]} ${
        fpDatas[0]
      }`;

      const parsedJSONData = JSON.parse(data.gstr1SaveRequest);
      data.grossTurnOver = parsedJSONData.gt;
      transformedData.push(data);
    }
    return transformedData;
  }

  onPageChange(pageNumber: number) {
    this.page = pageNumber;
    this.loadData();
  }

  onSaveGSTR1(id: number) {
    this.gstr1Service.submit(id).subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }

  onProceedToFile(id: number) {
    this.gstr1Service.proceedToFile(id).subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }

  generateOTP() {
    this.gstr1Service.generateOTP().subscribe((data) => {
      if (data.isSuccess) {
        this.loadData();
      }
      this.snackBar.open(data.message, 'Close', {
        duration: 5000,
      });
    });
  }
}
