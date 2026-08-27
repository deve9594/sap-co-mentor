import { Component, Input } from '@angular/core';
import { CoMentorResponse } from './co-mentor-response.model';

@Component({
  selector: 'app-lesson',
  templateUrl: './lesson.component.html',
  styleUrls: ['./lesson.component.scss']
})
export class LessonComponent {
  @Input() lesson: CoMentorResponse | null = null;
}
