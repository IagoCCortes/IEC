import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BsDropdownModule, CollapseModule, TabsModule, ModalModule, PaginationModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav/nav.component';
import { MovieService } from './_services/movie.service';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { MovieCardComponent } from './interests/movies/movie-card/movie-card.component';
import { MovieDetailComponent } from './interests/movies/movie-detail/movie-detail.component';
import { appRoutes } from './routes';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { ArtistService } from './_services/artist.service';
import { ArtistCardComponent } from './interests/artists/artist-card/artist-card.component';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistDetailComponent } from './interests/artists/artist-detail/artist-detail.component';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { UserService } from './_services/user.service';
import { UserMovieService } from './_services/userMovie.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './_guards/auth.guard';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { LoginComponent } from './nav/login/login.component';
import { RegisterComponent } from './nav/register/register.component';
import { OpenAuthModalService } from './_services/openAuthModal.service';
import { ListComponent } from './interests/list/list.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AdminPanelComponent,
      AppComponent,
      ArtistCardComponent,
      ArtistDetailComponent,
      HasRoleDirective,
      ListComponent,
      LoginComponent,
      MovieCardComponent,
      MovieDetailComponent,
      NavComponent,
      RegisterComponent
   ],
   imports: [
      BrowserAnimationsModule,
      BrowserModule,
      BsDropdownModule.forRoot(),
      CollapseModule.forRoot(),
      FormsModule,
      HttpClientModule,
      JwtModule.forRoot({
         config: {
            tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      }),
      ModalModule.forRoot(),
      PaginationModule.forRoot(),
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes),
      TabsModule.forRoot()
   ],
   providers: [
      AlertifyService,
      ArtistDetailResolver,
      ArtistListResolver,
      ArtistService,
      AuthGuard,
      AuthService,
      ErrorInterceptorProvider,
      MovieDetailResolver,
      MovieListResolver,
      MovieService,
      OpenAuthModalService,
      UserMovieService,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
