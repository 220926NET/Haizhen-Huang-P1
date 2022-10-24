using Model;
using Microsoft.Data.SqlClient;

namespace Database;

public class DatabaseUser
{

    private static SqlConnection connection = new SqlConnection("Server=tcp:221010-938.database.windows.net,1433;Initial Catalog=ExpenseReimbursement-P1;Persist Security Info=False;User ID=flashcard-admin;Password=personalpwd97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    public static async Task<User> getUsers(User loginUser){

        connection.Open();

        User user;

        SqlCommand command = new SqlCommand("SELECT * FROM UserStorage", connection);
        SqlDataReader reader = await command.ExecuteReaderAsync();

        if(reader.HasRows){

            while(reader.Read()){

                if((string)reader["UserName"] == loginUser.userName && (string)reader["UserPassword"] == loginUser.userPassword){

                    string returnUserName = (string)reader["UserName"];
                    string returnUserPassword = (string)reader["UserPassword"];
                    string returnUserRole = (string)reader["UserRole"];

                    user = new User(returnUserName, returnUserPassword, returnUserRole);
                    connection.Close();
                    return user;
                }
                
            } 
        }
        else{
            
            connection.Close();
            return null;
            
        }

        connection.Close();
        return null;

        
         
    }


    public static async Task<User> setUser(User registerUser){

        connection.Open();

        try{

            SqlCommand command = new SqlCommand($"INSERT INTO UserStorage VALUES('{registerUser.userName}', '{registerUser.userPassword}', '{registerUser.userRole}')", connection);
            int affectRow = await command.ExecuteNonQueryAsync();
            
            if(affectRow == 1){
                
                return registerUser;
            }
            else{
                return null;
            }

        }catch(Microsoft.Data.SqlClient.SqlException e){


            return null;
        }
        finally{

            connection.Close();
        }
        
    }


}
