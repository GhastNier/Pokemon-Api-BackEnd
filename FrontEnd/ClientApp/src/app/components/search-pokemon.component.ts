import {Component} from '@angular/core';
import {ApiService} from "../api-service.service";

@Component({
  selector: 'app-search-pokemon',
  templateUrl: './search-pokemon.component.html',
  styleUrls: ['./search-pokemon.component.css']
})

export class SearchPokemonComponent {
  formFieldValue: string | undefined;
  pokemon: any;

  constructor(private apiService:ApiService) {}

  setValue(event: Event) {
    this.formFieldValue = (event.target as HTMLInputElement).value;
  }
  searchPkmnName(){
    if (this.formFieldValue != null) {
      this.apiService.getPokemon(this.formFieldValue).subscribe((data: any) => {
        this.pokemon = data
      });
    }
  }
}
