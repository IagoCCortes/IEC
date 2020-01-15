import { Injectable, EventEmitter } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class OpenAuthModalService {
  openModal = new EventEmitter();

  constructor() { }

}
