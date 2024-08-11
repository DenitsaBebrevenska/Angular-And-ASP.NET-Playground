class Ticket {
    public destination: string;
    public price: number;
    public status: string;

    constructor(destinationInput: string, priceInput: string, statusInput: string){
        this.destination = destinationInput;
        this.price = Number(priceInput);
        this.status = statusInput;
    }
}

let tickets: Ticket[] = new Array<Ticket>;

console.log(solve([
    'Philadelphia|94.20|available',
     'New York City|95.99|available',
     'New York City|95.99|sold',
     'Boston|126.20|departed'
    ],
    'status'    
    ));


function solve(ticketArray: string[], keyword: string){

    while(ticketArray.length > 0){
        let currentTicketInfo: string[] = ticketArray.shift()
            .split('|');

        tickets.push(new Ticket(currentTicketInfo[0], currentTicketInfo[1], currentTicketInfo[2]));
    }

    if(keyword === "destination"){
        tickets.sort((a, b) => a.destination.localeCompare(b.destination));
    } else if (keyword === "status"){
        tickets.sort((a, b) => a.status.localeCompare(b.status));
    } else {
        tickets.sort();
    }


    return(tickets);
}




