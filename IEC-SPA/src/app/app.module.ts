import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BsDropdownModule, CollapseModule, TabsModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MovieListComponent } from './regular-user/movies/movie-list/movie-list.component';
import { NavComponent } from './regular-user/nav/nav.component';
import { MovieService } from './_services/movie.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { MovieCardComponent } from './regular-user/movies/movie-card/movie-card.component';
import { MovieDetailComponent } from './regular-user/movies/movie-detail/movie-detail.component';
import { appRoutes } from './routes';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { NavAdminComponent } from './admin/nav-admin/nav-admin.component';
import { MovieAdminListComponent } from './admin/movies-admin/movie-admin-list/movie-admin-list.component';

@NgModule({
   declarations: [
      AppComponent,
      MovieListComponent,
      NavComponent,
      MovieCardComponent,
      MovieDetailComponent,
      NavAdminComponent,
      MovieAdminListComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      BsDropdownModule.forRoot(),
      CollapseModule.forRoot(),
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes),
      TabsModule.forRoot()
   ],
   providers: [
    MovieService,
    ErrorInterceptorProvider,
    MovieDetailResolver,
    MovieListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
