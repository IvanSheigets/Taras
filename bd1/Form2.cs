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
    public partial class Form2 : Form
    {
        MySqlDataReader myDReader;

           

        private MySqlCommand myCmd;
        public MySqlCommand MyCmd
        {
            get { return myCmd; }
            set { myCmd = value; }
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            myDReader = myCmd.ExecuteReader();
            string[] arr = new string[100];
            for (int i = 0; i < myDReader.FieldCount; i++)
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
        

    }
}
