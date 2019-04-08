using System;
using System.Data;
using MySql.Data.MySqlClient;

class Doctor:User{
    public int age;
    public string jobTitle;
    public string department;

    public int getAge(){
        return this.age;
    }

    public string getJobTitle(){
        return this.jobTitle;
    }

    public string getDepartment(){
        return this.department;
    }

    public void initiate(int id){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("select * from doctor where doctorID = {0}",id));
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){
                this.id = reader.GetInt32("doctorID");
                this.password = reader.GetString("password");
                this.name = reader.GetString("doctorName");
                this.age = reader.GetInt32("age");
                this.jobTitle = reader.GetString("jobTitle"); 
                this.department = reader.GetString("departmentName");
                reader.Close();
                command.Connection.Close();
            }
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public bool setPassword(string password){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("update doctor set password = '{0}' where doctorID = {1}",password,this.id));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
            this.password = password;
            return true;
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
            return false;
        }
    }
    
    public void displayInfo(){
        Console.WriteLine("工作证号：{0}",this.id); 
        Console.WriteLine("姓名：{0}",this.name);
        Console.WriteLine("年龄：{0}",this.age);
        Console.WriteLine("职称：{0}",this.jobTitle);
        Console.WriteLine("所在科室：{0}",this.department); 
    }

    public void getPatientInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            string s = String.Format("select medicalRecordNO,patientName,sickroomID from patient, doctor where patient.doctorID = doctor.doctorID and doctor.doctorID = {0}",this.id);
            MySqlCommand command = new MySqlCommand(s);
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("病历号\t姓名\t病房号");
            while(reader.Read()){
                string result = String.Format("{0}\t{1}\t{2}",reader.GetString("medicalRecordNO"),reader.GetString("patientName"),reader.GetString("sickroomID"));
                Console.WriteLine(result);
            }
            reader.Close();
            command.Connection.Close();
        } 
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }
    public static void Main(){
        Doctor d = new Doctor();
        d.initiate(1);
        Console.WriteLine(d.name);
        if(d.setPassword("fuck")){
            Console.WriteLine(d.password);
        }
        d.displayInfo();
        d.getPatientInfo();
    }
}
