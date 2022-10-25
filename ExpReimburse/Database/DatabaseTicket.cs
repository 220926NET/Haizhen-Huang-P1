using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseTicket{

    private static SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public static async Task<Ticket> submitTicket(Ticket ticketToSubmit){

        connection.Open();
        
        SqlCommand command = new SqlCommand($"INSERT into TicketStorage VALUES('{ticketToSubmit.userName}','{ticketToSubmit.ticketType}','{ticketToSubmit.description}', '{ticketToSubmit.amountExpense}', NULL ,GETDATE())", connection);

        try{

            int affectRows = await command.ExecuteNonQueryAsync();
            if(affectRows == 1){

                connection.Close();
                return ticketToSubmit;
            
            }
            else{

                connection.Close();
                return null;
            }


        }catch(Microsoft.Data.SqlClient.SqlException e){

            connection.Close();
            return null;

        }
        

        
    }

    public static async Task<List<Ticket>> getTicket(User returnUser){

        //retrive User data from DB
        User user = await DatabaseUser.getUsers(returnUser);

        if(user != null){

            List<Ticket> TicketList = new List<Ticket>();
            connection.Open();

            SqlCommand command = new SqlCommand($"SELECT * FROM TicketStorage WHERE [User] = '{returnUser.userName}'", connection);
            SqlDataReader reader = await command.ExecuteReaderAsync();

            if(reader.HasRows){

                while(reader.Read()){
                    int dbID = (int)reader["ID"];
                    string dbName = (string)reader["User"];
                    string dbType = (string)reader["TicketType"];
                    string dbDescription = (string)reader["Description"];
                    double dbAmountExp = (double)reader["AmountExpense"];
                    bool? dbApprovalStatus = Convert.IsDBNull(reader["ApprovalStatus"])? null: (bool?)reader["ApprovalStatus"];
                    DateTime dbDate = (DateTime)reader["date"];

                    

                    Ticket ticket = new Ticket(dbID, dbName, dbType,dbDescription, dbAmountExp, dbApprovalStatus, dbDate);
                    TicketList.Add(ticket);

                }
            }
            
            connection.Close();
            return TicketList;

        }
        else{

            return null;
        }

        
    }


    // Overload getTicket method for Manager
    // return waiting approve tickets
    public static async Task<List<Ticket>> ViewPendingTicket(){

        List<Ticket> TicketList = new List<Ticket>();
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM TicketStorage WHERE ApprovalStatus IS NULL", connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        if(reader.HasRows){

            while(reader.Read()){
                int returnID = (int)reader["ID"];
                string returnUserName = (string)reader["User"];
                string returnType = (string)reader["TicketType"];
                string returnDescription = (string)reader["Description"];
                double returnAmountExp = (double)reader["AmountExpense"];
                bool? returnApprovalStatus = Convert.IsDBNull(reader["ApprovalStatus"])? null: (bool?)reader["ApprovalStatus"];
                DateTime returnDate = (DateTime)reader["date"];

                Ticket ticket = new Ticket(returnID, returnUserName, returnType, returnDescription, returnAmountExp, returnApprovalStatus, returnDate);
                TicketList.Add(ticket);

            }
        }else{
            Console.WriteLine("Table is empty");
        }
        
        connection.Close();
        return TicketList;
    }


    public static Ticket ProcessPendingTicket(int ticketID, bool action){

        string actionCmd = action? "1":"0";

        connection.Open();

        SqlCommand command = new SqlCommand($"UPDATE TicketStorage SET ApprovalStatus = {actionCmd} WHERE ID = {ticketID}", connection);
        int affectRows = command.ExecuteNonQuery();

        if(affectRows == 1){
            connection.Close();
            return RetriveProcessedTicket(ticketID);
        }
        else{
            connection.Close();
            return null;

        }
    
    }

    public static Ticket RetriveProcessedTicket(int ticketID){

        connection.Open();
        SqlCommand command2 = new SqlCommand($"SELECT * FROM TicketStorage WHERE ID = {ticketID}", connection);
        SqlDataReader reader = command2.ExecuteReader();
        Ticket ticket = null;

        if(reader.HasRows){
            while(reader.Read()){

                int returnID = (int)reader["ID"];
                string returnUserName = (string)reader["User"];
                string returnType = (string)reader["TicketType"];
                string returnDescription = (string)reader["Description"];
                double returnAmountExp = (double)reader["AmountExpense"];
                bool? returnApprovalStatus = Convert.IsDBNull(reader["ApprovalStatus"])? null: (bool?)reader["ApprovalStatus"];
                DateTime returnDate = (DateTime)reader["date"];

                ticket = new Ticket(returnID, returnUserName, returnType, returnDescription, returnAmountExp, returnApprovalStatus, returnDate);
                connection.Close();
                return ticket; 
            }
            
                
        }
        return ticket;
    }


    
}