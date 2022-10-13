namespace Model;

public class Ticket{

    // Properties
    string userName;
    string description;
    double amountExp;
    DateOnly date;

    public Ticket(string userName, string description, double amountExp, DateOnly date){

        this.userName = userName;
        this.description = description;
        this.amountExp = amountExp;
        this.date = date;
        
    }

}