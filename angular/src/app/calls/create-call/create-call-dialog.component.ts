import { Component, Injector, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CreateTenantDto,
  TenantServiceProxy,
  CreateCallDto,
  CallServiceProxy
} from '@shared/service-proxies/service-proxies';


@Component({
  templateUrl: './create-call-dialog.component.html',
  styles: [
    `
      mat-form-field {
        width: 100%;
      }
      mat-checkbox {
        padding-bottom: 5px;
      }
    `
  ]
})
export class CreateCallDialogComponent extends AppComponentBase
 implements OnInit {

  saving = false;
  tenant: CreateCallDto = new CreateCallDto();

  constructor(
    injector: Injector,
    private _callService: CallServiceProxy,
    private _dialogRef: MatDialogRef<CreateCallDialogComponent>
  ) {
    super(injector);
  }

  ngOnInit(): void {
    //this.tenant.isActive = true;
  }

  save(): void {
    this.saving = true;

    this._callService
      .create(this.tenant)
      .pipe(
        finalize(() => {
          this.saving = false;
        })
      )
      .subscribe(() => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.close(true);
      });
  }

  close(result: any): void {
    this._dialogRef.close(result);
  }
  
}
