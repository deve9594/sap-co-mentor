import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-topic-selection',
  templateUrl: './topic-selection.component.html',
  styleUrls: ['./topic-selection.component.scss']
})
export class TopicSelectionComponent {
  @Output() start = new EventEmitter<string>();

  topics = [
    'Cost Center',
    'Internal Order',
    'Profit Center',
    'Activity Type',
    'Cost Element',
    'Cost Object',
    'Assessment/Distribution'
  ];

  selected: string | null = null;

  select(topic: string) {
    this.selected = topic;
  }

  onStartLearning() {
    if (!this.selected) return;
    this.start.emit(this.selected);
  }
}
