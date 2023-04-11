import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'custom'
})
export class CustomPipe implements PipeTransform {

  transform(value: string, ...args: string[]): unknown {
    console.log(value, args)
    return value.split("").join(args[0]||"+");
  }

}
