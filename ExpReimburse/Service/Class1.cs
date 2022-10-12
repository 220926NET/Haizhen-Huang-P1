using Model;
using Database;

namespace Service;

public class ServiceClass{

    //login function
    public static void login(string userName, string userPassword){

        User returnUser = DatabaseClass.getUsers(userName, userPassword);

        try{

            Console.WriteLine("Login successfully");
            Console.WriteLine(returnUser.userName + "\n" + returnUser.userRole);
            
            //NEED submit ticket function
              
        }catch(NullReferenceException e){

            Console.WriteLine("Username or passwaor is NOT correct");
        }
        
        
    }


    public static void register(string userName, string userPassword, string userRole){

        DatabaseClass.setUser(userName, userPassword, userRole);

    }
}