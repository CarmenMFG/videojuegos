import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { VideogameComponent } from './components/videogame/videogame.component';
import { VideogameDetailComponent } from './components/videogame-detail/videogame-detail.component';
import { AdminUsersComponent } from './components/admin-users/admin-users.component';
import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  {
    path: 'videogame/:id',
    component: VideogameComponent,
    canActivate: [AuthGuard],
  },
  { path: 'videogame-detail/:id', component: VideogameDetailComponent },
  {
    path: 'admin-users',
    component: AdminUsersComponent,
    canActivate: [AdminGuard],
  },
  { path: '**', pathMatch: 'full', redirectTo: 'home' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
