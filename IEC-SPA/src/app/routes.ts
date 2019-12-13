import {Routes} from '@angular/router';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { MovieDetailComponent } from './movies/movie-detail/movie-detail.component';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';

export const appRoutes: Routes = [
    {path: 'movies', component: MovieListComponent,
        resolve: {movies: MovieListResolver}},
    {path: 'movies/:id', component: MovieDetailComponent,
        resolve: {movie: MovieDetailResolver}},
    {path: '**', redirectTo: 'movies', pathMatch: 'full'}
];
