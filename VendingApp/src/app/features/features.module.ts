import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { VendingModule } from './vending/vending.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    VendingModule,
  ],
  exports:[
    VendingModule,
  ]
})
export class FeaturesModule { }
