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

    login(userName, userPassword);

}
else if(isUser == "N" || isUser == "n"){

    string wantRegister;
    Console.WriteLine("Do you want to register?");
    Console.WriteLine("Y/N: ");
    wantRegister = Console.ReadLine();

}



// login function
public static void login(string userName, string userPassword){
    Console.WriteLine("Login Success!");
}


