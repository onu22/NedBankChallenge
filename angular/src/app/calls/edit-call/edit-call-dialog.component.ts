import { Component, Injector, OnInit, Inject, Optional } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CallDto,
  CallServiceProxy
} from '@shared/service-proxies/service-proxies';


@Component({
  templateUrl: './edit-call-dialog.component.html',
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
export class EditCallDialogComponent extends AppComponentBase 
implements OnInit {
  saving = false;
  call: CallDto = new CallDto();

  constructor(
    injector: Injector,
    private _callService: CallServiceProxy,
    private _dialogRef: MatDialogRef<EditCallDialogComponent>,
    @Optional() @Inject(MAT_DIALOG_DATA) private _id: number
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this._callService.get(this._id).subscribe((result: CallDto) => {
      this.call = result;
    });
  }

  save(): void {
    this.saving = true;

    this._callService
      .update(this.call)
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
