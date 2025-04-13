import { Component, OnInit } from '@angular/core';
import {MatTableModule} from '@angular/material/table'
import { CuidadoService } from '../../services/cuidado-service.service';
import { CuidadoModel } from '../../models/cuidado-model.module';
import { MatButtonModule } from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import {MatDialog} from '@angular/material/dialog';
import { CuidadoDialogDeletarComponent } from '../cuidado-dialog-deletar/cuidado-dialog-deletar.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cuidado',
  standalone: true,
  imports: [MatTableModule, MatIconModule,MatButtonModule],
  templateUrl: './cuidado.component.html',
  styleUrl: './cuidado.component.css',

})
export class CuidadoComponent implements OnInit{
  dataSource!: CuidadoModel[]
  displayedColumns: string[] = ["Nome","Descrição","Frequencia","btnEditar","btnDeletar" ]
  constructor(private service:CuidadoService,
    private dialog: MatDialog,
    private router: Router){
  }
  ngOnInit(): void {
    console.log("ola")
    this.service.pesquisarCuidado().subscribe({
      next: (response) =>{
        this.dataSource = response;
      }
    })
  }
  EditarCuidado(cuidado:CuidadoModel){
    this.router.navigateByUrl("Cuidado/Editar",{state: {cuidado}})
  }
  DeletarCuidado(cuidado:CuidadoModel){
    this.dialog.open(CuidadoDialogDeletarComponent,{
      data:cuidado
    })
  }
}
