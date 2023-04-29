// package: 
// file: src/app/protos/trackingService.proto

import * as src_app_protos_trackingService_pb from "../../../src/app/protos/trackingService_pb";
import * as google_protobuf_empty_pb from "google-protobuf/google/protobuf/empty_pb";
import {grpc} from "@improbable-eng/grpc-web";

type TrackingServiceSendMessage = {
  readonly methodName: string;
  readonly service: typeof TrackingService;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof src_app_protos_trackingService_pb.TrackingMessage;
  readonly responseType: typeof src_app_protos_trackingService_pb.TrackingResponse;
};

type TrackingServiceKeepAlive = {
  readonly methodName: string;
  readonly service: typeof TrackingService;
  readonly requestStream: true;
  readonly responseStream: false;
  readonly requestType: typeof src_app_protos_trackingService_pb.PulseMessage;
  readonly responseType: typeof google_protobuf_empty_pb.Empty;
};

type TrackingServiceSubscribeNotification = {
  readonly methodName: string;
  readonly service: typeof TrackingService;
  readonly requestStream: false;
  readonly responseStream: true;
  readonly requestType: typeof src_app_protos_trackingService_pb.SubscriptionRequest;
  readonly responseType: typeof src_app_protos_trackingService_pb.NotificationMessage;
};

export class TrackingService {
  static readonly serviceName: string;
  static readonly SendMessage: TrackingServiceSendMessage;
  static readonly KeepAlive: TrackingServiceKeepAlive;
  static readonly SubscribeNotification: TrackingServiceSubscribeNotification;
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

export class TrackingServiceClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  sendMessage(
    requestMessage: src_app_protos_trackingService_pb.TrackingMessage,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_trackingService_pb.TrackingResponse|null) => void
  ): UnaryResponse;
  sendMessage(
    requestMessage: src_app_protos_trackingService_pb.TrackingMessage,
    callback: (error: ServiceError|null, responseMessage: src_app_protos_trackingService_pb.TrackingResponse|null) => void
  ): UnaryResponse;
  keepAlive(metadata?: grpc.Metadata): RequestStream<src_app_protos_trackingService_pb.PulseMessage>;
  subscribeNotification(requestMessage: src_app_protos_trackingService_pb.SubscriptionRequest, metadata?: grpc.Metadata): ResponseStream<src_app_protos_trackingService_pb.NotificationMessage>;
}

