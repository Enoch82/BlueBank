import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Cliente, Cuenta, CustomeResponse, Movimiento } from '../@core/const/interfaces';
import { ClienteService } from '../@core/service/cliente.service';
import { CuentaService } from '../@core/service/cuenta.service';

@Component({
  selector: 'app-usuario-detalles',
  templateUrl: './usuario-detalles.component.html',
  styleUrls: ['./usuario-detalles.component.scss']
})
export class UsuarioDetallesComponent implements OnInit {

  
  mostrarDetalles:boolean = false;
  mostrarCrearCuenta:boolean = false;
  mostrarConsignarCuenta:boolean = false;
  mostrarRetirarCuenta:boolean = false; 
  userInformation!: Cliente;
  detallesDisable:boolean =true;
  crearCuenteDisable:boolean =true;
  consignarCuentaDisable:boolean =true;
  retirarCuentaDisable:boolean =true;
  listaCuentas:any;
  crearCuentaForm: any;
  consignarCuentaForm:any;
  cuentaIdSelecionada!:number;
  listaMoviemientosCuenta!:any;
  retirarCuentaForm:any;
  cuentaSelectedForm =new FormControl()
  saldoInicial!:number;
  constructor(
    private clienteService: ClienteService,
    private cuentaService: CuentaService,
    private fb: FormBuilder

  ) { }

  ngOnInit(): void {
    let info:any = sessionStorage.getItem('usuario');
    this.userInformation = <Cliente> JSON.parse(info);
    this.listaCuentasClienteId(this.userInformation.clienteId!)
    this.crearCuentaForm = this.fb.group ({
      saldoInicial : [],
      clienteId :[this.userInformation.clienteId!]
    });
    
    this.consignarCuentaForm = this.fb.group({
      cuentaId:[],
      abonos:[]
    })
    this.retirarCuentaForm = this.fb.group({
      cuentaId:[],
      cargos:[]
    })
  }
  onChange(saldoCuenta:any){
    
    this.saldoInicial = saldoCuenta;
    

    this.saldoInicial = saldoCuenta.toString().split("-")[0];
    this.cuentaIdSelecionada = saldoCuenta.toString().split("-")[1].trim();
    
    this.listarMovimientoPorCuentaId(this.cuentaIdSelecionada);
  }

  consignacion(value:any){
    let movimiento = <Movimiento> value;
    movimiento.fechaOperacion = new Date();
    movimiento.cuentaId = Number(movimiento.cuentaId)
  
    
    this.cuentaService.consignarCuenta(movimiento)
      .subscribe(
        (response :CustomeResponse) =>{
          if(response.sucess === 1){
            this.listarMovimientoPorCuentaId(movimiento.cuentaId)
            this.listaCuentasClienteId(this.userInformation.clienteId!)
            this.consignarCuentaForm.reset();
          }
        });
  }

  retirar(value:any){
    let movimiento = <Movimiento> value;
    movimiento.fechaOperacion = new Date();
    movimiento.cuentaId = Number(movimiento.cuentaId)
  
    
    
    this.cuentaService.retirarCuenta(movimiento)
      .subscribe(
        (response :CustomeResponse) =>{
         if(response.sucess === 1){
          this.listarMovimientoPorCuentaId(movimiento.cuentaId)
          this.listaCuentasClienteId(this.userInformation.clienteId!)
          this.retirarCuentaForm.reset();
         }
        });
    
  }

  listarMovimientoPorCuentaId(cuentaId: number){
    this.cuentaService.ListaMovimientoPorCuentaId(cuentaId)
          .subscribe((response:CustomeResponse) =>{
            
            if(response.sucess === 1){
              this.listaMoviemientosCuenta = response.data;
            }
            
          });
  }

  listaCuentasClienteId(clienteId:number){
    this.clienteService.listarCuentasCliente(clienteId)
      .subscribe(
        (response:CustomeResponse) => {
          
          if(response.sucess === 1 && response.data !== null){
            this.habilitarBotone()
            this.listaCuentas = response.data;
           
          }
        
        });
  }
  crearCuentaFn(value:any){
    
    let cuenta = <Cuenta> value;
    
    cuenta.fechaCreacion = new Date();
    cuenta.productoId = 1;
    this.cuentaService.crearCuenta(cuenta)
      .subscribe((response:CustomeResponse) => {
        console.log(response)
    
      });
    this.crearCuentaForm.reset();
  }

  habilitarBotone(){
    this.detallesDisable = false;
    this.crearCuenteDisable = false;
    this.consignarCuentaDisable = false;
    this.retirarCuentaDisable = false;
  }
  mostrarDeatllesFn(){

    this.mostrarDetalles =!this.mostrarDetalles;
    
  }
  mostrarCrearCuentaFn(){

    this.mostrarCrearCuenta =!this.mostrarCrearCuenta;
    if(this.mostrarConsignarCuenta== true) {
      this.mostrarConsignarCuenta=false
    } 
    if(this.mostrarRetirarCuenta== true) {
      this.mostrarRetirarCuenta=false
    } 

  }

  mostrarConsignarCuentaFn(){
    this.mostrarConsignarCuenta =!this.mostrarConsignarCuenta;
    if(this.mostrarCrearCuenta== true) {
      this.mostrarCrearCuenta=false
    } 
    if(this.mostrarRetirarCuenta== true) {
      this.mostrarConsignarCuenta=false
    } 
  }
  mostrarRetirarCuentaFn(){
    this.mostrarRetirarCuenta =!this.mostrarRetirarCuenta;
    if(this.mostrarConsignarCuenta== true) {
      this.mostrarConsignarCuenta=false
    } 
    if(this.mostrarCrearCuenta== true) {
      this.mostrarCrearCuenta=false
    } 
  }

}
