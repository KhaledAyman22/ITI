import { Component } from '@angular/core';
import { Location, TrackingMessage } from './generated/src/app/protos/trackingService_pb';
import { Timestamp } from 'google-protobuf/google/protobuf/timestamp_pb';
import { grpc } from '@improbable-eng/grpc-web';
import { TrackingService } from './generated/src/app/protos/trackingService_pb_service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ITI.GrpcDemo.Web';

  sendMessage() {

    let msg = new TrackingMessage();
    msg.setDeviceid(111);
    msg.setSpeed(120);

    let location = new Location();
    location.setLat(30);
    location.setLong(31);
    msg.setLocation(location);

    msg.setStamp(new Timestamp());

    grpc.unary(TrackingService.SendMessage, {
      request: msg,
      host: "https://localhost:7105",
      onEnd: result => {
        const {status, message} = result;

        if (status == grpc.Code.OK && message) {
          console.log(message.toObject());
        }
      }
    })
  }

}
