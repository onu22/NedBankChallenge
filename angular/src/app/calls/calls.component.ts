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

  tenants: CallDto[] = [];

  constructor(
      injector: Injector,
      private _tenantService: CallServiceProxy,
      private _dialog: MatDialog
  ) {
      super(injector);
  }

  list(
    request: PagedCallsRequestDto,
    pageNumber: number,
    finishedCallback: Function
): void {
    this._tenantService
        .getAll(request.maxResultCount,request.skipCount)
        .pipe(
            finalize(() => {
                finishedCallback();
            })
        )
        .subscribe((result: PagedResultDtoOfCallDto) => {
            this.tenants = result.items;
            this.showPaging(result, pageNumber);
        });
} 


delete(tenant: CallDto): void {
  abp.message.confirm(
      this.l('TenantDeleteWarningMessage', tenant.code),
      (result: boolean) => {
          if (result) {
              this._tenantService
                  .delete(tenant.id)
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


createTenant(): void {
  this.showCreateOrEditCallDialog();
}

editTenant(tenant: CallDto): void {
  this.showCreateOrEditCallDialog(tenant.id);
}

showCreateOrEditCallDialog(id?: number): void {
  let createOrEditTenantDialog;
  if (id === undefined || id <= 0) {
      createOrEditTenantDialog = this._dialog.open(CreateCallDialogComponent);
  } else {
      createOrEditTenantDialog = this._dialog.open(EditCallDialogComponent, {
          data: id
      });
  }

  createOrEditTenantDialog.afterClosed().subscribe(result => {
      if (result) {
          this.refresh();
      }
  });
}


}
