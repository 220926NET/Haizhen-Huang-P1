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
}