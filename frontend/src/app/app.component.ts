import { Component } from '@angular/core';
import { CoMentorService } from './co-mentor.service';
import { CoMentorResponse } from './co-mentor-response.model';

@Component({
  selector: 'app-root',
  template: `
    <div class="toolbar" role="banner">
      <div style="display:flex;gap:12px;align-items:center">
        <div style="width:44px;height:44px;border-radius:6px;background:#fff;color:#0b5a88;display:flex;align-items:center;justify-content:center;font-weight:700">CO</div>
        <div>
          <div style="font-weight:700">SAP CO Mentor</div>
          <div style="font-size:12px;opacity:.9">Learn SAP Controlling using your FI knowledge</div>
        </div>
      </div>
    </div>

    <main style="max-width:1100px;margin:96px auto;padding:16px">
      <app-topic-selection (start)="onStart($event)" *ngIf="!lesson && !loading"></app-topic-selection>

      <div style="text-align:center;margin-top:2rem">
        <div *ngIf="loading" style="color:#0b5a88;">Loading lesson...</div>
        <div *ngIf="error" style="color:#b00020;">{{ error }}</div>
      </div>

      <app-lesson [lesson]="lesson" *ngIf="lesson"></app-lesson>

      <div style="margin:12px 0;text-align:center" *ngIf="lesson">
        <button (click)="back()" style="padding:.6rem 1rem;border-radius:8px;border:1px solid #ccc;background:#fff">Back to topics</button>
      </div>
    </main>
  `
})
export class AppComponent {
  lesson: CoMentorResponse | null = null;
  loading = false;
  error: string | null = null;

  constructor(private service: CoMentorService) {}

  onStart(topic: string) {
    if (this.loading) return;
    this.loading = true;
    this.error = null;
    this.lesson = null;

    this.service.learn(topic).subscribe({
      next: (res) => {
        this.lesson = res;
        this.loading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = err?.error || err?.message || 'Unable to load lesson.';
        this.loading = false;
      }
    });
  }

  back() {
    this.lesson = null;
    this.error = null;
  }
}
