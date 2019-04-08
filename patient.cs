using System;
using System.Data;
using MySql.Data.MySqlClient;

class Patient:User{
    public string gender;
    public int doctorID;
    public int sickroomID;

    public void initiate(int id){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("select * from patient where medicalRecordNO = {0}",id));
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){
                this.id = reader.GetInt32("medicalRecordNO");
                this.password = reader.GetString("password");
                this.name = reader.GetString("patientName");
                this.gender = reader.GetString("gender");
                this.doctorID = reader.GetInt32("doctorID"); 
                this.sickroomID = reader.GetInt32("sickroomID");
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
            MySqlCommand command = new MySqlCommand(String.Format("update patient set password = '{0}' where medicalRecordNO = {1}",password,this.id));
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
        Console.WriteLine("病历号：{0}",this.id);
        Console.WriteLine("姓名：{0}",this.name);
        Console.WriteLine("性别：{0}",this.gender);
        Console.WriteLine("主管医生工作证号：{0}",this.doctorID);
        Console.WriteLine("病房号：{0}",this.sickroomID);
    }

    public void getAllDepartmentInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand("select * from department");
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("科名\t科地址\t电话");
            while(reader.Read()){
                string result = String.Format("{0}\t{1}\t{2}",reader.GetString("departmentName"),reader.GetString("departmentAddress"),reader.GetString("telephoneNO"));
                Console.WriteLine(result);
            }
            reader.Close();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public static void noMain(){
        Patient p = new Patient();
        p.initiate(1);
        Console.WriteLine("{0}{1}{2}{3}{4}{5}",p.id,p.password,p.name,p.gender,p.doctorID,p.sickroomID);
        p.setPassword("fuckyouman");
        p.getAllDepartmentInfo();
    }
}
