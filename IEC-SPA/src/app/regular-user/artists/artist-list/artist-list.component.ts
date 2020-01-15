import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArtistList } from 'src/app/_models/artist-list';
import { Pagination, PaginatedResult } from 'src/app/_models/pagination';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ArtistService } from 'src/app/_services/artist.service';

@Component({
  selector: 'app-artist-list',
  templateUrl: './artist-list.component.html',
  styleUrls: ['./artist-list.component.css']
})
export class ArtistListComponent implements OnInit {
  artists: ArtistList[];
  movieParams: any = {};
  pagination: Pagination;
  maxSize = 5;

  constructor(private artistService: ArtistService, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.artists = data.artists.result;
      this.pagination = data.artists.pagination;
    });
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadArtists();
  }

  loadArtists() {
    this.artistService.getArtists(this.pagination.currentPage, this.pagination.itemsPerPage, this.movieParams).
      subscribe((res: PaginatedResult<ArtistList[]>) => {
      this.artists = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }
}
