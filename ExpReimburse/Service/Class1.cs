using Model;
using Database;

namespace Service;

public class ServiceClass{

    //login function
    public static void login(string userName, string userPassword){

        User returnUser = DatabaseClass.getUsers(userName, userPassword);

        Console.WriteLine(returnUser.userName + "\n" + returnUser.userRole);
        
    }


    public static void register(){


    }
}