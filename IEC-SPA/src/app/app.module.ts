import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import { BsDropdownModule, CollapseModule, TabsModule, ModalModule, PaginationModule } from 'ngx-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav/nav.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { MovieDetailComponent } from './interests/movies/movie-detail/movie-detail.component';
import { appRoutes } from './routes';
import { MovieDetailResolver } from './_resolver/movie-detail.resolver';
import { MovieListResolver } from './_resolver/movie-list.resolver';
import { ArtistListResolver } from './_resolver/artist-list.resolver';
import { ArtistDetailComponent } from './interests/artists/artist-detail/artist-detail.component';
import { ArtistDetailResolver } from './_resolver/artist-detail.resolver';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthGuard } from './_guards/auth.guard';
import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { HasRoleDirective } from './_directives/hasRole.directive';
import { LogRegModalComponent } from './nav/logReg-modal/logReg-modal.component';
import { OpenAuthModalService } from './_services/openAuthModal.service';
import { ListComponent } from './interests/list/list.component';
import { CardComponent } from './interests/card/card.component';
import { GenericRestService } from './_services/generic-rest.service';
import { ProfileComponent } from './user/profile/profile.component';
import { UserManagementComponent } from './admin/user-management/user-management.component';
import { RolesModalComponent } from './admin/roles-modal/roles-modal.component';
import { HomeComponent } from './home/home.component';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AdminPanelComponent,
      AppComponent,
      ArtistDetailComponent,
      CardComponent,
      HasRoleDirective,
      HomeComponent,
      ListComponent,
      LogRegModalComponent,
      MovieDetailComponent,
      NavComponent,
      ProfileComponent,
      RolesModalComponent,
      UserManagementComponent,
      HomeComponent
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
      AuthGuard,
      AuthService,
      ErrorInterceptorProvider,
      GenericRestService,
      MovieDetailResolver,
      MovieListResolver,
      OpenAuthModalService
   ],
   entryComponents: [
      LogRegModalComponent,
      RolesModalComponent
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
