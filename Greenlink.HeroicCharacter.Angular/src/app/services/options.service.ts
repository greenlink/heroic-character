import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OptionsService {
  private apiUrl = 'http://localhost:5030/api/options'; // update to your API port

  constructor(private http: HttpClient) {}

  getSpecies(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/species`);
  }

  getClasses(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/classes`);
  }

  getGenders(): Observable<string[]> {
    return this.http.get<string[]>(`${this.apiUrl}/genders`);
  }
}
