import { Component, signal, OnInit } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Tasks } from '../models/tasks.model';
import { TasksService } from '../tasks-service';

@Component({
  selector: 'app-edit-tasks',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './edit-tasks.html',
  styleUrl: './edit-tasks.css'
})
export class EditTasks implements OnInit {
  tasksToEdit = signal<Tasks | null>(null);
  editForm!: FormGroup;

  constructor(
    public _tasksService: TasksService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    const name = this.route.snapshot.paramMap.get('names'); // וודאי שזה תואם ל-Route
    if (name) {
      this._tasksService.getTask(name).subscribe({
        next: (data: Tasks) => {
          this.tasksToEdit.set(data);
          this.editForm = new FormGroup({
            id: new FormControl(data.id),
            name: new FormControl(data.name),
            description: new FormControl(data.description),
            status: new FormControl(data.status),
            dueDate: new FormControl(data.dueDate),
            grade: new FormControl(data.grade)
          });
        }
      });
    }
  }

  submit() {
    if (this.editForm.valid) {
      this._tasksService.updateTasks(this.editForm.value).subscribe({
        next: () => this.router.navigate(['/tasks-list'])
      });
    }
  }

  goToList() {
    this.router.navigate(['/tasks-list']);
  }
}