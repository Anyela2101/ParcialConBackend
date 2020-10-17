import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Persona } from '../ApoyoEconomico/models/persona';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { FindValueSubscriber } from 'rxjs/internal/operators/find';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {
  baseUrl: string;
  constructor(
      private http: HttpClient,
      @Inject('BASE_URL') baseUrl: string,
      private handleErrorService: HandleHttpErrorService)
  {
      this.baseUrl = baseUrl;
  }

  get(): Observable<Persona[]> {
    return this.http.get<Persona[]>(this.baseUrl + 'api/Persona')
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Persona[]>('Consulta Persona', null))
        );
  }

  ValidarPersona(persona:Persona, personas:Persona[]):boolean{
    for(var i in personas){
      if(persona.identificacion==personas[i].identificacion){return false;}
    }
    return true;
  }

  ValidarValor(persona:Persona, personas:Persona[]):boolean{
    var sumador=persona.valorApoyo;
        personas.forEach(element => {
            sumador = sumador + element.valorApoyo;
      });
      if(sumador>600000000){
        return false;
      }else{
        return true;
      }
  }

  post(persona: Persona): Observable<Persona> {
    return this.http.post<Persona>(this.baseUrl + 'api/Persona', persona)
        .pipe(
            tap(_ => this.handleErrorService.log('datos enviados')),
            catchError(this.handleErrorService.handleError<Persona>('Registrar Persona', null))
        );
  }


 /* ValidarDato(persona:Persona):boolean{
    let personas:Persona[]=[];
    if(this.get()!=null){
      personas=this.get();
    }
    if(this.ValidarValor(persona,personas)){
      personas.push(persona);
      console.log(persona);
      localStorage.setItem('informacion', JSON.stringify(personas));
      return true;
    }
    return false;
  }*/
}
