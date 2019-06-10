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
        private string lastQuery;
        private string LastQuery { get{return lastQuery;} }

        private DataBase(string filePath)
        {
            this.connetionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + filePath;
            this.aConnection = new OleDbConnection(this.connetionString);
            this.aCommand = new OleDbCommand("", this.aConnection);
        }

        public int selectCount(string tableName, string fieldName, string where)
        {
            int count;
            this.aCommand.CommandText = "SELECT COUNT(" + fieldName + ") AS resInt FROM [" + tableName + "]";
            if (where.Length != 0) this.aCommand.CommandText += (" WHERE " + where); 
            try{
                this.aConnection.Open();
                count = (int)aCommand.ExecuteScalar();
                this.aConnection.Close();
                return count;
            }
            catch (OleDbException exp){
                return -1;
            }
        }

        public int selectCountDistinct(string tableName, string fieldName, string where)
        {
            int count;
            this.aCommand.CommandText = "SELECT COUNT(" + fieldName + ") AS resInt FROM (SELECT DISTINCT "+ fieldName + " FROM ["+ tableName + "] "+ where + ")";
            if (where.Length != 0) this.aCommand.CommandText += (" WHERE " + where);
            try{
                this.aConnection.Open();
                count = (int)aCommand.ExecuteScalar();
                this.aConnection.Close();
                return count;
            }
            catch (OleDbException exp){
                return -1;
            }
        }

        public int sendQuery<T>(string sqlQuery, int countOfFields, T[,] result)
        {
            this.aCommand.CommandText = sqlQuery;
            try{
                this.aConnection.Open();
                this.aReader = aCommand.ExecuteReader();
                int i = 0;
                while (aReader.Read()){
                    for (int j = 0; j < countOfFields; j++){
                        try { 
                            T res = (T)aReader.GetValue(j);
                            result[i, j] = res;
                        }
                        catch (InvalidCastException exp){
                           //
                        }
                    }
                    ++i;
                }
                this.aConnection.Close();
                return i;
            }
            catch (OleDbException exp){
                return -1;
            }
        }

        public int sendNonQuery(string sqlQuery) 
        {
            this.aCommand.CommandText = sqlQuery;
            try{
                this.aConnection.Open();
                aCommand.ExecuteNonQuery();
                this.aConnection.Close();
                return 0;
            }
            catch (OleDbException exp){
                return -1;
            }
        }

        public  static DataBase getInstanceDB(string filePath)
        {
            if (instanceDB == null)
                instanceDB = new DataBase(filePath);
            return instanceDB;
        }
    }
}
