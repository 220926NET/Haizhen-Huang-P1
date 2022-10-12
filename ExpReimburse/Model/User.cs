namespace Model;

public class User
{

    //Users information variables
   
    public string userName;
    public string userPassword;
    public string userRole;

    public User(string userName, string userPassword, string userRole){

        this.userName = userName;
        this.userPassword = userPassword;
        this.userRole = userRole;


    }


    

    //login function
    public static void login(string userName, string userPassword, Dictionary<string, User> UserDB){

        try{
            
            if(UserDB[userName].userName == userName && UserDB[userName].userPassword == userPassword){
            Console.WriteLine("Login successful");
            Console.WriteLine("User Name: " + UserDB[userName].userName);
            Console.WriteLine("Role: " + UserDB[userName].userRole);
            }
            else{
                Console.WriteLine("User password is not correct");
            }
            
        }catch(KeyNotFoundException e){

            Console.WriteLine("User name is not exist");
        }
         
    }


    //register function
    public static User register(string userName, string userPassword, string userRole){

        User newUser = new User(userName, userPassword, userRole);
        Console.WriteLine("Register successful");
        

        return newUser;
        
    }
}
