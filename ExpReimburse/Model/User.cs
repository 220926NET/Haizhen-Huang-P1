using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model;


public class User
{

    //Users information variables
   

    public string userName{get; set;}
    public string userPassword{get; set;}
    public string userRole{get; set;}

    //For register
    


  
    [JsonConstructor]
    public User(string userName, string userPassword, string userRole){

        this.userName = userName;
        this.userPassword = userPassword;
        this.userRole = userRole;


    }

    //For login
    
    public User(string userName, string userPassword){

        this.userName = userName;
        this.userPassword = userPassword;
    }

}
