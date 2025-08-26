import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CharacterRequest } from '../models/character-request';
import { CharacterResult } from '../models/character-result';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  private apiUrl = 'http://localhost:5030/api/character'; // update to match API

  constructor(private http: HttpClient) {}

  generateCharacter(request: CharacterRequest): Observable<CharacterResult> {
    return this.http.post<CharacterResult>(`${this.apiUrl}/generate`, request);
  }
}
