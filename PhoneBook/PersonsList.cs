using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PersonsList
    {
        private int countOfPersons;
        private string[] personItem;
        private string groupName;

        public PersonsList(string _GroupName)
        {
            groupName = _GroupName;
            string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
            DataBase dataBase = DataBase.getInstanceDB(filePath);
            this.countOfPersons = dataBase.selectCount("Persons", "groupName", "");
            personItem = new string[this.countOfPersons];
            string sqlQuery = "SELECT name, middlename, surname FROM [Persons] WHERE groupName='" + groupName + "'";
            string[,] res = new string[this.countOfPersons, 3];
            dataBase.sendQuery<string>(sqlQuery, 3, res);
            for (int i = 0; i < this.countOfPersons; i++){
                this.personItem[i]  = res[i, 0] + " ";
                this.personItem[i] += (res[i, 1] + " ");
                this.personItem[i] += res[i, 2];
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < countOfPersons; i++)
            {
                yield return personItem[i];
            }
        }


    }
}