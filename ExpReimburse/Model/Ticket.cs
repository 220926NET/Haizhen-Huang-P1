namespace Model;

public class Ticket{

    // Properties
    public int ID;
    public string userName;
    public string description;
    public double amountExpense;
    public bool approved;
    public DateTime date;
    

    // Ticket for DB
    public Ticket(int ID, string userName, string description, double amountExpense, bool approved, DateTime date){

        this.ID = ID;
        this.userName = userName;
        this.description = description;
        this.amountExpense = amountExpense;
        this.approved = approved;
        this.date = date;
    }

    // Ticket for submission
    public Ticket(string userName, string description, double amountExpense){

        this.userName = userName;
        this.description = description;
        this.amountExpense = amountExpense;
    }

}