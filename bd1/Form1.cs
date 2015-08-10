using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace bd1
{
    


    public partial class Form1 : Form
    {

        private MySqlConnection myConnection;
        private MySqlCommand myCmd;


        public Form1()
        {
            InitializeComponent();
            tbDB.Text = "database1";
            tbDS.Text = "localhost";
            tbUser.Text = "root";
            btGetData.Enabled = false;
            btGT.Enabled = false;
            btEdit.Enabled = false;
        }
            


        private void btConnect_Click(object sender, EventArgs e)
        {


            myDB _mb = new myDB("132", "2354234", "23524", "23423");


           

        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            if (myConnection != null)
            {
                myConnection.Close();
                StatusLabel.Text = "Succesful close DB";
            }
            else
                StatusLabel.Text = "No opened DB";
            btGT.Enabled = false;
            btGetData.Enabled = false;
            listBox1.Items.Clear();
            cleanGrid();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            cleanGrid();

                myCmd.CommandText = "select * from " + listBox1.SelectedItem + ";";

 

            MySqlDataReader myDReader;

            myDReader = myCmd.ExecuteReader();

//            myDReader.Read();
            string[] arr = new string[100];
             for(int i = 0;i < myDReader.FieldCount;i++)
             {
                 dataGridView1.Columns.Add(i.ToString(), myDReader.GetName(i));
             }
            

                 while (myDReader.Read())
                 {
                     for (int i = 0; i < myDReader.FieldCount; i++)
                     {
                         arr[i] = myDReader.GetString(i);
                     }
                     dataGridView1.Rows.Add(arr);
                 }



            myDReader.Close();

        }

        private void btGetTables_Click(object sender, EventArgs e)
        {
            cleanGrid();
             btGetData.Enabled = false;
             btEdit.Enabled = false;
             listBox1.Items.Clear();
             myCmd.CommandText = "SHOW tables;";

             MySqlDataReader myDReader;
            
             myDReader = myCmd.ExecuteReader();
            
             while(myDReader.Read())
             {
                 for (int j = 0; j < myDReader.FieldCount; j++)
                 {
                     listBox1.Items.Add(myDReader.GetString(j));
                 }
                 //int id = myDReader.GetInt32(1);
             }
             myDReader.Close();
             //listBox1.Items.Add(res);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                btGetData.Enabled = false;
            else
            {
                btGetData.Enabled = true;
                btEdit.Enabled = true;
            }
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MyCmd = myCmd;
            form2.Show();
        }

        private void cleanGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
        }


    }
}
