import { Component, OnInit } from '@angular/core';
import {Persona} from '../models/persona';
import {PersonaService} from 'src/app/services/persona.service';

@Component({
  selector: 'app-persona-consulta',
  templateUrl: './persona-consulta.component.html',
  styleUrls: ['./persona-consulta.component.css']
})
export class PersonaConsultaComponent implements OnInit {
  personas:Persona[]=[];
  personaTotal:number=0;
  searchText: string;
  constructor(private personaService: PersonaService) { }

  ngOnInit(): void {
    this.get();
    this.calcular();
  }
  get(){
    this.personaService.get().subscribe(result => {
      this.personas = result;
    });
  }
  calcular(){
    var sumador=0;
        this.personas.forEach(element => {
            sumador = sumador + element.valorApoyo;
      });
        this.personaTotal = sumador;
  }
  
}
