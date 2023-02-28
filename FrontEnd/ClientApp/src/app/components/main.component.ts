import {Component} from '@angular/core';
import {BreakpointObserver} from '@angular/cdk/layout';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  pokemonList: any[] = [];
  loading: boolean = false;
  constructor(private breakpointObserver: BreakpointObserver, private http: HttpClient) {
  }
}
