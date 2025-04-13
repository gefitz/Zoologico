import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule,FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CuidadoModel } from '../../models/cuidado-model.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { CuidadoService } from '../../services/cuidado-service.service';
import { Router,RouterLink } from '@angular/router';
@Component({
  selector: 'app-cuidado-cadastro',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    RouterLink
  ],
  templateUrl: './cuidado-cadastro.component.html',
  styleUrl: './cuidado-cadastro.component.css'
})
export class CuidadoCadastroComponent implements OnInit {
  form!: FormGroup;
  constructor(private fb: FormBuilder, private service: CuidadoService, private router: Router){
    var nav = this.router.getCurrentNavigation();
    var cuidado: CuidadoModel = nav?.extras.state?.["cuidado"]
    if(cuidado){
      this.form = this.fb.group({
        id:[cuidado.id, Validators.required],
        nomeCuidado: [cuidado.nomeCuidado, Validators.required],
        descricao: [cuidado.descricao],
        frequencia: [cuidado.frequencia, Validators.required]
      })
    }else{
      this.form = this.fb.group({
        id: [0,Validators.required],
        nomeCuidado: ['', Validators.required],
        descricao: [''],
        frequencia: ['', Validators.required]
      })
    }
  }
  ngOnInit(): void {

  }
  onSubmit(){
    if(this.form.valid){
      const novoCuidado: CuidadoModel = this.form.value;
      if(novoCuidado.id && novoCuidado.id != 0)
        this.service.editarCuidado(novoCuidado);
      else{
        this.service.createCuidado(novoCuidado);
      }
    }
  }
}
