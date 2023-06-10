
#region Before SRP
// Before: SRP
class PlaceOrder
 def initialize(product)
 @product = product
 end
 def run
 # 1. Logic related to verification of stock availability
 # 2. Logic related to payment process
 # 3. Logic related to shipment process
 end
end
#endregion

#region After SRP
// After: SRP-1
class PlaceOrder
 def initialize(product, shipment, stock, payment)
 @product = product
 @shipment = shipment
 @stock = stock
 @payment = payment
 end
 def run
 stock.verify()
 payment.check()
 shipment.ship()
 end
end

//After:SRP-2
class PlaceOrder
 def initialize(product)
 @product = product
 end
 def run
 stock.new(@product).run
 payment.new(@product).run
 shipment.new(@product).run
 end
 def run
 stock.verify()
 payment.check()
 shipment.ship()
 end
end

class stock{
    # 1. Logic related to verification of stock availability
 
}
class payment {
    # 2. Logic related to payment process
}

class shipment{
    # 3. Logic related to shipment process
}

#endregion

