import { Routes } from '@angular/router';
import { CuidadoCadastroComponent } from './cuidado/components/cuidado-cadastro/cuidado-cadastro.component';
import { CuidadoComponent } from './cuidado/components/cuidadoTabela/cuidado.component';

export const routes: Routes = [
  {
    path:"Cuidado",
    component:CuidadoComponent
  },
  {
    path:"Cuidado/Cadastrar",
    component:CuidadoCadastroComponent
  },
  {
    path:"Cuidado/Editar",
    component:CuidadoCadastroComponent
  }

];
