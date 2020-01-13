import {Routes} from '@angular/router';
import { MovieListComponent } from './regular-user/movies/movie-list/movie-list.component';
import { MovieDetailComponent } from './regular-user/movies/movie-detail/movie-detail.component';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { MovieAdminListComponent } from './admin/movies-admin/movie-admin-list/movie-admin-list.component';
import { ArtistListComponent } from './regular-user/artists/artist-list/artist-list.component';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { ArtistDetailComponent } from './regular-user/artists/artist-detail/artist-detail.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';

export const appRoutes: Routes = [
    { path: '', component: MovieListComponent,
        resolve: {movies: MovieListResolver}},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'admin', component: AdminPanelComponent, data: { roles: ['Admin']}},
            {path: 'admin/movies', component: MovieAdminListComponent, data: { roles: ['Admin']}}
        ]
    },
    {path: 'movies', component: MovieListComponent,
        resolve: {movies: MovieListResolver}},
    {path: 'movies/:id', component: MovieDetailComponent,
        resolve: {movie: MovieDetailResolver}},
    {path: 'artists', component: ArtistListComponent,
        resolve: {artists: ArtistListResolver}},
    {path: 'artists/:id', component: ArtistDetailComponent,
        resolve: {artist: ArtistDetailResolver}},
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
