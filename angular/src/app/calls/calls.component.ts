import { Component, Injector } from '@angular/core';
import { MatDialog } from '@angular/material';
import { finalize } from 'rxjs/operators';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {
    PagedListingComponentBase,
    PagedRequestDto
} from 'shared/paged-listing-component-base';
import {
    CallServiceProxy,
    CallDto,
    PagedResultDtoOfCallDto
} from '@shared/service-proxies/service-proxies';
import { CreateCallDialogComponent } from './create-call/create-call-dialog.component';
import { EditCallDialogComponent } from './edit-call/edit-call-dialog.component';


class PagedCallsRequestDto extends PagedRequestDto {
  keyword: string;
  isActive: boolean | null;
}

@Component({
  selector: 'app-calls',
  templateUrl: './calls.component.html',
  styleUrls: ['./calls.component.css']
})
export class CallsComponent extends PagedListingComponentBase<CallDto> {

  calls: CallDto[] = [];

  constructor(
      injector: Injector,
      private _callService: CallServiceProxy,
      private _dialog: MatDialog
  ) {
      super(injector);
  }

  list(
    request: PagedCallsRequestDto,
    pageNumber: number,
    finishedCallback: Function
): void {
    this._callService
        .getAll(request.maxResultCount,request.skipCount)
        .pipe(
            finalize(() => {
                finishedCallback();
            })
        )
        .subscribe((result: PagedResultDtoOfCallDto) => {
            this.calls = result.items;
            this.showPaging(result, pageNumber);
        });
} 


delete(call: CallDto): void {
  abp.message.confirm(
      this.l('TenantDeleteWarningMessage', call.code),
      (result: boolean) => {
          if (result) {
              this._callService
                  .delete(call.id)
                  .pipe(
                      finalize(() => {
                          abp.notify.success(this.l('SuccessfullyDeleted'));
                          this.refresh();
                      })
                  )
                  .subscribe(() => { });
          }
      }
  );
}


createCall(): void {
  this.showCreateOrEditCallDialog();
}

editCall(call: CallDto): void {
  this.showCreateOrEditCallDialog(call.id);
}

showCreateOrEditCallDialog(id?: number): void {
  let createOrEditCallDialog;
  if (id === undefined || id <= 0) {
      createOrEditCallDialog = this._dialog.open(CreateCallDialogComponent);
  } else {
      createOrEditCallDialog = this._dialog.open(EditCallDialogComponent, {
          data: id
      });
  }

  createOrEditCallDialog.afterClosed().subscribe(result => {
      if (result) {
          this.refresh();
      }
  });
}


}
