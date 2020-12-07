import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-group-buttons',
  templateUrl: './group-buttons.component.html',
  styleUrls: ['./group-buttons.component.css'],
})
export class GroupButtonsComponent implements OnInit {
  @Input() idGame: string;
  @Input() details = false;
  @Input() adminUsers = false;
  @Output() actionType = new EventEmitter();
  constructor(private router: Router) {}

  ngOnInit(): void {}
  goHome(): void {
    this.router.navigateByUrl('/home');
  }
  delete(): void {
    this.actionType.emit('delete');
  }
  save(): void {
    this.actionType.emit('save');
  }
  edit(): void {
    this.actionType.emit('edit');
  }
}
