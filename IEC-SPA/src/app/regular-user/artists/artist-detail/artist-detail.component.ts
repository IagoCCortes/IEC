import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistService } from 'src/app/_services/artist.service';
import { Artist } from 'src/app/_models/artist';
import { MovieArtist } from 'src/app/_models/movieArtist';

@Component({
  selector: 'app-artist-detail',
  templateUrl: './artist-detail.component.html',
  styleUrls: ['./artist-detail.component.css']
})
export class ArtistDetailComponent implements OnInit {
  artist: Artist;
  roles = {star: [], director: [], writer: []};

  constructor(
    private route: ActivatedRoute,
    private artistService: ArtistService
  ) {}

  ngOnInit() {
    this.route.data.subscribe(
      data => {
        this.artist = data.artist;
      },
      error => {
        console.log(error);
      }
    );

    this.splitMoviesByRoles(this.artist.movies);
  }

  splitMoviesByRoles(movieArtist: MovieArtist) {
    for (let i = 0; i < movieArtist.roleId.length; i++) {
      switch (movieArtist.roleId[i]) {
        case 1: // star
          this.roles.star.push(movieArtist.movieTitle[i]);
          break;
        case 2: // director
          this.roles.director.push(movieArtist.movieTitle[i]);
          break;
        case 3: // writer
          this.roles.writer.push(movieArtist.movieTitle[i]);
          break;
      }
    }
  }
}
