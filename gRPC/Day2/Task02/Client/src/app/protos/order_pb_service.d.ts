// package: order
// file: src/app/protos/order.proto

import * as src_app_protos_order_pb from "./order_pb";
import {grpc} from "@improbable-eng/grpc-web";

type OrderPlaceOrder = {
  readonly methodName: string;
  readonly service: typeof Order;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_protos_order_pb.OrderRequest;
  readonly responseType: typeof src_app_protos_order_pb.OrderReply;
};

export class Order {
  static readonly serviceName: string;
  static readonly PlaceOrder: OrderPlaceOrder;
}

export type ServiceError = { message: string, code: number; metadata: grpc.Metadata }
export type Status = { details: string, code: number; metadata: grpc.Metadata }

interface UnaryResponse {
  cancel(): void;
}
interface ResponseStream<T> {
  cancel(): void;
  on(type: 'data', handler: (message: T) => void): ResponseStream<T>;
  on(type: 'end', handler: (status?: Status) => void): ResponseStream<T>;
  on(type: 'status', handler: (status: Status) => void): ResponseStream<T>;
}
interface RequestStream<T> {
  write(message: T): RequestStream<T>;
  end(): void;
  cancel(): void;
  on(type: 'end', handler: (status?: Status) => void): RequestStream<T>;
  on(type: 'status', handler: (status: Status) => void): RequestStream<T>;
}
interface BidirectionalStream<ReqT, ResT> {
  write(message: ReqT): BidirectionalStream<ReqT, ResT>;
  end(): void;
  cancel(): void;
  on(type: 'data', handler: (message: ResT) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'end', handler: (status?: Status) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'status', handler: (status: Status) => void): BidirectionalStream<ReqT, ResT>;
}

export class OrderClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  placeOrder(
    requestMessage: src_app_protos_order_pb.OrderRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_order_pb.OrderReply|null) => void
  ): UnaryResponse;
  placeOrder(
    requestMessage: src_app_protos_order_pb.OrderRequest,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_order_pb.OrderReply|null) => void
  ): UnaryResponse;
}

