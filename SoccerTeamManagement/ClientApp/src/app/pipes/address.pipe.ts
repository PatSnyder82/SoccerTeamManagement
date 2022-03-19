import { Pipe, PipeTransform } from '@angular/core';
import { IAddress } from '../interfaces/address';

@Pipe({
  name: 'address'
})
export class AddressPipe implements PipeTransform {
  transform(address: IAddress, isSingleLine: boolean = false): string {
    let value = 'None';

    if (address) {
      value = '';
      if (isSingleLine) {
        value += address?.addressLine1;
        value += address?.addressLine2 ? ', ' + address?.addressLine2 : '';
        value += address?.city ? ', ' + address?.city : '';
        value += address?.state ? ', ' + address?.state?.alpha2Code : '';
        value += address?.zipCode ? '  ' + address?.zipCode : '';
        value += address?.country?.text ? '  ' + address?.country?.text : '';
      }
      else {
        value += address?.addressLine1;
        value += address?.addressLine2 ? ',\n' + address?.addressLine2 : '';
        value += address?.city ? ',\n' + address?.city : '';
        value += address?.state?.alpha2Code ? ', ' + address?.state?.alpha2Code : '';
        value += address?.zipCode ? '  ' + address?.zipCode : '';
        value += address?.country?.text ? '\n' + address?.country?.text : '';
      }
    }

    return value;
  }
}
