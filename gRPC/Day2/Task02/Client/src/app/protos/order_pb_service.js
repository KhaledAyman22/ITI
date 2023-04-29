// package: order
// file: src/app/protos/order.proto

var src_app_protos_order_pb = require("./order_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var Order = (function () {
  function Order() {}
  Order.serviceName = "order.Order";
  return Order;
}());

Order.PlaceOrder = {
  methodName: "PlaceOrder",
  service: Order,
  requestStream: false,
  responseStream: false,
  requestType: src_app_protos_order_pb.OrderRequest,
  responseType: src_app_protos_order_pb.OrderReply
};

exports.Order = Order;

function OrderClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

OrderClient.prototype.placeOrder = function placeOrder(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(Order.PlaceOrder, {
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

exports.OrderClient = OrderClient;

