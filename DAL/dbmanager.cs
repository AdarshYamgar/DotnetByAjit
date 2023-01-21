namespace DAL;
using BOL;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
public class dbmanager
{
    public static string con=@"server=localhost;
                                user=root;
                                port=3306;
                                password=aniket8425;
                                database=feedbacksystem";
    
    public static List<Student> getstudent(){

        List<Student> std=new List<Student>();
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString=con;

        try{
            conn.Open();
            string query="select * from student";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=conn;
            cmd.CommandText=query;
            MySqlDataReader reader= cmd.ExecuteReader();
            while(reader.Read())
            {
                int sid1 = int.Parse(reader["sid"].ToString()!);
                string name1 = reader["sname"].ToString()!;
                string email1 = reader["email"].ToString()!;
                string password1 = reader["password"].ToString()!;
                Student stud=new Student(){
                    Sid=sid1,
                    Sname=name1,
                    Semail=email1,
                    Spassword=password1
                };
                std.Add(stud);
            }
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return std;
    }

    public static void insertstd(Student stud){
        List<Student> std=new List<Student>();
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString=con;

        try{
            conn.Open();
            string query="insert into student values("+stud.Sid+",'"+stud.Sname+"','"+stud.Semail+"','"+stud.Spassword+"')";
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=conn;
            cmd.CommandText=query;
           cmd.ExecuteNonQuery();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return;
    }
    public static void deletestd(int id){
        List<Student> std=new List<Student>();
        MySqlConnection conn=new MySqlConnection();
        conn.ConnectionString=con;

        try{
            conn.Open();
            string query="delete from student where sid = " +id;
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection=conn;
            cmd.CommandText=query;
           cmd.ExecuteNonQuery();
        }
        catch(Exception e){
            Console.WriteLine(e.Message);
        }
        finally{
            conn.Close();
        }
        return;
    }
}
