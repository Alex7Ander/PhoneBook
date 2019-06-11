using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Person
    {
        private string name;
        private string surname;
        private string middleName;
        private string mobilePhone;
        private string homePhone;
        private string workPhone;
        private string email;
        private string addres;
        private string photoPath;
        private string groupname;

        public string Name { get { return name; } }
        public string Surname { get { return surname; } }
        public string MiddleName { get { return middleName; } }
        public string MobilePhone { get { return mobilePhone; } }
        public string HomePhone { get { return homePhone; } }
        public string WorkPhone { get { return workPhone; } }
        public string Email { get { return email; } }
        public string Addres { get { return addres; } }
        public string PhotoPath { get { return photoPath; } }
        public string Groupname { get { return groupname; } }

        public Person(string _GroupName, string _Name, string _MiddleName, string _SurName, bool _GetFromDB)
        {
            this.groupname = _GroupName;
            this.name = _Name;
            this.surname = _SurName;
            this.middleName = _MiddleName;
            if (_GetFromDB)
            {
                string[,] resOfQuery = new string[1, 6];
                string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
                DataBase dataBase = DataBase.getInstanceDB(filePath);
                string filter = "WHERE name='" + this.name + "' AND surname='" + this.surname + "' AND middlename='" + this.middleName + "' AND groupName='" + this.groupname + "'";
                string sqlQuery = "SELECT mobile_phone, home_phone, work_phone, email, address, photoPath FROM [Persons] " + filter;
                dataBase.sendQuery<string>(sqlQuery, 6, resOfQuery);
                this.mobilePhone = resOfQuery[0, 0];
                this.homePhone = resOfQuery[0, 1];
                this.workPhone = resOfQuery[0, 2];
                this.email = resOfQuery[0, 3];
                this.addres = resOfQuery[0, 4];
                this.photoPath = resOfQuery[0, 5];
            }
        }

        public Person(string _GroupName, string _Name, string _MiddleName, string _SurName, string _MobilePhone,
            string _HomePhone, string _WorkPhone, string _Email, string _Addres, string _PhotoPath)
        {
            this.groupname = _GroupName;
            this.name = _Name;
            this.surname = _SurName;
            this.middleName = _MiddleName;
            this.mobilePhone = _MobilePhone;
            this.homePhone = _HomePhone;
            this.workPhone = _WorkPhone;
            this.email = _Email;
            this.addres = _Addres;
            this.photoPath = _PhotoPath;
        }

        public int update(String[] _UpdatingFiel, String[] _UpdatingValue, int _CountOfUpdating) 
        {
            string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
            DataBase dataBase = DataBase.getInstanceDB(filePath);
            string sqlQuery = "UPDATE [Persons] SET ";
            for (int i=0; i< _CountOfUpdating; i++){
                string upStr = _UpdatingFiel[i] + "='" + _UpdatingValue[i] + "'";
                sqlQuery += upStr;
                if (i != _CountOfUpdating - 1) sqlQuery += ",";
            }
            dataBase.sendNonQuery(sqlQuery);
            return 0;
        }

        public int save()
        {
            string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
            DataBase dataBase = DataBase.getInstanceDB(filePath);
            string where = "groupName='" + this.groupname + "' AND name='" + this.name + "' AND surname='" + this.surname + "' AND middlename='" + this.middleName + "'";
            int countOfSuchPersons = dataBase.selectCount("Persons", "*", where);
            if (countOfSuchPersons == 0){
                string sqlQuery = "INSERT INTO [Persons] (name, surname, middlename, mobile_phone, home_phone, work_phone, email, address, photoPath, groupName) values ('"+this.name+
                    "','"+this.surname+"','"+this.middleName+"','"+this.mobilePhone+"','"+this.homePhone+"','"+this.workPhone+"','"+this.email+"','"+this.addres+"','"+this.photoPath+"','"+this.groupname+"')";
                int res = dataBase.sendNonQuery(sqlQuery);
                return res;
            }
            else{
                return countOfSuchPersons;
            }
        }

        public int delete()
        {
            string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
            DataBase dataBase = DataBase.getInstanceDB(filePath);
            string sqlQuery = "DELETE FROM [Persons] WHERE name='"+this.name+"' AND surname='"+this.surname+"' AND middlename='"+this.middleName+"' AND groupName='"+this.groupname+"'";
            int res = dataBase.sendNonQuery(sqlQuery);
            return res;
        }


    }
}
