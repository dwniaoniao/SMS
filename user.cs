using System;
using System.Data;
using MySql.Data.MySqlClient;

class User{
    public int id;
    public string name;
    public string password;

    public int getID(){
        return this.id;
    }

    public string getName(){
        return this.name;
    }

    public bool checkPassword(string password){
        if(password == this.password) return true;
        else return false;
    }

    public void setPassword(string password){
        this.password = password;
    }

    public MySqlConnection connectToDB(){
        string connectionString = "Database=SICKROOM;Host=localhost;User ID=root;Password=password;";
        try{
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
            return null;
        }
    }
}

