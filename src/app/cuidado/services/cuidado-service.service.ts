import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { CuidadoModel } from "../models/cuidado-model.module";
import { Router } from "@angular/router";
import { LogErroService } from "../../shared/logErro/services/log-erro.service";
import {MatSnackBar} from '@angular/material/snack-bar'
import { Observable } from "rxjs";
@Injectable({
  providedIn: 'root'
})
export class CuidadoService{
private apiUrl = "http://localhost:9000/api/Cuidado"

  constructor(private http: HttpClient,
    private modalErro: LogErroService,
    private snackBar: MatSnackBar,
    private router:Router){}

  createCuidado(cuidado:CuidadoModel){
    console.log("Service")
    var urlFinal = this.apiUrl + "/CadastrarCuidado"
    this.http.post<CuidadoModel>(urlFinal,cuidado)
    .subscribe(
      {
        next: (e) => {
          this.snackBar.open("Sucesso no cadastro","Ok",{duration:5000});
        },
        error: (error) =>{
          this.modalErro.exibirErro(error)
        }
      }
    )
  }
  pesquisarCuidado(): Observable<CuidadoModel[]>{
    const urlFinal = this.apiUrl + "/BuscarCuidado";
    return this.http.get<CuidadoModel[]>(urlFinal);
  }
  removerCuidado(cuidado:CuidadoModel){
    const urlFinal = this.apiUrl + "?id=" + cuidado.id
    console.log(urlFinal)
    this.http.delete(urlFinal).subscribe({
      next: (response) =>{
        this.snackBar.open("Sucesso ao remover cuidado","Ok",{duration:5000});
        window.location.reload();
      },
      error: (error) =>{
        this.modalErro.exibirErro(error.error)
      }
    })
  }
  editarCuidado(cuidado:CuidadoModel){
    this.http.put(this.apiUrl,cuidado).subscribe({
      next:() =>{
        this.snackBar.open("Sucesso ao editar cuidado","Ok",{duration:5000});
      },
      error: (error)=> {
        this.modalErro.exibirErro(error.error);
      }
    })
  }

}
