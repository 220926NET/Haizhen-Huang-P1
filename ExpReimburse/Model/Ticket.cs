namespace Model;

public class Ticket{

    // Properties
    public int ID;
    public string userName;
    public string description;
    public double amountExpense;
    public bool approved;
    public DateTime date;
    

    public Ticket(int ID, string userName, string description, double amountExpense, bool approved, DateTime date){

        this.ID = ID;
        this.userName = userName;
        this.description = description;
        this.amountExpense = amountExpense;
        this.approved = approved;
        this.date = date;
    }

}