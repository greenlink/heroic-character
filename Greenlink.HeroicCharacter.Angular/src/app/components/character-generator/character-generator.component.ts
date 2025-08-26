import { Component, OnInit } from '@angular/core';
import { OptionsService } from '../../services/options.service';
import { CharacterService } from '../../services/character.service';
import { CharacterRequest } from '../../models/character-request';
import { CharacterResult } from '../../models/character-result';
import {FormsModule} from '@angular/forms';
import {NgOptimizedImage} from '@angular/common';
import {CharacterError} from '../../models/character-error';

@Component({
  selector: 'app-character-generator',
  templateUrl: './character-generator.component.html',
  imports: [
    FormsModule,
    NgOptimizedImage
  ],
  styleUrls: ['./character-generator.component.css']
})
export class CharacterGeneratorComponent implements OnInit {
  speciesOptions: string[] = [];
  classOptions: string[] = [];
  genderOptions: string[] = [];

  selectedSpecies: string = '';
  selectedClass: string = '';
  selectedGender: string = '';

  isLoading = false
  error: CharacterError | null = null;

  result: CharacterResult | null = null;

  constructor(
    private optionsService: OptionsService,
    private characterService: CharacterService
  ) {}

  ngOnInit(): void {
    this.optionsService.getSpecies().subscribe(data => this.speciesOptions = data);
    this.optionsService.getClasses().subscribe(data => this.classOptions = data);
    this.optionsService.getGenders().subscribe(data => this.genderOptions = data);
  }

  generateCharacter(): void {
    this.isLoading = true; // 👈 start loading
    this.result = null;

    const request: CharacterRequest = {
      species: this.selectedSpecies,
      className: this.selectedClass,
      gender: this.selectedGender
    };

    this.characterService.generateCharacter(request)
      .subscribe({
        next: (result: CharacterResult) => {
          this.result = result;
          this.isLoading = false;
        },
        error: (err) => {
          console.error('Error generating character:', err);
          this.error = {
            status: err.error?.status || 'Error',
            message: err.error?.message || 'Unknown error',
            detailedMessage: err.error?.detailedMessage || ''
          };
          this.isLoading = false;
        },
      });
  }
}
