﻿namespace Model;

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

}
