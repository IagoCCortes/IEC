import { Component, OnInit, Input } from '@angular/core';
import { ArtistList } from 'src/app/_models/artist-list';

@Component({
  selector: 'app-artist-card',
  templateUrl: './artist-card.component.html',
  styleUrls: ['./artist-card.component.css']
})
export class ArtistCardComponent implements OnInit {
  @Input() artist: ArtistList;

  constructor() { }

  ngOnInit() {
  }

}
