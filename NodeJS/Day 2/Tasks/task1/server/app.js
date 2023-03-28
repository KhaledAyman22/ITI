let {Flights} = require("../modules/flights");

let flights = new Flights();

let tId = flights.AddTicket("0001", "2A211", "CAI", "JFK", new Date('11-11-2023'))

flights.DisplayTicket(tId);

let t = flights.GetTicket(tId)

t.departureAirport = "KAJ";

t = flights.UpdateTicket(tId, t);

console.log(t);