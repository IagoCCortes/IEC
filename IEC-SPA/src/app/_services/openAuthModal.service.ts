import { Injectable, EventEmitter } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { LoginComponent } from '../nav/login/login.component';

@Injectable({
  providedIn: 'root'
})
export class OpenAuthModalService {
  logged = new EventEmitter();
  bsModalRef: BsModalRef;

  constructor(private modalService: BsModalService) { }

  openModal() {
    const initialState = { choice: 'Login' };
    this.bsModalRef = this.modalService.show(LoginComponent, {initialState});
    this.bsModalRef.content.logged.subscribe(() => {
      this.logged.emit();
    });
  }

}
