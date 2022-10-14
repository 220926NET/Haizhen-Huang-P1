using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseTicket{

    private static SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public static void submitTicket(string userName, string description, double amountExp){

        connection.Open();
        
        SqlCommand command = new SqlCommand($"INSERT into TicketStorage VALUES('{userName}', '{description}', '{amountExp}', 0 ,GETDATE())", connection);
        int affectRows = command.ExecuteNonQuery();
        Console.WriteLine("Invoke submit ticket method successful");
        Console.WriteLine("Affect rows: " + affectRows);

        connection.Close();
    }

    public static List<Ticket> getTicket(string userName){

        List<Ticket> TicketList = new List<Ticket>();
        connection.Open();

        SqlCommand command = new SqlCommand($"SELECT * FROM TicketStorage WHERE [User] = '{userName}'", connection);
        SqlDataReader reader = command.ExecuteReader();

        if(reader.HasRows){

            while(reader.Read()){
                int returnID = (int)reader["ID"];
                string returnUserName = (string)reader["User"];
                string returnDescription = (string)reader["Description"];
                double returnAmountExp = (double)reader["AmountExpense"];
                bool returnApproved = (bool)reader["Approved"];
                DateTime returnDate = (DateTime)reader["date"];

                

                Ticket ticket = new Ticket(returnID, returnUserName, returnDescription, returnAmountExp, returnApproved, returnDate);
                TicketList.Add(ticket);

            }
        }else{
            Console.WriteLine("table is empty");
        }
        
        connection.Close();
        return TicketList;
    }

    public static void approveTicket(){

        List<Ticket> TicketList = new List<Ticket>();
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM TicketStorage WHERE Approved = 0", connection);
        SqlDataReader reader = command.ExecuteReader();

        if(reader.HasRows){

            while(reader.Read()){
                int returnID = (int)reader["ID"];
                string returnUserName = (string)reader["User"];
                string returnDescription = (string)reader["Description"];
                double returnAmountExp = (double)reader["AmountExpense"];
                bool returnApproved = (bool)reader["Approved"];
                DateTime returnDate = (DateTime)reader["date"];

                

                Ticket ticket = new Ticket(returnID, returnUserName, returnDescription, returnAmountExp, returnApproved, returnDate);
                TicketList.Add(ticket);
            }
        }else{
            Console.WriteLine("table is empty");
        }

        foreach(Ticket ticket in TicketList){

                Console.WriteLine(ticket.ID + " " + ticket.userName + " " + ticket.description + " " + ticket.amountExpense + " " + ticket.approved + " " + ticket.date);
            }
        
        Console.WriteLine("Please enter the ID of ticket you want to approve: ");
        int ticketID = int.Parse(Console.ReadLine());

        command = new SqlCommand($"UPDATE TicketStorage SET Approved = 1 WHERE ID = {ticketID}", connection);
        int affectRows = command.ExecuteNonQuery();
        
        Console.Write("Effect row: " + affectRows);
        connection.Close();
    }
}