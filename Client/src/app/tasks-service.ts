import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Tasks } from './models/tasks.model';

@Injectable({
  providedIn: 'root',
})
export class TasksService {
  // שימוש בכתובת בסיס אחידה
  private readonly basicUrl = 'https://localhost:7055/api/Tasks';

  constructor(private _http: HttpClient) {}

  // שליפת כל המשימות
  getTasks(): Observable<Tasks[]> {
    return this._http.get<Tasks[]>(this.basicUrl);
  }

  // שליפת משימה לפי שם - שימוש בגרשיים אלכסוניים (Backticks)
  getTask(name: string): Observable<Tasks> {
    return this._http.get<Tasks>(`${this.basicUrl}/getByName/${name}`);
  }

  // הוספת משימה
  addTasks(newtask: Tasks): Observable<Tasks> {
    return this._http.post<Tasks>(this.basicUrl, newtask);
  }

  // עדכון משימה - תיקון השרשור של ה-ID
  updateTasks(updatedTasks: Tasks): Observable<Tasks> {
    return this._http.put<Tasks>(`${this.basicUrl}/update/${updatedTasks.id}`, updatedTasks);
  }
}