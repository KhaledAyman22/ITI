// Before: ISP
// BAD Design
class Car
 def open
 end

 def start_engine
 end

 def change_engine
 end
end
# ISP violation: Driver instance does not make use
# of #change_engine
class Drive
 def take_a_ride(car)
 car.open
 car.start_engine
 end
end
# ISP violation: Mechanic instance does not make use
# of #start_engine
class Mechanic
 def repair(car)
 car.open
 car.change_engine
 end
end