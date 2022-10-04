//namespace


// users login/registe interface feature
string isUser;
string userName;
string userPassword;
Dictionary<string, string> userInfo = new Dictionary<string, string>();
userInfo.Add("haizhen", "000");


Console.WriteLine("Are you an existing user? ");
Console.WriteLine("Y/N: ");
isUser = Console.ReadLine();


if(isUser == "Y" || isUser == "y"){

    Console.WriteLine("Please enter your user name: ");
    userName = Console.ReadLine();
    Console.WriteLine("Please enter your password: ");
    userPassword = Console.ReadLine();


    LoginUI.login(userName, userPassword, userInfo);


}
else if(isUser == "N" || isUser == "n"){


    string wantRegister;
    Console.WriteLine("Do you want to register?");
    Console.WriteLine("Y/N: ");
    wantRegister = Console.ReadLine();

    if(wantRegister == "Y" || wantRegister == "y"){
        
        Console.WriteLine("Please enter your new user name: ");
        userName = Console.ReadLine();
        Console.WriteLine("Please enter your new password: ");
        userPassword = Console.ReadLine();

        LoginUI.register(userName,userPassword,userInfo);
    }
    else{
        Console.WriteLine("Press x to exit.");
    }

}


/// <summary>
/// //////////////////////////
/// </summary>
public class LoginUI{

    //login function
    public static void login(string userName, string userPassword,Dictionary<string, string> userInfo){

        if(userInfo.ContainsKey(userName) && userInfo[userName].Equals(userPassword)){
            Console.WriteLine("Login successful");
        }
        else{
            Console.WriteLine("user name or password is incorrected");
        }
    }


    //register function
    public static void register(string userName, string userPassword, Dictionary<string, string> userInfo){

        userInfo.Add(userName, userPassword);
        Console.WriteLine("Register successful");
        LoginUI.login(userName, userPassword, userInfo);
    }
}
