import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CoMentorResponse } from './co-mentor-response.model';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CoMentorService {
  // Use environment configuration for the API base URL
  private baseUrl = environment.apiBaseUrl;

  constructor(private http: HttpClient) {}

  learn(topic: string): Observable<CoMentorResponse> {
    return this.http.post<CoMentorResponse>(`${this.baseUrl}/learn`, { topic });
  }

  ask(question: string): Observable<CoMentorResponse> {
    return this.http.post<CoMentorResponse>(`${this.baseUrl}/ask`, { question });
  }
}
