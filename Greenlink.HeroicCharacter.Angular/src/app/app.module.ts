import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CharacterGeneratorComponent } from './components/character-generator/character-generator.component';

@NgModule({
    declarations: [

    ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    CharacterGeneratorComponent,
    AppComponent
  ],
    providers: [],
    bootstrap: []
})
export class AppModule {}
