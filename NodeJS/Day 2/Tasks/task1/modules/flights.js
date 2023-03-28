const { v4: guid } = require('uuid');

class Ticket {
    id;
    seatNumber;
    flightNumber;
    departureAirport;
    arrivalAirport;
    flightDate;


    constructor(seatNumber, flightNumber, departureAirport, arrivalAirport, flightDate) {
        this.id = guid();
        this.seatNumber = seatNumber;
        this.flightNumber = flightNumber;
        this.departureAirport = departureAirport;
        this.arrivalAirport = arrivalAirport;
        this.flightDate = flightDate;
    }
}

class Flights{
    tickets = [];

    AddTicket(seatNumber, flightNumber, departureAirport, arrivalAirport, flightDate){
        let t = new Ticket(seatNumber, flightNumber, departureAirport, arrivalAirport, flightDate);
        this.tickets.push(t);
        return t.id;
    }

    DisplayTicket(id){
        let ticket = this.tickets.find((t) => t.id === id);
        console.log(ticket);
    }

    GetTicket(id){
        return this.tickets.find((t) => t.id === id)
    }

    UpdateTicket(id, updatedTicket){
        let ticket = this.tickets.find((t) => t.id === id);
        ticket.seatNumber = updatedTicket.seatNumber;
        ticket.flightNumber = updatedTicket.flightNumber;
        ticket.departureAirport = updatedTicket.departureAirport;
        ticket.arrivalAirport = updatedTicket.arrivalAirport;
        ticket.flightDate = updatedTicket.flightDate;

        return ticket;
    }
}

module.exports = {
    Flights
}