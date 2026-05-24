import { Routes } from '@angular/router';
import { TasksList } from './tasks-list/tasks-list';
import { AddNewTasks } from './add-new-tasks/add-new-tasks';
import { HomePage } from './home-page/home-page';
import { NotFound } from './not-found/not-found';
import { TasksDetails } from './tasks-details/tasks-details';
import { EditTasks } from './edit-tasks/edit-tasks';
export const routes: Routes = [
     {  path:'',redirectTo: 'HomePage',pathMatch:'full'},
     {  path: 'tasks-list',component: TasksList},
     {  path: 'tasks-details/:name',component:  TasksDetails},
     {  path:'home-page',component:HomePage},
     {  path:'add-new-tasks',component:AddNewTasks},
     {  path:'edit-tasks/:name',component:EditTasks},
     {  path: '**',component:NotFound},
];

