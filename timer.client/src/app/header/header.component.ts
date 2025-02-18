import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: false,
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})

export class HeaderComponent {
isMenuActive=false



toggleMenu(){
  this.isMenuActive=!this.isMenuActive
}



@HostListener('document:click', ['$event'])
onDocumentClick(event: MouseEvent) {
  const target = event.target as HTMLElement;
  if (!target.closest('.navbar-menu') && !target.closest('.navbar-burger')) {
    this.isMenuActive = false;
  }
}
}
