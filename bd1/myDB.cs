using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bd1
{

    enum ErrorsList
    {
        StatusOk = 0,
        BadData = -1,
        NoBD = -2
    }
    class myDB
    {
        private string dataBaseName;
        public string DataBaseName
        {
            get { return dataBaseName; }
            set { dataBaseName = value; }
        }

        private string dataBaseAdress;
        public string DataBaseAdress
        {
            get { return dataBaseAdress; }
            set { dataBaseAdress = value; }
        }

        private string dataBaseUserName;
        public string DataBaseUserName
        {
            get { return dataBaseUserName; }
            set { dataBaseUserName = value; }
        }

        private string dataBasePassword;

        public string DataBasePassword
        {
            get { return dataBasePassword; }
            set { dataBasePassword = value; }
        }

        private string connectiongString;
        public string ConnectiongString
        {
            get { return connectiongString; }
            set { connectiongString = value; }
        }

        private MySqlConnection myConnection;
        private MySqlCommand myCmd;
        private MySqlCommand MyCmd
        {
            get { return myCmd; }
            set { myCmd = value; }
        }
        
        
      

        public myDB()
        {

        }


        public myDB (string dataBase, string dataSource, string user, string password)
        {
            int status = (int)ErrorsList.StatusOk;

            status = SetConnectionParams(dataBase, dataSource, user, password);

        }

  
        private int CheckConnectingParams(string dataBase, string dataSource, string user, string password)
        {
            int status = (int) ErrorsList.StatusOk;
            
            if (string.IsNullOrEmpty(dataBase))
                status = (int)ErrorsList.BadData;

            if(status==(int)ErrorsList.StatusOk)
            {
                if (string.IsNullOrEmpty(dataSource))
                    status = (int)ErrorsList.BadData;
            }

            if (status == (int)ErrorsList.StatusOk)
            {
                if (string.IsNullOrEmpty(user))
                    status = (int)ErrorsList.BadData;
            }

            if (status == (int)ErrorsList.StatusOk)
            {
                if (string.IsNullOrEmpty(password))
                    status = (int)ErrorsList.BadData;
            }
            return status;
        }


        public int SetConnectionParams(string dataBase, string dataSource, string user, string password)
        {
            int status = (int)ErrorsList.StatusOk;

            status = CheckConnectingParams(dataBase, dataSource, user, password);

            if(status==(int)ErrorsList.StatusOk)
            {
                DataBaseName = dataBase;
                DataBaseAdress = dataSource;
                DataBaseUserName = user;
                DataBasePassword = password;
            }
            return status;
        }

        private int SetConnectiongString()
        {
            int status = (int)ErrorsList.StatusOk;

            status = CheckConnectingParams(DataBaseName, DataBaseAdress, DataBaseUserName, DataBasePassword);

            if (status == (int)ErrorsList.StatusOk)
            {
                ConnectiongString="DataBase="+DataBaseName+",DataSourse="+DataBaseAdress+",user="+DataBaseUserName+",password="+DataBasePassword+";";
            }

            return status;
        }


       
    }
}
