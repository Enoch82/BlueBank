import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClienteService } from '../@core/service/cliente.service';
import { Cliente, CustomeResponse, loginUser } from '../@core/const/interfaces'
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  regex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";
  loginForm: any;
  returnUrl: string = '';
  showMessage:boolean = false;
  message:string = '';

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private fb:FormBuilder,
    private clienteService: ClienteService
    
  ) { }

  ngOnInit(): void {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/detallesdeUsuario';
    this.loginForm = this.fb.group ({
      clienteEmail : ['', Validators.required],
      clientePassword : ['', Validators.required]
    })
  }

  loginIn(formValue: any){
    
    let clienteLogin : loginUser = {
      email : formValue.clienteEmail,
      password : formValue.clientePassword,
      
    }
 
    this.clienteService.loginIn(clienteLogin)
      .subscribe(
        (response : CustomeResponse) => {
          
          if(response.sucess === 1){
            let cliente = <Cliente> response.data;
            let nombre:string = cliente.nombre!;
            let clienteId = cliente.clienteId!;
            
            sessionStorage.setItem('usuario', JSON.stringify(cliente));
            
            this.router.navigate([this.returnUrl]);
          }else{
            this.loginForm.reset();
            this.showMessage = true;
            this.message = response.message;
          }
        });
  }

}
