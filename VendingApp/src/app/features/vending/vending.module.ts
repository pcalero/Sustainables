import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { MainVendingComponent } from './components/main-vending/main-vending.component';
import { FormsModule } from '@angular/forms';


const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: MainVendingComponent
  }
];


@NgModule({
  declarations: [MainVendingComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
  ]
})

export class VendingModule { }
