import {Routes} from '@angular/router';
import { MovieListComponent } from './regular-user/movies/movie-list/movie-list.component';
import { MovieDetailComponent } from './regular-user/movies/movie-detail/movie-detail.component';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { MovieAdminListComponent } from './admin/movies-admin/movie-admin-list/movie-admin-list.component';
import { ArtistListComponent } from './regular-user/artists/artist-list/artist-list.component';
import { ArtistListResolver } from './_resolver/artist-list.resolver';

export const appRoutes: Routes = [
    {path: 'movies', component: MovieListComponent,
        resolve: {movies: MovieListResolver}},
    {path: 'movies/:id', component: MovieDetailComponent,
        resolve: {movie: MovieDetailResolver}},
    {path: 'artists', component: ArtistListComponent,
        resolve: {artists: ArtistListResolver}},
    {path: 'admin/movies', component: MovieAdminListComponent},
    {path: '**', redirectTo: 'movies', pathMatch: 'full'}
];
