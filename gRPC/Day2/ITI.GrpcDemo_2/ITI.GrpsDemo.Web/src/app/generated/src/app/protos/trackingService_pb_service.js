// package: 
// file: src/app/protos/trackingService.proto

var src_app_protos_trackingService_pb = require("../../../src/app/protos/trackingService_pb");
var google_protobuf_empty_pb = require("google-protobuf/google/protobuf/empty_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var TrackingService = (function () {
  function TrackingService() {}
  TrackingService.serviceName = "TrackingService";
  return TrackingService;
}());

TrackingService.SendMessage = {
  methodName: "SendMessage",
  service: TrackingService,
  requestStream: false,
  responseStream: false,
  requestType: src_app_protos_trackingService_pb.TrackingMessage,
  responseType: src_app_protos_trackingService_pb.TrackingResponse
};

TrackingService.KeepAlive = {
  methodName: "KeepAlive",
  service: TrackingService,
  requestStream: true,
  responseStream: false,
  requestType: src_app_protos_trackingService_pb.PulseMessage,
  responseType: google_protobuf_empty_pb.Empty
};

TrackingService.SubscribeNotification = {
  methodName: "SubscribeNotification",
  service: TrackingService,
  requestStream: false,
  responseStream: true,
  requestType: src_app_protos_trackingService_pb.SubscriptionRequest,
  responseType: src_app_protos_trackingService_pb.NotificationMessage
};

exports.TrackingService = TrackingService;

function TrackingServiceClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

TrackingServiceClient.prototype.sendMessage = function sendMessage(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(TrackingService.SendMessage, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

TrackingServiceClient.prototype.keepAlive = function keepAlive(metadata) {
  var listeners = {
    end: [],
    status: []
  };
  var client = grpc.client(TrackingService.KeepAlive, {
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport
  });
  client.onEnd(function (status, statusMessage, trailers) {
    listeners.status.forEach(function (handler) {
      handler({ code: status, details: statusMessage, metadata: trailers });
    });
    listeners.end.forEach(function (handler) {
      handler({ code: status, details: statusMessage, metadata: trailers });
    });
    listeners = null;
  });
  return {
    on: function (type, handler) {
      listeners[type].push(handler);
      return this;
    },
    write: function (requestMessage) {
      if (!client.started) {
        client.start(metadata);
      }
      client.send(requestMessage);
      return this;
    },
    end: function () {
      client.finishSend();
    },
    cancel: function () {
      listeners = null;
      client.close();
    }
  };
};

TrackingServiceClient.prototype.subscribeNotification = function subscribeNotification(requestMessage, metadata) {
  var listeners = {
    data: [],
    end: [],
    status: []
  };
  var client = grpc.invoke(TrackingService.SubscribeNotification, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onMessage: function (responseMessage) {
      listeners.data.forEach(function (handler) {
        handler(responseMessage);
      });
    },
    onEnd: function (status, statusMessage, trailers) {
      listeners.status.forEach(function (handler) {
        handler({ code: status, details: statusMessage, metadata: trailers });
      });
      listeners.end.forEach(function (handler) {
        handler({ code: status, details: statusMessage, metadata: trailers });
      });
      listeners = null;
    }
  });
  return {
    on: function (type, handler) {
      listeners[type].push(handler);
      return this;
    },
    cancel: function () {
      listeners = null;
      client.close();
    }
  };
};

exports.TrackingServiceClient = TrackingServiceClient;

