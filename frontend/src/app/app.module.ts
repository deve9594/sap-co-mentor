import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { TopicSelectionComponent } from './topic-selection.component';
import { LessonComponent } from './lesson.component';

@NgModule({
  declarations: [
    AppComponent,
    TopicSelectionComponent,
    LessonComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
