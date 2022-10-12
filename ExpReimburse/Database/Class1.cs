using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseClass
{


    public static User getUsers(string userName, string userPassword){

        SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM UserStorage", connection);
        SqlDataReader reader = command.ExecuteReader();

        if(reader.HasRows){

            while(reader.Read()){

                
                if((string)reader["UserName"] == userName && (string)reader["UserPassword"] == userPassword){

                    string returnUserName = (string)reader["UserName"];
                    string returnUserPassword = (string)reader["UserPassword"];
                    string returnUserRole = (string)reader["UserRole"];

                    User user = new User(returnUserName, returnUserPassword, returnUserRole);
                    return user;
                }
                
            }
        }

        Console.WriteLine("User name is not exist");
        return null; 
    }
}
