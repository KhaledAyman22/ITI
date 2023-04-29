// package: 
// file: src/app/protos/trackingService.proto

import * as jspb from "google-protobuf";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";
import * as google_protobuf_timestamp_pb from "google-protobuf/google/protobuf/timestamp_pb";

export class TrackingMessage extends jspb.Message {
  getDeviceid(): number;
  setDeviceid(value: number): void;

  hasLocation(): boolean;
  clearLocation(): void;
  getLocation(): Location | undefined;
  setLocation(value?: Location): void;

  getSpeed(): number;
  setSpeed(value: number): void;

  hasStamp(): boolean;
  clearStamp(): void;
  getStamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setStamp(value?: google_protobuf_timestamp_pb.Timestamp): void;

  clearSensorsList(): void;
  getSensorsList(): Array<Sensor>;
  setSensorsList(value: Array<Sensor>): void;
  addSensors(value?: Sensor, index?: number): Sensor;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TrackingMessage.AsObject;
  static toObject(includeInstance: boolean, msg: TrackingMessage): TrackingMessage.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: TrackingMessage, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TrackingMessage;
  static deserializeBinaryFromReader(message: TrackingMessage, reader: jspb.BinaryReader): TrackingMessage;
}

export namespace TrackingMessage {
  export type AsObject = {
    deviceid: number,
    location?: Location.AsObject,
    speed: number,
    stamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
    sensorsList: Array<Sensor.AsObject>,
  }
}

export class Location extends jspb.Message {
  getLat(): number;
  setLat(value: number): void;

  getLong(): number;
  setLong(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Location.AsObject;
  static toObject(includeInstance: boolean, msg: Location): Location.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Location, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Location;
  static deserializeBinaryFromReader(message: Location, reader: jspb.BinaryReader): Location;
}

export namespace Location {
  export type AsObject = {
    lat: number,
    pb_long: number,
  }
}

export class Sensor extends jspb.Message {
  getName(): string;
  setName(value: string): void;

  getValue(): number;
  setValue(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): Sensor.AsObject;
  static toObject(includeInstance: boolean, msg: Sensor): Sensor.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: Sensor, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): Sensor;
  static deserializeBinaryFromReader(message: Sensor, reader: jspb.BinaryReader): Sensor;
}

export namespace Sensor {
  export type AsObject = {
    name: string,
    value: number,
  }
}

export class TrackingResponse extends jspb.Message {
  getSuccess(): boolean;
  setSuccess(value: boolean): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): TrackingResponse.AsObject;
  static toObject(includeInstance: boolean, msg: TrackingResponse): TrackingResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: TrackingResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): TrackingResponse;
  static deserializeBinaryFromReader(message: TrackingResponse, reader: jspb.BinaryReader): TrackingResponse;
}

export namespace TrackingResponse {
  export type AsObject = {
    success: boolean,
  }
}

export class PulseMessage extends jspb.Message {
  getDeviceid(): number;
  setDeviceid(value: number): void;

  getStatus(): DeviceStatusMap[keyof DeviceStatusMap];
  setStatus(value: DeviceStatusMap[keyof DeviceStatusMap]): void;

  hasStamp(): boolean;
  clearStamp(): void;
  getStamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setStamp(value?: google_protobuf_timestamp_pb.Timestamp): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): PulseMessage.AsObject;
  static toObject(includeInstance: boolean, msg: PulseMessage): PulseMessage.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: PulseMessage, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): PulseMessage;
  static deserializeBinaryFromReader(message: PulseMessage, reader: jspb.BinaryReader): PulseMessage;
}

export namespace PulseMessage {
  export type AsObject = {
    deviceid: number,
    status: DeviceStatusMap[keyof DeviceStatusMap],
    stamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
  }
}

export class SubscriptionRequest extends jspb.Message {
  getDeviceid(): number;
  setDeviceid(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): SubscriptionRequest.AsObject;
  static toObject(includeInstance: boolean, msg: SubscriptionRequest): SubscriptionRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: SubscriptionRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): SubscriptionRequest;
  static deserializeBinaryFromReader(message: SubscriptionRequest, reader: jspb.BinaryReader): SubscriptionRequest;
}

export namespace SubscriptionRequest {
  export type AsObject = {
    deviceid: number,
  }
}

export class NotificationMessage extends jspb.Message {
  getText(): string;
  setText(value: string): void;

  hasStamp(): boolean;
  clearStamp(): void;
  getStamp(): google_protobuf_timestamp_pb.Timestamp | undefined;
  setStamp(value?: google_protobuf_timestamp_pb.Timestamp): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): NotificationMessage.AsObject;
  static toObject(includeInstance: boolean, msg: NotificationMessage): NotificationMessage.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: NotificationMessage, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): NotificationMessage;
  static deserializeBinaryFromReader(message: NotificationMessage, reader: jspb.BinaryReader): NotificationMessage;
}

export namespace NotificationMessage {
  export type AsObject = {
    text: string,
    stamp?: google_protobuf_timestamp_pb.Timestamp.AsObject,
  }
}

export interface DeviceStatusMap {
  UNKNOWN: 0;
  WORKING: 1;
  FAILED: 2;
}

export const DeviceStatus: DeviceStatusMap;

