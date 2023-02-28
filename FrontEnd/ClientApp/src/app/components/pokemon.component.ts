import {
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  AfterViewInit,
  ViewChildren,
  Renderer2,
  QueryList
} from '@angular/core'
import {PokemonsService} from '../services/pokemons.service'
import {PokemonMainImpl} from "../interfaces/pokemons.interface"
import {catchError, empty, of, switchMap, tap, throwError} from "rxjs"


@Component({
  selector: 'app-pokemon',
  templateUrl: './pokemon.component.html',
  styleUrls: ['./pokemon.component.css']
})
export class PokemonComponent implements OnInit, AfterViewInit {

  @ViewChildren('listItem') listItemsRef!: QueryList<ElementRef<HTMLLIElement>>
  @ViewChild('scrollContainer') scrollContainerRef!: ElementRef<HTMLUListElement>
  pkmnMain: PokemonMainImpl[] = []
  page = 1
  isLoading = false
  fav: string = "./assets/pokeball.svg"
  notFav: string = "./assets/pokeball_in.svg"
  favorite: boolean = false

  constructor(private renderer: Renderer2, private pokemonService: PokemonsService) {
  }

  ngOnInit() {
    this.loadPokemon()

    const scrollContainerNative = this.scrollContainerRef.nativeElement
    this.listItemsRef.forEach(itemRef => {
      const listItemNative = itemRef.nativeElement
      console.log(listItemNative.textContent)
    })

    this.scrollContainerRef.nativeElement.addEventListener('scroll', () => {
      if (scrollContainerNative.scrollTop + scrollContainerNative.clientHeight >= scrollContainerNative.scrollHeight) {
        this.loadPokemon()
      }
    })
  }

  ngAfterViewInit() {
    // if (this.scrollContainerRef === undefined) {
    //   console.error("The Scroll Container is not Initialized")
    //  } else {
    //    console.log("This is the scroll container: " + this.scrollContainerRef)
    //    this.renderer.listen(scrollContainerNative, 'scroll', (event) => {
    //      this.loadPokemon()
    //    })
    // }
    console.log(this.pkmnMain)
  }

  loadPokemon(): void {
    this.isLoading = true
    this.pokemonService.initPokemon(this.page).subscribe(data => {
      this.pkmnMain.push(...data)
      this.page++
      this.isLoading = false
    })
  }

  async updateFavorite(natDex: number) {
    try {
      const updatedPokemon = await this.pokemonService.updatePokemonFavorite(natDex).toPromise();
      const index = this.pkmnMain.findIndex(p => p.natDex === updatedPokemon.natDex);
      if (index !== -1) {
        this.pkmnMain[index] = updatedPokemon;
        this.pkmnMain[index].favorite = updatedPokemon.favorite;
      }
      console.log("Update successful:", updatedPokemon);
      let successMessage = "Favorite updated successfully.";
      console.log(successMessage);
    } catch (error) {
      console.error("Error updating favorite:", error);
      let errorMessage = "An error occurred while updating the favorite.";
      console.log(errorMessage);
    }
  }



// addScrollEventListener(scrollContainerNative: any): void {
  //   scrollContainerNative.addEventListener('scroll', () => {
  //     if (this.scrollContainer.nativeElement.scrollTop + this.scrollContainer.nativeElement.clientHeight >= this.scrollContainer.nativeElement.scrollHeight) {
  //       this.loadPokemon()
  //     }
  //   })
  // }
}
