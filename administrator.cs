using System;
using System.Data;
using MySql.Data.MySqlClient;

class Administrator:User{
    public void initiate(int id){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("select * from administrator where administratorNO = {0}",id));
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            if(reader.Read()){
                this.id = reader.GetInt32("administratorNO");
                this.password = reader.GetString("password");
                this.name = reader.GetString("administratorName");
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
            MySqlCommand command = new MySqlCommand(String.Format("update administrator set password = '{0}' where administratorNo = {1}",password,this.id));
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
    }

    public void getDoctorInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand("select doctorID,doctorName,jobTitle,departmentName from doctor");
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("工作证号\t姓名\t职称\t所在科室");
            while(reader.Read()){
                string result = String.Format("{0}\t{1}\t{2}\t{3}",reader.GetInt32("doctorID"),reader.GetString("doctorName"),reader.GetString("jobTitle"),reader.GetString("departmentName"));
                Console.WriteLine(result);
            }
            reader.Close();
            command.Connection.Close();
        } 
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public void getPatientInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand("select medicalRecordNO,patientName,gender,doctorID,sickroomID from patient");
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("病历号\t姓名\t性别\t主管医生工作证号\t病房号");
            while(reader.Read()){
                string result = String.Format("{0}\t{1}\t{2}\t{3}\t{4}",reader.GetInt32("medicalRecordNO"),reader.GetString("patientName"),reader.GetString("gender"),reader.GetInt32("doctorID"),reader.GetString("sickroomID"));
                Console.WriteLine(result);
            }
            reader.Close();
            command.Connection.Close();
        } 
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public void getDepartmentInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand("select * from department");
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("科名\t地址\t电话");
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

    public void getSickroomInfo(){
        MySqlConnection connection = this.connectToDB();
        try{
            MySqlCommand command = new MySqlCommand("select * from sickroom");
            command.Connection = connection;
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("病房号\t床位号\t所属科室");
            while(reader.Read()){
                string result = String.Format("{0}\t{1}\t{2}",reader.GetInt32("sickroomID"),reader.GetInt32("bedNO"),reader.GetString("departmentName"));
                Console.WriteLine(result);
            }
            reader.Close();
            command.Connection.Close();
        } 
        catch (Exception e){
            Console.WriteLine(e.ToString());
        } 
    }
    
    public void insertNewDepartment(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("科名：");
        string departmentName = Console.ReadLine();
        Console.Write("地址：");
        string departmentAddress = Console.ReadLine();
        Console.Write("电话：");
        string telephoneNO = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("insert into department value ('{0}','{1}','{2}')",departmentName,departmentAddress,telephoneNO));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public void insertNewSickroom(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("床位号：");
        string bedNO = Console.ReadLine();
        Console.Write("所属科室：");
        string departmentName = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("insert into sickroom value (default,{0},'{1}')",bedNO,departmentName));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public void insertNewDoctor(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("姓名：");
        string doctorName = Console.ReadLine();
        Console.Write("年龄：");
        string age = Console.ReadLine();
        Console.Write("职称：");
        string jobTitle = Console.ReadLine();
        Console.Write("所在科室：");
        string departmentName = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("insert into doctor value (default,'','{0}','{1}','{2}','{3}')",doctorName,age,jobTitle,departmentName));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }   
    }

    public void insertNewPatient(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("姓名：");
        string patientName = Console.ReadLine();
        Console.Write("性别：");
        string gender = Console.ReadLine();
        Console.Write("主管医生工作证号：");
        string doctorID = Console.ReadLine();
        Console.Write("病房号：");
        String sickroomID = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("insert into patient value (default,'','{0}','{1}',{2},{3})",patientName,gender,doctorID,sickroomID));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }

    }

    public void deleteDepartment(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("待删除科室名：");
        string departmentName = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("delete from department where departmentName = '{0}'",departmentName));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }
    }

    public void deleteSickRoom(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("待删除病房号：");
        string sickroomID = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("delete from sickroom where sickroomID = {0}",sickroomID));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }   
    }

    public void deleteDoctor(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("待删除医生工作证号：");
        string doctorID = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("delete from doctor where doctorID = {0}",doctorID));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        }   
    }

    public void deletePatient(){
        MySqlConnection connection = this.connectToDB();
        Console.Write("待删除病人病历号：");
        string medicalRecordNO = Console.ReadLine();
        try{
            MySqlCommand command = new MySqlCommand(String.Format("delete from patient where medicalRecordNO = {0}",medicalRecordNO));
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }
        catch (Exception e){
            Console.WriteLine(e.ToString());
        } 
    }

    public static void noMain(){
        Administrator a = new Administrator();
        a.initiate(1);
        Console.WriteLine("{0}\t{1}\t{2}",a.id,a.password,a.name);
//        a.getDepartmentInfo();
//        a.getSickroomInfo();
//        a.getDoctorInfo();
//        a.getPatientInfo();
//        a.insertNewDepartment();
//        a.insertNewSickroom();
//        a.insertNewDoctor();
//        a.insertNewPatient();
//        a.deleteDepartment();
//        a.deleteDepartment();
        a.deleteSickRoom();
        a.deleteDoctor();
        a.deletePatient();
    }  
}


