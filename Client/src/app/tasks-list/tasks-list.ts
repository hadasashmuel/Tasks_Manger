import { Component, signal } from '@angular/core';
import {Tasks} from '../models/tasks.model';
import { eGradeLevelTesk } from '../models/tasks.model';
import { TasksService } from '../tasks-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-tasks-list',
  standalone: true,
  imports: [],
  templateUrl: './tasks-list.html',
  styleUrls: ['./tasks-list.css'],
})
export class TasksList {

  
  selectedTasks = signal<Tasks | null>(null);
  tasks= signal<Tasks[] | null > (null);

  constructor(
    public _tasksService:TasksService,
    private _router:Router,){
    this._tasksService.getTasks().subscribe({
      next:(data)=> this.tasks.set(data),
      error:(err) => console.error('Error fetching tasks:',err),
      
      });
  }
  navigateNewTasks() {
   this._router.navigate(['add-new-tasks']);
  }

  navigateDetails(t:Tasks){
    this._router.navigate(['tasks-details',t.name])
  }

  navigateEdits(t:Tasks){
        this._router.navigate(['edit-tasks',t.name])

  }
}
