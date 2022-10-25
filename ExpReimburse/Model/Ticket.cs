using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;

public class Ticket{

    // Properties
    public int ID{get;}
    public string userName{get;set;}
    public string description{get;set;}
    public string ticketType{get;set;}
    public double amountExpense{get;set;}
    public bool? approvalStatus{get;set;}
    public DateTime date{get;}
    

    // Ticket for DB
    public Ticket(int ID, string userName, string TicketType, string description,double amountExpense, bool? approvalStatus, DateTime date){

        this.ID = ID;
        this.userName = userName;
        this.ticketType = TicketType;
        this.description = description;
        this.amountExpense = amountExpense;
        this.approvalStatus = approvalStatus;
        this.date = date;
    }

    // Ticket for submission
    [JsonConstructor]
    public Ticket(string userName, string TicketType, string description, double amountExpense){

        this.userName = userName;
        this.ticketType = TicketType;
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

    public enum TicketType{

        Travel,
        Food,
        Meidical,
        Accommodation,
        Supplies,
        Other
    }