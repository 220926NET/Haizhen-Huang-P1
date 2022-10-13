namespace Model;

public class Ticket{

    // Properties
    public string userName;
    public string description;
    public double amountExp;
    

    public Ticket(string userName, string description, double amountExp){

        this.userName = userName;
        this.description = description;
        this.amountExp = amountExp;
        
    }

}