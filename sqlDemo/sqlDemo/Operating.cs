using System.Data.SqlClient;

namespace sqlDemo
{
    internal class Operating
    {
        public static SqlConnection con = new SqlConnection("data source = (localdb)\\MSSQLLocalDB; initial catalog=master;intergrated security = true");
        public static void createDatabase()
        {
            SqlConnection con = new SqlConnection("data source= (localdb)\\MSSQLLocalDB; initial catalog=master; integrated security=true");
            try
            {
                //Writing SQL Query
                string query = "Create database PersonDetails";
                SqlCommand cmd = new SqlCommand(query, con);
                //Opening Connection
                con.Open();
                //Executing the SQL query
                cmd.ExecuteNonQuery();
                //Display meesage in console
                Console.WriteLine("Database created successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong " + ex);
            }
            finally
            {
                con.Close();
            }
        }
        internal static void ReadDataBase()
        {
            try
            {
                using (con)
                {
                    Person model = new Person();
                    string query = "Select * from Description";
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader(); 
                    if(reader.Read())
                    {
                        while (reader.Read())
                        {
                            Person.Id = Convert.ToString(reader["Id"]);
                            Person.Name = Convert.ToString(reader["Name"]);
                            Person.Salary = Convert.ToString(reader["Salary"]);
                            Person.Phone = Convert.ToString(reader["Phone"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("something error :"+ex.Message);
            }
        }
        public static void updateDatebase()
        {
            try
            {
                string query = "update Person set phonenumber = '11111111' where id =1";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Date updated Suucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Date Not Updated");
            }
            finally
            {
                con.Close();
            }
        }
        public static void DeleteDatebase()
        {
            try
            {
                string query = "Delete from Person where id=2";
                SqlCommand cmd = new SqlCommand(query, con);
                // CommandType type = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Date Deleted Suucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Date Not Updated");
            }
            finally
            {
                con.Close();
            }
        }
        public static void CreateTable()
        {
            try
            {
                string query = "create table Demo(\r\nid int primary key identity(1,1),\r\nname varchar(max),\r\nsalary bigint,\r\naddress varchar(max),\r\nphonenumber varchar(10)\r\n);";
                SqlCommand cmd = new SqlCommand(query, con);
                // CommandType type = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Table  Created Suucessfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Date Not Updated");
            }
            finally
            {
                con.Close();
            }
        }
    }
}