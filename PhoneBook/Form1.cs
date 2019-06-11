using System;
using System.IO;
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
        private string currentPhotoPath;

        public MainForm()
        {
            
            InitializeComponent();
            this.photoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void clearGUI()
        {
            
            this.photoPictureBox.Dispose();
            this.photoPictureBox.Image = null;

            this.nameTextBox.Text = "";
            this.surNameTextBox.Text = "";
            this.MidNameTextBox.Text = "";
            this.mobilePhoneTextBox.Text = "";
            this.workPhoneTextBox.Text = "";
            this.homePhoneTextBox.Text = "";
            this.emailTextBox.Text = "";
            this.addrTextBox.Text = "";
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
            this.currentPhotoPath = anyPerson.PhotoPath;
            if (this.currentPhotoPath == null)
                this.currentPhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\noPhotoAvailable.jpg";
            this.photoPictureBox.Image = Image.FromFile(this.currentPhotoPath);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string _GroupName = this.groupsComboBox.SelectedItem.ToString();
            string _Name = this.nameTextBox.Text;
            string _MiddleName = this.MidNameTextBox.Text;
            string _SurName = this.surNameTextBox.Text;
            Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            //int res = anyPerson.update();
            String newPhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\Photos\\"+
                anyPerson.Groupname+"_"+ anyPerson.Surname+"_"+anyPerson.Name+"_"+anyPerson.MiddleName +".jpg";
            if (!anyPerson.PhotoPath.Equals(newPhotoPath)) {
                File.Copy(currentPhotoPath, newPhotoPath);
            }
                       
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
                String _PhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\Photos\\" +
                _GroupName + "_" + _SurName + "_" + _Name + "_" + _MiddleName + ".jpg"; ;
                Person newPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, _MobilePhone,
                   _HomePhone, _WorkPhone, _Email, _Addres, _PhotoPath);
                int res = newPerson.save();
                if (res == 0)
                {
                    this.updateGroupsList();
                    this.updatePersonsList();
                    File.Copy(this.currentPhotoPath, _PhotoPath, true);
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
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.currentPhotoPath = openFileDialog1.FileName;
                this.photoPictureBox.Image = Image.FromFile(this.currentPhotoPath);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string _GroupName = this.groupsComboBox.SelectedItem.ToString();
            string _Name = this.nameTextBox.Text;
            string _MiddleName = this.MidNameTextBox.Text;
            string _SurName = this.surNameTextBox.Text;
            Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            try
            {
                int res = anyPerson.delete();
                if (res == 0){
                    this.clearGUI();
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

            this.photoPictureBox.Dispose();
            if (anyPerson.PhotoPath!=null)
                File.Delete(anyPerson.PhotoPath);
        }
    }
}
