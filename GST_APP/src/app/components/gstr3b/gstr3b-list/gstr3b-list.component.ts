import { Component } from '@angular/core';

@Component({
  selector: 'app-gstr3b-list',
  templateUrl: './gstr3b-list.component.html',
  styleUrls: ['./gstr3b-list.component.css']
})
export class Gstr3bListComponent {
displayedColumns: string[] = ['nature', 'taxableValue', 'integratedTax', 'centralTax', 'stateTax', 'cess'];
dataSource1 = ELEMENT_DATA;
dataSource = ELEMENT_DATA1;

}
export interface SupplyData {
  nature: string;
  taxableValue: number | string;
  integratedTax: number | string;
  centralTax: number | string;
  stateTax: number | string;
  cess: number | string;
}

const ELEMENT_DATA: SupplyData[] = [
  {
    nature: 'Outward taxable supplies (other than zero rated, nil rated and exempted)',
    taxableValue: 0.00, integratedTax: 0.00, centralTax: 0.00, stateTax: 0.00, cess: 0.00
  },
  {
    nature: 'Outward taxable supplies (zero rated)',
    taxableValue: 0.00, integratedTax: 0.00, centralTax: 0.00, stateTax: 0.00, cess: 0.00
  },
  {
    nature: 'Other outward supplies (nil rated, exempted)',
    taxableValue: 0.00, integratedTax: '-', centralTax: '-', stateTax: '-', cess: '-'
  },
  {
    nature: 'Inward supplies (liable to reverse charge)',
    taxableValue: 0.00, integratedTax: 0.00, centralTax: 0.00, stateTax: 0.00, cess: 0.00
  },
  {
    nature: 'Non-GST outward supplies',
    taxableValue: 0.00, integratedTax: '-', centralTax: '-', stateTax: '-', cess: '-'
  }
];

export interface SupplyEntry {
  nature: string;
  taxableValue: string;
  integratedTax: string;
  centralTax: string;
  stateTax: string;
  cess: string;
}

export interface SupplyEntry1 {
  nature: string;
  taxableValue: string;
  integratedTax: string;
  centralTax: string;
  stateTax: string;
  cess: string;
}

const ELEMENT_DATA1: SupplyEntry1[] = [
    {
      nature: '(i) Taxable supplies on which electronic commerce operator pays tax u/s 9(5) [to be furnished by electronic commerce operator]',
      taxableValue: '0.00',
      integratedTax: '0.00',
      centralTax: '0.00',
      stateTax: '0.00',
      cess: '0.00'
    },
    {
      nature: '(ii) Taxable supplies made by registered person through electronic commerce operator, on which electronic commerce operator is required to pay tax u/s 9(5) [to be furnished by registered person making supplies through electronic commerce operator]',
      taxableValue: '0.00',
      integratedTax: '-',
      centralTax: '-',
      stateTax: '-',
      cess: '-'
    }
  ];
export class YourComponent {
  displayedColumns: string[] = ['nature', 'taxableValue', 'integratedTax', 'centralTax', 'stateTax', 'cess'];



}
export interface InterstateSupply {
  nature: string;
  taxableValue: string;
  integratedTax: string;
}

// export class YourComponent {
//   displayedColumns: string[] = ['nature', 'taxableValue', 'integratedTax'];

//   dataSource: InterstateSupply[] = [
//     {
//       nature: 'Supplies made to Unregistered Persons',
//       taxableValue: '0.00',
//       integratedTax: '0.00'
//     },
//     {
//       nature: 'Supplies made to Composition Taxable Persons',
//       taxableValue: '0.00',
//       integratedTax: '0.00'
//     },
//     {
//       nature: 'Supplies made to UIN holders',
//       taxableValue: '0.00',
//       integratedTax: '0.00'
//     }
//   ];
// }


