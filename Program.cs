using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace sickroomMS
{
    class Program
    {
        static void Main(string[] args)
        {
start:
            Console.WriteLine("\n\t欢迎使用病房管理系统！\n");
            Console.WriteLine("请选择作为下列用户登陆：");
            Console.WriteLine("1.管理员");
            Console.WriteLine("2.医生");
            Console.WriteLine("3.病人");
            Console.WriteLine("\n0.退出\n");

            char c = Console.ReadKey(true).KeyChar;
            switch (c){
                case '1':administratorLogin();
                         goto start;
                case '2':doctorLogin();
                         goto start;         
                case '3':patientLogin();
                         goto start;
                default:return;
            }
        }

        static void administratorLogin(){
            Administrator administrator = new Administrator();
            Console.WriteLine("已选择作为管理员登陆。");
adminLogin:
            Console.Write("账号：");
            string administratorNO = Console.ReadLine();
            administrator.initiate(Convert.ToInt32(administratorNO));
            Console.Write("密码：");
            string password = readPassword();
            if(administrator.checkPassword(password)){
                Console.WriteLine("登陆成功，选择操作：");
adminHelp:
                Console.WriteLine("1.查询科室");
                Console.WriteLine("2.查询病房");
                Console.WriteLine("3.查询医生");
                Console.WriteLine("4.查询病人");
                Console.WriteLine("5.增加科室");
                Console.WriteLine("6.增加病房");
                Console.WriteLine("7.增加医生");
                Console.WriteLine("8.增加病人");
                Console.WriteLine("9.删除科室");
                Console.WriteLine("a.删除病房");
                Console.WriteLine("b.删除医生");
                Console.WriteLine("c.删除病人");
                Console.WriteLine("d.查看我的信息");
                Console.WriteLine("e.修改密码");
                Console.WriteLine("h.显示帮助信息");
                Console.WriteLine("0.退出\n");
adminOP:
                Console.WriteLine();
                char c = Console.ReadKey(true).KeyChar;
                switch(c){
                    case '1':administrator.getDepartmentInfo();
                             goto adminOP;
                    case '2':administrator.getSickroomInfo();
                             goto adminOP;
                    case '3':administrator.getDoctorInfo();
                             goto adminOP;
                    case '4':administrator.getPatientInfo();
                             goto adminOP;
                    case '5':administrator.insertNewDepartment();
                             goto adminOP;
                    case '6':administrator.insertNewSickroom();
                             goto adminOP;
                    case '7':administrator.insertNewDoctor();
                             goto adminOP;
                    case '8':administrator.insertNewPatient();
                             goto adminOP;
                    case '9':administrator.deleteDepartment();
                             goto adminOP;
                    case 'a':administrator.deleteSickRoom();
                             goto adminOP;
                    case 'b':administrator.deleteDoctor();
                             goto adminOP;
                    case 'c':administrator.deletePatient();
                             goto adminOP;
                    case 'd':administrator.displayInfo();
                             goto adminOP;
                    case 'e':Console.Write("新密码：");
                             string newPassword = readPassword();
                             administrator.setPassword(newPassword);
                             goto adminOP;
                    case 'h':goto adminHelp;
                    default:return;
                }
            }
            else{
                Console.WriteLine("验证失败，请重新输入帐号和密码：");
                goto adminLogin;
            }
        }

        static void doctorLogin(){
            Doctor doctor = new Doctor();
            Console.WriteLine("已选择作为医生登陆。");
dLogin:
            Console.Write("工作证号：");
            string doctorID = Console.ReadLine();
            doctor.initiate(Convert.ToInt32(doctorID));
            Console.Write("密码：");
            string password = readPassword();
            if(doctor.checkPassword(password)){
                Console.WriteLine("登陆成功，选择操作：");
dHelp:
                Console.WriteLine("1.查看我的信息");
                Console.WriteLine("2.查询所有由我负责的病人");
                Console.WriteLine("3.修改密码");
                Console.WriteLine("h.显示帮助信息");
                Console.WriteLine("0.退出\t");
dOP:
                Console.WriteLine();
                char c = Console.ReadKey(true).KeyChar;
                switch(c){
                    case '1':doctor.displayInfo();
                             goto dOP;
                    case '2':doctor.getPatientInfo();
                             goto dOP;
                    case '3':Console.Write("新密码：");
                             string newPassword = readPassword();
                             doctor.setPassword(newPassword);
                             goto dOP;
                    case 'h':goto dHelp;
                    case '0':return;
                }
            }
            else{
                Console.WriteLine("验证失败，请重新输入帐号和密码：");
                goto dLogin;
            }
        }

        static void patientLogin(){
            Patient patient = new Patient();
            Console.WriteLine("已选择作为病人登陆。");
pLogin:
            Console.Write("病历号：");
            string medicalRecordNO = Console.ReadLine();
            patient.initiate(Convert.ToInt32(medicalRecordNO));
            Console.Write("密码：");
            string password = readPassword();
            if(patient.checkPassword(password)){
                Console.WriteLine("登陆成功，选择操作：");
pHelp:
                Console.WriteLine("1.查看我的信息");
                Console.WriteLine("2.查看本院所有的科室信息");
                Console.WriteLine("3.修改密码");
                Console.WriteLine("h.显示帮助信息");
                Console.WriteLine("0.退出\n");
pOP:
                Console.WriteLine();
                char c = Console.ReadKey(true).KeyChar;
                switch(c){
                    case '1':patient.displayInfo();
                             goto pOP;
                    case '2':patient.getAllDepartmentInfo();
                             goto pOP;
                    case '3':Console.Write("新密码：");
                             string newPassword = readPassword();
                             patient.setPassword(newPassword);
                             goto pOP;
                    case 'h':goto pHelp;
                    case '0':return;
                }
            }
            else{
                Console.WriteLine("验证失败，请重新输入帐号和密码：");
                goto pLogin; 
            }
        }

        static string readPassword(){
            string password = "";
            while(true){
                ConsoleKeyInfo key = Console.ReadKey(true);
                if(key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter){
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else{
                    if(key.Key == ConsoleKey.Backspace && password.Length > 0){
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if(key.Key == ConsoleKey.Enter ){
                        Console.WriteLine();
                        break;
                    } 
                }
            }
            return password;
        }
    }
}
