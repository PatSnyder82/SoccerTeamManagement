import { Pipe, PipeTransform } from '@angular/core';
import { IAddress } from '../interfaces/address';

@Pipe({
  name: 'address'
})
export class AddressPipe implements PipeTransform {
  transform(address: IAddress): string {
    let value = '';

    if (address) {
      value += address?.addressLine1;
      value += address?.addressLine2 ? ', ' + address?.addressLine2 : '';
      value += address?.city ? ', ' + address?.city : '';
      value += address?.zipCode ? '  ' + address?.zipCode : '';
      value += address?.country?.text ? address?.country?.text : '';
    }

    return value;
  }
}
