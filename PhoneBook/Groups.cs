using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Groups
    {
        private int countOfGroups;
        private string[] groups;

        public Groups()
        {
            string filePath = CurrentDirrectoryReturner.getDirrectory() + "//data//data.mdb";
            DataBase dataBase = DataBase.getInstanceDB(filePath);
            this.countOfGroups = dataBase.selectCountDistinct("Persons", "groupName", "");
            groups = new string[this.countOfGroups];
            string sqlQuery = "SELECT DISTINCT [groupName] FROM [Persons]";
            string[,] res = new string[this.countOfGroups, 1];
            dataBase.sendQuery<string>(sqlQuery, 1, res);
            for (int i = 0; i < this.countOfGroups; i++){
                String r = res[i, 0];
                this.groups[i] = r;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < countOfGroups; i++){
                yield return groups[i];
            }
        }
    }
}
