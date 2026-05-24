import { Component } from '@angular/core';
import { TasksList } from "../tasks-list/tasks-list";

@Component({
  selector: 'app-home',
  imports: [TasksList],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  public isShow: boolean = false
  showTasks() {
    this.isShow = true

  }
}
