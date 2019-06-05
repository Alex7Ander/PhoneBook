using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace PhoneBook
{
    class DataBase
    {
        private static DataBase instanceDB;
        private OleDbConnection aConnection;
        private OleDbCommand aCommand;
        private OleDbDataReader aReader;
        private string connetionString;
        private string lastCommand { get; }

        private DataBase(string filePath){
            this.connetionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="+filePath;
            this.aConnection = new OleDbConnection(this.connetionString);
            this.aCommand = new OleDbCommand("", this.aConnection);
        }

        public int select(string sqlQuery, string[] result){

            this.aCommand.CommandText = sqlQuery;
            try{
                this.aConnection.Open();
                this.aReader = aCommand.ExecuteReader();
                int i = 0;
                while (aReader.Read()) {
                    result[i] = aReader.GetString(i);
                    ++i;
                }
                this.aConnection.Close();
                return i;
            }
            catch(OleDbException exp){
                return -1;
            }
        }

        static DataBase getInstanceDB(string filePath){
            if (instanceDB == null)
                instanceDB = new DataBase(filePath);
            return instanceDB;
        }
    }
}
