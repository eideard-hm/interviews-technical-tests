import { ChangeDetectionStrategy, Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-management-layout',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './user-management-layout.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class UserManagementLayoutComponent {
  @Input() className = '';
  @Input() id = '';
  @Input() title = '';
}
