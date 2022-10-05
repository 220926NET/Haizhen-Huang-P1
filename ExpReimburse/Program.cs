//namespace


//Users information variables
string isUser;
string userName;
string userPassword;
string userRole;

//User information storage  //pair userName with corresponding userPassword
Dictionary<string, string> accountInfo = new Dictionary<string, string>();
Dictionary<string, string> roleInfo = new Dictionary<string, string>();
accountInfo.Add("haizhen", "000");
roleInfo.Add("haizhen", "manager");


//Login and register process
while(true){

    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine("Are you an existing user? ");
    Console.WriteLine("Y/N: ");
    isUser = Console.ReadLine();

    if(isUser == "Y" || isUser == "y"){

        Console.WriteLine("Please enter your user name: ");
        userName = Console.ReadLine();
        Console.WriteLine("Please enter your password: ");
        userPassword = Console.ReadLine();

        //Existing users will be logined
        LoginUI.login(userName, userPassword, accountInfo, roleInfo);
        break;


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
            Console.WriteLine("Are you manager ot employee? ");
            userRole = Console.ReadLine();


            //New user will ask for create an account
            LoginUI.register(userName,userPassword,userRole, accountInfo, roleInfo );
            //And then login after created an account
            LoginUI.login(userName, userPassword, accountInfo, roleInfo);
            
            break;
        }
        else if(wantRegister == "n" || wantRegister == "N"){
            //If don't want to create an account
            Console.WriteLine("Back to login page");
        }
        else{
            Console.WriteLine("Please input your choose correctly");
        }

    }
    else{
        Console.WriteLine("Please input your choose correctly");
    }
}


/// <summary>
/// //////////////////////////
/// </summary>
public class LoginUI{

    //login function
    public static void login(string userName, string userPassword, Dictionary<string, string> accountInfo, Dictionary<string, string> roleInfo){

        if(accountInfo.ContainsKey(userName) && accountInfo[userName].Equals(userPassword)){
            Console.WriteLine("Login successful");
            Console.WriteLine("User Name: " + userName);
            Console.WriteLine("Role: " + roleInfo[userName]);
        }
        else{
            Console.WriteLine("user name or password is incorrected");
        }
    }


    //register function
    public static void register(string userName, string userPassword, string userRole, Dictionary<string, string> accountInfo, Dictionary<string, string> roleInfo){

        accountInfo.Add(userName, userPassword);
        roleInfo.Add(userName, userRole);
        Console.WriteLine("Register successful");
        
        
    }
}
