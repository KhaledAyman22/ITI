import {Component} from '@angular/core';
import {Order} from "./protos/order_pb_service";
import {OrderRequest} from "./protos/order_pb";
import {grpc} from "@improbable-eng/grpc-web";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent
{
  title = 'Client';
  message = ''
  isError = false

  placeOrder(userId: HTMLInputElement, productId: HTMLInputElement, quantity: HTMLInputElement)
  {
    let orderRequest = new OrderRequest();
    orderRequest.setUserid(parseInt(userId.value))
    orderRequest.setProductid(parseInt(productId.value))
    orderRequest.setQuantity(parseInt(quantity.value))

    grpc.unary(Order.PlaceOrder, {
      request: orderRequest,
      host: "https://localhost:7293",
      onEnd: result => {
        const {status, message} = result

        if(status == grpc.Code.OK && message){
          this.message = message.toString()

          setTimeout(()=> this.message = '', 3000);
        }
      }
    })
  }
}
