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
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            updateGroupsList();
        }

        private void groupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updatePersonsList();
        }

        private void updatePersonsList()
        {           
            if (this.groupsComboBox.SelectedItem != null)
            {
                this.personsListBox.Items.Clear();
                string chekedGroup = this.groupsComboBox.SelectedItem.ToString();
                PersonsList personsList = new PersonsList(chekedGroup);
                foreach (string person in personsList) this.personsListBox.Items.Add(person);
            }
        }

        private void updateGroupsList()
        {
            this.groupsComboBox.Items.Clear();
            Groups personsGroups = new Groups();
            foreach (string gr in personsGroups) this.groupsComboBox.Items.Add(gr);
            if (this.groupsComboBox.Items.Count > 0)
            {
                this.groupsComboBox.SelectedIndex = 0;
                this.groupsComboBox.SelectedItem = this.groupsComboBox.Items[0];
            }
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
            string _GroupName = this.groupsComboBox.SelectedItem.ToString();
            string _Name = this.nameTextBox.Text;
            string _MiddleName = this.MidNameTextBox.Text;
            string _SurName = this.surNameTextBox.Text;
            Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            int res = anyPerson.update();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (this.groupsComboBox.Text.Length != 0)
            {
                String _GroupName = this.groupsComboBox.Text;
                String _Name = this.nameTextBox.Text;
                String _MiddleName = this.MidNameTextBox.Text;
                String _SurName = this.surNameTextBox.Text;
                String _MobilePhone = this.mobilePhoneTextBox.Text;
                String _HomePhone = this.homePhoneTextBox.Text;
                String _WorkPhone = this.workPhoneTextBox.Text;
                String _Email = this.emailTextBox.Text;
                String _Addres = this.addrTextBox.Text;
                String _PhotoPath = "";
                Person newPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, _MobilePhone,
                   _HomePhone, _WorkPhone, _Email, _Addres, _PhotoPath);
                int res = newPerson.save();
                if (res == 0)
                {
                    this.updateGroupsList();
                    this.updatePersonsList();
                    MessageBox.Show("Успешное сохранение!", "Успешно!");
                }
                else
                {
                    MessageBox.Show("Ошибка! Информаци не была сохранена! Попробуйте повторить попытку!", "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не указали группу для нового контакта!", "Ошибка!");
            }
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
