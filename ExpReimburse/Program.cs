// users login/register

string isUser;
string userName;
string userPassword;

Console.WriteLine("Are you an existing user? ");
Console.WriteLine("Y/N: ");
isUser = Console.ReadLine();


if(isUser == "Y" || isUser == "y"){

    Console.WriteLine("Please enter your user name: ");
    userName = Console.ReadLine();
    Console.WriteLine("Please enter your password: ");
    userPassword = Console.ReadLine();

    LoginAndRegister.login(userName, userPassword);

}
else if(isUser == "N" || isUser == "n"){

    string wantRegister;
    Console.WriteLine("Do you want to register?");
    Console.WriteLine("Y/N: ");
    wantRegister = Console.ReadLine();

    if(wantRegister == "Y" || wantRegister == "y"){
        LoginAndRegister.register();
    }
    else{
        Console.WriteLine("Press x to exit.");
    }

}


/// <summary>
/// //////////////////////////
/// </summary>
public class LoginAndRegister{

    //login function
    public static void login(string userName, string userPassword){

        if(userName == "haizhen" && userPassword == "000"){
            Console.WriteLine("Login successful");
        }
    }

    //register function

    public static void register(){
        Console.WriteLine("Please enter your new user name: ");
        Console.WriteLine("Please enter your new password: ");
    }
}



