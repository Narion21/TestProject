using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    internal class DataBase
    {
        public string sqlCars = "SELECT * FROM cars";
        public string sqlMarks = "SELECT * FROM marks";
        public string sqlOwners = "SELECT * FROM owners";
        NpgsqlConnection npgSqlConnection = null;
        public string server { set; get; }

        public string port { set; get; }

        public string username { set; get; }

        public string password { set; get; }

        public string database { set; get; }

        List<string> tableCarsList = new List<string>();
        List<string> tableMarksList = new List<string>();
        List<string> tableOwnersList = new List<string>();

        public static string tableNameCars = "cars";
        public static string tableNameMarks = "marks";
        public static string tableNameOwners = "owners";



        public DataBase()
        {
            tableCarsList.Add("car_id");
            tableCarsList.Add("serial");
            tableCarsList.Add("mark_id");
            tableCarsList.Add("owner_id");
            tableCarsList.Add("price");
            tableCarsList.Add("date_of_production");

            tableMarksList.Add("mark_id");
            tableMarksList.Add("mark_name");
            tableMarksList.Add("type");

            tableOwnersList.Add("owner_id");
            tableOwnersList.Add("first_name");
            tableOwnersList.Add("second_name");
            tableOwnersList.Add("mobile");
            tableOwnersList.Add("date_of_birth");

        }

        public void DataBaseOpen()
        {
            Console.WriteLine("OPEN DB");
            string connectionString = "Server=" + server + ";Port=" + port + ";Username=" + username + ";Password=" + password + ";Database=" + database;
            npgSqlConnection = new NpgsqlConnection(connectionString);
            npgSqlConnection.Open();
        }

        public void DataBaseClose()
        {
            if (npgSqlConnection.State == System.Data.ConnectionState.Open)
            {
                Console.WriteLine("CLOSE DB");
                npgSqlConnection.Close();
            }
        }
        public DataSet Show(string value)
        {

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(value, npgSqlConnection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;

        }
        public bool InsertToCars(List<string> textBoxList)
        {
            bool result = true;
            string command = "INSERT INTO " + tableNameCars + "(";
            for (int i = 0; i < 6; i++)
            {
                if (i <= 4)
                {
                    command += tableCarsList[i] + ',';
                }
                if (i == 5)
                {
                    command += tableCarsList[i];
                }
            }
            command = command + ")" + "VALUES" + "(";
            for (int j = 0; j < 6; j++)
            {
                if (j <= 4)
                {
                    command += "'" + textBoxList[j] + "'" + ',';
                }
                if (j == 5)
                {
                    command += "'" + textBoxList[j] + "'";
                }

            }
            command = command + ")";

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool InsertToMarks(List<string> textBoxList)
        {
            bool result = true;
            string command = "INSERT INTO " + tableNameMarks + "(";
            for (int i = 0; i < 3; i++)
            {
                if (i <= 1)
                {
                    command += tableMarksList[i] + ',';
                }
                if (i == 2)
                {
                    command += tableMarksList[i];
                }
            }
            command = command + ")" + "VALUES" + "(";
            for (int j = 0; j < 3; j++)
            {
                if (j <= 1)
                {
                    command += "'" + textBoxList[j] + "'" + ',';
                }
                if (j == 2)
                {
                    command += "'" + textBoxList[j] + "'";
                }

            }
            command = command + ")";

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool InsertToOwners(List<string> textBoxList)
        {
            bool result = true;
            string command = "INSERT INTO " + tableNameOwners + "(";
            for (int i = 0; i < 5; i++)
            {
                if (i <= 3)
                {
                    command += tableOwnersList[i] + ',';
                }
                if (i == 4)
                {
                    command += tableOwnersList[i];
                }
            }
            command = command + ")" + "VALUES" + "(";
            for (int j = 0; j < 5; j++)
            {
                if (j <= 3)
                {
                    command += "'" + textBoxList[j] + "'" + ',';
                }
                if (j == 4)
                {
                    command += "'" + textBoxList[j] + "'";
                }

            }
            command = command + ")";

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool UpdateToMarks(List<string> textBoxList, string id)
        {
            bool result = true;
            string command = "UPDATE " + tableNameMarks + " SET ";
            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (i < textBoxList.Count - 1)
                {
                    command += textBoxList[i] + ",";
                }
                else
                {
                    command += textBoxList[i];
                }

            }
            command = command + " WHERE id =" + id;

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;

        }

        public bool UpdateToCars(List<string> textBoxList, string id)
        {
            bool result = true;
            string command = "UPDATE " + tableNameCars + " SET ";
            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (i < textBoxList.Count - 1)
                {
                    command += textBoxList[i] + ",";
                }
                else
                {
                    command += textBoxList[i];
                }

            }
            command = command + " WHERE id =" + id;

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool UpdateToOwners(List<string> textBoxList, string id)
        {
            bool result = true;
            string command = "UPDATE " + tableNameOwners + " SET ";
            for (int i = 0; i < textBoxList.Count; i++)
            {
                if (i < textBoxList.Count - 1)
                {
                    command += textBoxList[i] + ",";
                }
                else
                {
                    command += textBoxList[i];
                }

            }
            command = command + " WHERE id =" + id;

            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool DeleteFromCars(string id)
        {
            bool result = true;
            string command = "DELETE FROM " + tableNameCars + " WHERE id=" + id;
            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool DeleteFromMarks(string id)
        {
            bool result = true;
            string command = "DELETE FROM " + tableNameMarks + " WHERE id=" + id;
            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public bool DeleteFromOwners(string id)
        {
            bool result = true;
            string command = "DELETE FROM " + tableNameOwners + " WHERE id=" + id;
            Console.WriteLine(command);
            NpgsqlCommand adapter = new NpgsqlCommand(command, npgSqlConnection);
            try
            {
                adapter.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        public DataTable Task1()
        {
            string command = "SELECT cars.serial, cars.price, marks.type, owners.second_name, " +
                 "cars.date_of_production\r\nFROM cars, marks, owners\r\n" +
                 "WHERE (date_of_production >'01-01-1999' AND date_of_production < '31-12-2019') " +
                 "AND price>=450000\r\nAND cars.mark_id=marks.mark_id " +
                 "AND cars.owner_id = owners.owner_id\r\nORDER BY date_of_production DESC;";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }

        public DataTable Task1_1()
        {
            string command = "SELECT cars.serial, cars.price, marks.type, owners.second_name, " +
                 "cars.date_of_production\r\nFROM cars, marks, owners\r\n" +
                 "WHERE (date_of_production >'01-01-1999' AND date_of_production < '31-12-2019') " +
                 "AND price>=450000\r\nAND cars.mark_id=marks.mark_id " +
                 "AND cars.owner_id = owners.owner_id\r\nORDER BY price ASC;";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }
        public DataTable Task2()
        {
            string command = "SELECT owners.first_name, owners.second_name, marks.mark_name, " +
                "marks.type\r\n" +
                "FROM cars, marks, owners\r\n" +
                "WHERE (substring(cars.serial from 6 for 6)='0') AND cars.mark_id=marks.mark_id " +
                "AND cars.owner_id = owners.owner_id";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }

        public DataTable Task3()
        {
            string command = "SELECT owners.second_name, MIN(price), MAX(price)\r\n" +
                "FROM cars, owners\r\nWHERE cars.owner_id = owners.owner_id\r\n" +
                "GROUP BY second_name, date_of_birth \r\nORDER BY date_of_birth DESC;";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }
        public DataTable Task4()
        {
            string command = "SELECT owners.second_name\r\nFROM cars, owners\r\n" +
                "WHERE price > (SELECT AVG(price) FROM cars) AND cars.owner_id = owners.owner_id";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }

        public DataTable Task5()
        {
            string command = "UPDATE cars SET price=(price*0.1)+price\r\nFROM owners\r\n" +
                "WHERE (owners.first_name LIKE '%Иван%' OR owners.second_name LIKE '%Иван%')\r\n" +
                "AND cars.owner_id = owners.owner_id;\r\n" +
                "SELECT cars.price, owners.first_name, owners. second_name\r\n" +
                "FROM cars, owners\r\nWHERE cars.owner_id = owners.owner_id;";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }

        public DataTable Task6()
        {
            string command = "DELETE FROM marks\r\nWHERE marks.mark_name = 'BMW';\r\n" +
                "SELECT mark_name, price, second_name \r\nFROM cars, marks, owners\r\n" +
                "WHERE cars.mark_id=marks.mark_id AND cars.owner_id = owners.owner_id";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }

        public DataTable Task7()
        {
            string command = "INSERT INTO cars(car_id, serial, mark_id, owner_id, price, " +
                "date_of_production)\r\nVALUES(20,999999,2,3,3000000,'2000-09-04');\r\n" +
                "SELECT serial, mark_name, price, second_name, date_of_production\r\n" +
                "FROM cars, marks, owners\r\nWHERE cars.mark_id=marks.mark_id " +
                "AND cars.owner_id = owners.owner_id";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command, npgSqlConnection);
            DataTable ds = new DataTable();
            adapter.Fill(ds);
            return ds;

        }
    }

}
