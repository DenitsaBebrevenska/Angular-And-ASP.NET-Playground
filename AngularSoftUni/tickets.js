var Ticket = /** @class */ (function () {
    function Ticket(destinationInput, priceInput, statusInput) {
        this.destination = destinationInput;
        this.price = Number(priceInput);
        this.status = statusInput;
    }
    return Ticket;
}());
var tickets = new Array;
console.log(solve([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'destination'));
function solve(ticketArray, keyword) {
    while (ticketArray.length > 0) {
        var currentTicketInfo = ticketArray.shift()
            .split('|');
        tickets.push(new Ticket(currentTicketInfo[0], currentTicketInfo[1], currentTicketInfo[2]));
    }
    if (keyword === "destination") {
        tickets.sort(function (a, b) { return a.destination.localeCompare(b.destination); });
    }
    else if (keyword === "status") {
        tickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
    }
    else {
        tickets.sort();
    }
    return (tickets);
}
