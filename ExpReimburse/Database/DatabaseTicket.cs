using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseTicket{

    private static SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public static void submitTicket(string userName, string description, double amountExp){

        connection.Open();
        
        SqlCommand command = new SqlCommand($"INSERT into TicketStorage VALUES('{userName}', '{description}', '{amountExp}', GETDATE())", connection);
        int affectRows = command.ExecuteNonQuery();
        Console.WriteLine("Invoke submit ticket method successful");
        Console.WriteLine("Affect rows: " + affectRows);

        connection.Close();
    }

    public static List<Ticket> getTicket(string userName){

        List<Ticket> TicketList = new List<Ticket>();
        connection.Open();

        SqlCommand command = new SqlCommand($"SELECT * FROM TicketStorage WHERE User = '{userName}'");
        SqlDataReader reader = command.ExecuteReader();

        if(reader.HasRows){

            while(reader.Read()){

                string returnUserName = (string)reader["User"];
                string returnDescription = (string)reader["Description"];
                double returnAmountExp = (double)reader["AmountExp"];

                Ticket ticket = new Ticket(returnUserName, returnDescription, returnAmountExp);
                TicketList.Add(ticket);

            }
        }
        
        return TicketList;
    }
}