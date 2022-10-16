using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseUser
{

    private static SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public static User getUsers(User loginUser){

        connection.Open();

        SqlCommand command = new SqlCommand("SELECT * FROM UserStorage", connection);
        SqlDataReader reader = command.ExecuteReader();

        if(reader.HasRows){

            while(reader.Read()){

                if((string)reader["UserName"] == loginUser.userName && (string)reader["UserPassword"] == loginUser.userPassword){

                    string returnUserName = (string)reader["UserName"];
                    string returnUserPassword = (string)reader["UserPassword"];
                    string returnUserRole = (string)reader["UserRole"];

                    User user = new User(returnUserName, returnUserPassword, returnUserRole);
                    return user;
                }
                
            } 
        }else{

            Console.WriteLine("Database table is empty");
        }

        connection.Close();
        return null; 
    }


    public static void setUser(User registerUser){

        connection.Open();

        try{

            SqlCommand command = new SqlCommand($"INSERT INTO UserStorage VALUES('{registerUser.userName}', '{registerUser.userPassword}', '{registerUser.userRole}')", connection);
            int affectRows = command.ExecuteNonQuery();
            Console.WriteLine("Affect rows: " + affectRows + "\n" + "User register successfully");
            Console.WriteLine("---------------------------");

        }catch(Microsoft.Data.SqlClient.SqlException e){

            Console.WriteLine("User is already exist");
        }
        

        connection.Close();
    }


}
