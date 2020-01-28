import {Routes} from '@angular/router';
import { MovieDetailComponent } from './interests/movies/movie-detail/movie-detail.component';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { ArtistDetailComponent } from './interests/artists/artist-detail/artist-detail.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { ListComponent } from './interests/list/list.component';
import { ProfileComponent } from './user/profile/profile.component';
import { HomeComponent } from './home/home.component';
import { SearchComponent } from './search/search.component';
import { SearchResolver } from './_resolver/search.resolver';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'admin', component: AdminPanelComponent, data: { roles: ['Admin']}}
        ]
    },
    {path: 'movies', component: ListComponent,
        resolve: {entities: MovieListResolver}},
    {path: 'search/:searchStr', component: SearchComponent,
        resolve: {results: SearchResolver}},
    {path: 'movies/:id', component: MovieDetailComponent,
        resolve: {movie: MovieDetailResolver}},
    {path: 'artists', component: ListComponent,
        resolve: {entities: ArtistListResolver}},
    {path: 'artists/:id', component: ArtistDetailComponent,
        resolve: {artist: ArtistDetailResolver}},
    {path: 'users/:id', component: ProfileComponent},
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
