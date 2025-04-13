import { Component, Inject } from '@angular/core';
import {MAT_DIALOG_DATA} from '@angular/material/dialog'
import { LogErroModel } from '../../models/logErro-model.module';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-log-erro-modal',
  standalone: true,
  imports: [MatDialogModule,MatButtonModule, CommonModule],
  templateUrl: './log-erro-modal.component.html',
  styleUrls: ['./log-erro-modal.component.css']
})

export class LogErroModalComponent {
    constructor( @Inject(MAT_DIALOG_DATA)public data:string){
    }
}
