import { ChangeDetectionStrategy, Component, Inject, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import {
  MatDialogModule,
  MatDialogActions,
  MatDialogClose,
  MatDialogContent,
  MatDialogRef,
  MatDialogTitle,
  MatDialog,
  MAT_DIALOG_DATA,
} from '@angular/material/dialog';
import { CuidadoModel } from '../../models/cuidado-model.module';
import { CuidadoService } from '../../services/cuidado-service.service';

@Component({
  selector: 'app-cuidado-dialog-deletar',
  standalone: true,
  imports: [MatButtonModule,MatDialogModule],
  templateUrl: './cuidado-dialog-deletar.component.html',
  styleUrl: './cuidado-dialog-deletar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CuidadoDialogDeletarComponent {
      constructor( @Inject(MAT_DIALOG_DATA)public data:CuidadoModel, private service: CuidadoService){

      }
      DeletarCuidado(){
        this.service.removerCuidado(this.data)
      }
}
