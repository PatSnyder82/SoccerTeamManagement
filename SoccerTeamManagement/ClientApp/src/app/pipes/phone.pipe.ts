import { Pipe, PipeTransform } from '@angular/core';
import { PhoneType } from '../enum/phone-type';
import { IPhone } from '../interfaces/phone';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {
  transform(phone: IPhone): string {
    let value = 'None';

    if (phone) {
      value = '';
      value += phone?.phoneType ? PhoneType[+phone?.phoneType] : '';
      value += phone?.countryCode ? ': +' + phone?.countryCode?.trim() : '';
      value += phone?.areaCode ? ' (' + phone?.areaCode?.trim() + ')' : '';
      value += this._formatNumber(phone?.number.trim(), phone?.countryCode);
      value += phone?.extension ? ' (extension: ' + phone?.extension + ')' : '';
    }

    return value;
  }

  private _formatNumber(number: string, countryCode: string): string {
    if (!number) {
      return '';
    }
    else if (countryCode === "1" && number.length === 7) {
      return ' ' + number.substring(0, 2) + '-' + number.substring(3, 6);
    }
    else {
      return ' ' + number;
    }
  }
}
