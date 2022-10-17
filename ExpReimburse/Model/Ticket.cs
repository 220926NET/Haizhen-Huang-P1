namespace Model;

public class Ticket{

    // Properties
    public int ID;
    public string userName;
    public string description;
    public double amountExpense;
    public bool? approvalStatus;
    public DateTime date;
    

    // Ticket for DB
    public Ticket(int ID, string userName, string description, double amountExpense, bool? approvalStatus, DateTime date){

        this.ID = ID;
        this.userName = userName;
        this.description = description;
        this.amountExpense = amountExpense;
        this.approvalStatus = approvalStatus;
        this.date = date;
    }

    // Ticket for submission
    public Ticket(string userName, string description, double amountExpense){

        this.userName = userName;
        this.description = description;
        this.amountExpense = amountExpense;
    }

    public static string ApprovalStatusToString(bool? approvalStatus){

        if(approvalStatus.Equals(null)){

            return "Pending";
        }
        else if(approvalStatus == true){

            return "Approved";
        }
        else{

            return "Denied";
        }
    }

}