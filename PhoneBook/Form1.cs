using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class MainForm : Form
    {
        private void updatePersonsList()
        {
            this.personsListBox.Items.Clear();
            string chekedGroup = this.groupsComboBox.SelectedItem.ToString();
            PersonsList personsList = new PersonsList(chekedGroup);
            foreach (string person in personsList) this.personsListBox.Items.Add(person);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Groups personsGroups = new Groups();
            foreach(string gr in personsGroups) this.groupsComboBox.Items.Add(gr);           
        }

        private void groupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updatePersonsList();
           /* this.personsListBox.Items.Clear();
            string chekedGroup = this.groupsComboBox.SelectedItem.ToString();
            PersonsList personsList = new PersonsList(chekedGroup);
            foreach (string person in personsList) this.personsListBox.Items.Add(person);*/
        }

        private void personsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string personItem = this.personsListBox.SelectedItem.ToString();
            int index = personItem.IndexOf(' ');
            string _Name = personItem.Substring(0, index);
            personItem = personItem.Substring(index+1, personItem.Length-index-1);
            index = personItem.IndexOf(' ');
            string _MiddleName = personItem.Substring(0, index);
            string _SurName = personItem.Substring(index+1, personItem.Length-index-1);
            string _GroupName = this.groupsComboBox.SelectedItem.ToString();

            Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            this.nameTextBox.Text = anyPerson.Name;
            this.surNameTextBox.Text = anyPerson.Surname;
            this.MidNameTextBox.Text = anyPerson.MiddleName;
            this.mobilePhoneTextBox.Text = anyPerson.MobilePhone;
            this.homePhoneTextBox.Text = anyPerson.HomePhone;
            this.workPhoneTextBox.Text = anyPerson.WorkPhone;
            this.emailTextBox.Text = anyPerson.Email;
            this.addrTextBox.Text = anyPerson.Addres;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void photoButton_Click(object sender, EventArgs e)
        {
            //
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string _GroupName = this.groupsComboBox.SelectedItem.ToString();
                string _Name = this.nameTextBox.Text;
                string _MiddleName = this.MidNameTextBox.Text;
                string _SurName = this.surNameTextBox.Text;
                Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
                int res = anyPerson.delete();
                if (res == 0){
                    this.updatePersonsList();
                    MessageBox.Show("Успешное удаление!", "Успешно!");
                }
                else{
                    MessageBox.Show("Ошибка! Удаление не было завершено! Попробуйте повторить попытку!", "Ошибка!");
                }
            }
            catch (Exception exp){
                MessageBox.Show("Ошибка! Удаление не было завершено! Попробуйте повторить попытку!", "Ошибка!");
            }
        }
    }
}
