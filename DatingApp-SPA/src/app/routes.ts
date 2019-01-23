import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberListResolver } from './_resolvers/members-list.resolver';
import { MemberDetailResolver } from './_resolvers/members-detail.resolver';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberEditResolver } from './_resolvers/members-edit.resolver';
import { PreventUnSavedChanges } from './_guards/prevent-unsaved-changes.guard';

export const appRoutes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'members', component: MemberListComponent, resolve: {users: MemberListResolver}},
            { path: 'members/:id', component: MemberDetailComponent, resolve: {user: MemberDetailResolver}},
            { path: 'member/edit', component: MemberEditComponent, resolve: {user: MemberEditResolver}
            , canDeactivate: [PreventUnSavedChanges]},
            { path: 'messages', component: MessagesComponent},
            { path: 'list', component: ListsComponent}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'},
];
