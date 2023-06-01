using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    public partial class Form1 : Form
    {
        int a = 2;
        DataBase dataBase = new DataBase();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ErrorInfoLb.Visible = false;
            buttonPanel.Enabled = false;
            tabControl.Enabled = false;
            ipTb.Text = "127.0.0.1";
            portTb.Text = "5432";
            usernameTb.Text = "postgres";
            passwordTb.Text = "123456";
            databaseTb.Text = "carsDB";

            tableCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tableCars.AllowUserToAddRows = false;
        }

        private void ConnectionToDbClick(object sender, EventArgs e)
        {
            try
            {
                dataBase.server = ipTb.Text;
                dataBase.port = portTb.Text;
                dataBase.username = usernameTb.Text;
                dataBase.password = passwordTb.Text;
                dataBase.database = databaseTb.Text;
                dataBase.DataBaseOpen();
                dataBase.DataBaseClose();

                Console.WriteLine("Соединение с БД открыто");
                buttonPanel.Enabled = true;
                tabControl.Enabled = true;
                ErrorInfoLb.Visible = false;
            }
            catch (Exception ex)
            {
                ErrorInfoLb.Visible = true;
                tabControl.Enabled = false;
                buttonPanel.Enabled = false;
                ErrorInfoLb.Text = ex.Message;
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowAllTableClick(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataSet ds = dataBase.Show(dataBase.sqlCars);
            dataBase.DataBaseClose();
            tableCars.DataSource = ds.Tables[0];

            dataBase.DataBaseOpen();
            DataSet ds1 = dataBase.Show(dataBase.sqlMarks);
            dataBase.DataBaseClose();
            tableMarks.DataSource = ds1.Tables[0];

            dataBase.DataBaseOpen();
            DataSet ds2 = dataBase.Show(dataBase.sqlOwners);
            dataBase.DataBaseClose();
            tableOwners.DataSource = ds2.Tables[0];

        }

        private void InsertToCarsClick(object sender, EventArgs e)
        {

            List<string> textBoxList = new List<string>();
            if (carIdTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(carIdTb.Text);
            }
            if (serialTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(serialTb.Text);
            }
            if (markIdFkTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(markIdFkTb.Text);
            }
            if (ownerIdFkTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(ownerIdFkTb.Text);
            }
            if (priceTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(priceTb.Text);
            }
            if (dateOfProductionTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(dateOfProductionTb.Text);
            }

            dataBase.DataBaseOpen();
            bool result = dataBase.InsertToCars(textBoxList);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void InsertToMarksClick(object sender, EventArgs e)
        {
            List<string> textBoxList = new List<string>();
            if (markIdPkTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(markIdPkTb.Text);
            }
            if (markNameTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(markNameTb.Text);
            }
            if (typeTb.Text == string.Empty)
            {
                textBoxList.Add(" ");
            }
            else
            {
                textBoxList.Add(typeTb.Text);
            }
            dataBase.DataBaseOpen();
            bool result = dataBase.InsertToMarks(textBoxList);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void InsertToOwnersClick(object sender, EventArgs e)
        {
            List<string> textBoxList = new List<string>();
            if (ownerIdPkTb.Text == string.Empty)
            {
                textBoxList.Add("");
            }
            else
            {
                textBoxList.Add(ownerIdPkTb.Text);
            }
            if (firstNameTb.Text == string.Empty)
            {
                textBoxList.Add("");
            }
            else
            {
                textBoxList.Add(firstNameTb.Text);
            }
            if (secondNameTb.Text == string.Empty)
            {
                textBoxList.Add("");
            }
            else
            {
                textBoxList.Add(secondNameTb.Text);
            }
            if (mobileTb.Text == string.Empty)
            {
                textBoxList.Add("");
            }
            else
            {
                textBoxList.Add(mobileTb.Text);
            }
            if (dateOfBirthTb.Text == string.Empty)
            {
                textBoxList.Add("");
            }
            else
            {
                textBoxList.Add(dateOfBirthTb.Text);
            }
            dataBase.DataBaseOpen();
            bool result = dataBase.InsertToOwners(textBoxList);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void UpdateToMarksClick(object sender, EventArgs e)
        {
            string id = marksIdTb.Text;
            List<string> textBoxList = new List<string>();
            if (markIdPkTb.Text != string.Empty)
            {
                textBoxList.Add("mark_id =" + "'" + markIdPkTb.Text + "'");
            }

            if (markNameTb.Text != string.Empty)
            {
                textBoxList.Add("mark_name =" + "'" + markNameTb.Text + "'");
            }

            if (typeTb.Text != string.Empty)
            {
                textBoxList.Add("type =" + "'" + typeTb.Text + "'");
            }

            dataBase.DataBaseOpen();
            bool result = dataBase.UpdateToMarks(textBoxList, id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void UpdateToCarsClick(object sender, EventArgs e)
        {
            string id = carsIdTb.Text;
            List<string> textBoxList = new List<string>();
            if (carIdTb.Text != string.Empty)
            {
                textBoxList.Add("car_id =" + "'" + carIdTb.Text + "'");
            }

            if (serialTb.Text != string.Empty)
            {
                textBoxList.Add("serial =" + "'" + serialTb.Text + "'");
            }

            if (markIdFkTb.Text != string.Empty)
            {
                textBoxList.Add("mark_id =" + "'" + markIdFkTb.Text + "'");
            }

            if (ownerIdFkTb.Text != string.Empty)
            {
                textBoxList.Add("owner_id =" + "'" + ownerIdFkTb.Text + "'");
            }

            if (priceTb.Text != string.Empty)
            {
                textBoxList.Add("price =" + "'" + priceTb.Text + "'");
            }

            if (dateOfProductionTb.Text != string.Empty)
            {
                textBoxList.Add("date_of_production =" + "'" + dateOfProductionTb.Text + "'");
            }

            dataBase.DataBaseOpen();
            bool result = dataBase.UpdateToCars(textBoxList, id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void UpdateToOwnersClick(object sender, EventArgs e)
        {
            string id = ownersIdTb.Text;

            List<string> textBoxList = new List<string>();
            if (ownerIdPkTb.Text != string.Empty)
            {
                textBoxList.Add("owner_id =" + "'" + ownerIdPkTb.Text + "'");
            }

            if (firstNameTb.Text != string.Empty)
            {
                textBoxList.Add("first_name =" + "'" + firstNameTb.Text + "'");
            }

            if (secondNameTb.Text != string.Empty)
            {
                textBoxList.Add("second_name =" + "'" + secondNameTb.Text + "'");
            }

            if (mobileTb.Text != string.Empty)
            {
                textBoxList.Add("mobile =" + "'" + mobileTb.Text + "'");
            }

            if (dateOfBirthTb.Text != string.Empty)
            {
                textBoxList.Add("date_of_birth =" + "'" + dateOfBirthTb.Text + "'");
            }

            dataBase.DataBaseOpen();
            bool result = dataBase.UpdateToOwners(textBoxList, id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось добавить данные в таблицу";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }

        }


        private void DeleteFromCarsClick(object sender, EventArgs e)
        {
            string id = carsIdTb.Text;
            dataBase.DataBaseOpen();
            bool result = dataBase.DeleteFromCars(id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось удалить данные из таблицы";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void DeleteFromMarksClicl(object sender, EventArgs e)
        {
            string id = marksIdTb.Text;
            dataBase.DataBaseOpen();
            bool result = dataBase.DeleteFromMarks(id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось удалить данные из таблицы";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void DeleteFromOwnersClick(object sender, EventArgs e)
        {
            string id = ownersIdTb.Text;
            dataBase.DataBaseOpen();
            bool result = dataBase.DeleteFromOwners(id);
            dataBase.DataBaseClose();
            if (result == false)
            {
                ErrorInfoLb.Visible = true;
                ErrorInfoLb.Text = "Не удалось удалить данные из таблицы";
            }
            else
            {
                ErrorInfoLb.Visible = false;
            }
        }

        private void Task1Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task1();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task1_1Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task1_1();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task2Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task2();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task3Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task3();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task4Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task4();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task5Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task5();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task6Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task6();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }

        private void Task7Click(object sender, EventArgs e)
        {
            dataBase.DataBaseOpen();
            DataTable ds = dataBase.Task7();
            dataBase.DataBaseClose();
            tableTaskGv.DataSource = ds;
        }
    }

}
