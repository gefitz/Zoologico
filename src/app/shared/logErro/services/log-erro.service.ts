import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { LogErroModel } from '../models/logErro-model.module';
import { LogErroModalComponent } from '../components/log-erro-modal/log-erro-modal.component';

@Injectable({
  providedIn: 'root'
})
export class LogErroService {

  constructor(private dialog:MatDialog) { }

  exibirErro(erro:LogErroModel){
    this.dialog.open(LogErroModalComponent,{
      data: {erro}
    })
  }
  exibirErroPersonalido(error: string){

    this.dialog.open(LogErroModalComponent,{
      data: {mensagem: {error}}
    })
  }
}
