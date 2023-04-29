// package: order
// file: src/app/protos/order.proto

import * as jspb from "google-protobuf";

export class OrderRequest extends jspb.Message {
  getProductid(): number;
  setProductid(value: number): void;

  getQuantity(): number;
  setQuantity(value: number): void;

  getUserid(): number;
  setUserid(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderRequest.AsObject;
  static toObject(includeInstance: boolean, msg: OrderRequest): OrderRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: OrderRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderRequest;
  static deserializeBinaryFromReader(message: OrderRequest, reader: jspb.BinaryReader): OrderRequest;
}

export namespace OrderRequest {
  export type AsObject = {
    productid: number,
    quantity: number,
    userid: number,
  }
}

export class OrderReply extends jspb.Message {
  getMessage(): string;
  setMessage(value: string): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): OrderReply.AsObject;
  static toObject(includeInstance: boolean, msg: OrderReply): OrderReply.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: OrderReply, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): OrderReply;
  static deserializeBinaryFromReader(message: OrderReply, reader: jspb.BinaryReader): OrderReply;
}

export namespace OrderReply {
  export type AsObject = {
    message: string,
  }
}

