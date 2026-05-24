import { Component ,OnInit,signal} from '@angular/core';
import {Tasks} from '../models/tasks.model';
import { TasksService } from '../tasks-service';
import { ActivatedRoute } from '@angular/router';
import { __param } from 'tslib';

@Component({
  selector: 'app-tasks-details',
  standalone: true,
  imports: [],
  templateUrl: './tasks-details.html',
  styleUrl: './tasks-details.css',
})
export class TasksDetails implements OnInit {
  tasks = signal<Tasks>(new Tasks());
  names="";

  constructor(
    public _tasksService:TasksService,
    private _route:ActivatedRoute){}

   ngOnInit(): void {
     this._route.params.subscribe((param) => {
      this.names=param['name'];
      this._tasksService.getTask(this.names).subscribe({
          next:(date) =>{
            this.tasks.set(date);
          },
          error:(err) =>{
            console.log(err);
          }
        });
     });
   } 
}