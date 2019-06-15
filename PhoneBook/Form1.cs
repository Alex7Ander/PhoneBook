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
        private Person CurrentPerson;

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

            CurrentPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            this.nameTextBox.Text = CurrentPerson.Name;
            this.surNameTextBox.Text = CurrentPerson.Surname;
            this.MidNameTextBox.Text = CurrentPerson.MiddleName;
            this.mobilePhoneTextBox.Text = CurrentPerson.MobilePhone;
            this.homePhoneTextBox.Text = CurrentPerson.HomePhone;
            this.workPhoneTextBox.Text = CurrentPerson.WorkPhone;
            this.emailTextBox.Text = CurrentPerson.Email;
            this.addrTextBox.Text = CurrentPerson.Addres;
            this.currentPhotoPath = CurrentPerson.PhotoPath;
            if (this.currentPhotoPath == null)
                this.currentPhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\noPhotoAvailable.jpg";
            var picStream = File.OpenRead(this.currentPhotoPath);
            this.photoPictureBox.Image = Image.FromStream(picStream);
            picStream.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> UpdatedValues = new Dictionary<String, String>();
            if (!this.groupsComboBox.Text.Equals(this.CurrentPerson.Groupname))
                UpdatedValues.Add("groupName", this.groupsComboBox.Text);
            if (!this.nameTextBox.Text.Equals(this.CurrentPerson.Name))
                UpdatedValues.Add("name", this.nameTextBox.Text);
            if (!this.surNameTextBox.Text.Equals(this.CurrentPerson.Surname))
                UpdatedValues.Add("surname", this.surNameTextBox.Text);
            if (!this.MidNameTextBox.Text.Equals(this.CurrentPerson.MiddleName))
                UpdatedValues.Add("middlename", this.MidNameTextBox.Text);
            if (!this.mobilePhoneTextBox.Text.Equals(this.CurrentPerson.MobilePhone))
                UpdatedValues.Add("mobile_phone", this.mobilePhoneTextBox.Text);
            if (!this.workPhoneTextBox.Text.Equals(this.CurrentPerson.WorkPhone))
                UpdatedValues.Add("work_phone", this.workPhoneTextBox.Text);
            if (!this.homePhoneTextBox.Text.Equals(this.CurrentPerson.HomePhone))
                UpdatedValues.Add("home_phone", this.homePhoneTextBox.Text);
            if (!this.emailTextBox.Text.Equals(this.CurrentPerson.Email))
                UpdatedValues.Add("email", this.emailTextBox.Text);
            if (!this.addrTextBox.Text.Equals(this.CurrentPerson.Addres))
                UpdatedValues.Add("address", this.addrTextBox.Text);
            if (!this.currentPhotoPath.Equals(this.CurrentPerson.PhotoPath) && !this.currentPhotoPath.Equals(CurrentDirrectoryReturner.getDirrectory() + "\\data\\noPhotoAvailable.jpg"))
            {
                try
                {
                    String _GroupName = this.groupsComboBox.Text;
                    String _Name = this.nameTextBox.Text;
                    String _MiddleName = this.MidNameTextBox.Text;
                    String _SurName = this.surNameTextBox.Text;
                    String _PhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\Photos\\" +
                    _GroupName + "_" + _SurName + "_" + _Name + "_" + _MiddleName + ".jpg";
                    File.Copy(this.currentPhotoPath, _PhotoPath, true);
                    UpdatedValues.Add("photoPath", _PhotoPath);
                }finally {}
            }
                
            if (UpdatedValues.Count > 0)
            {
                int res = this.CurrentPerson.update(UpdatedValues);
                if (res == 0)
                {
                    this.updateGroupsList();
                    this.updatePersonsList(); 
                    MessageBox.Show("Изменения сохранены", "Успешно!");
                }
                else
                {
                    MessageBox.Show("Ошибка сохранения", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Отображаемые данные актуальны. Нет изменений для внесения в базу данных", "Внимание");
            }
            /*
            if (!this.currentPhotoPath.Equals(this.CurrentPerson.PhotoPath) && !this.currentPhotoPath.Equals(CurrentDirrectoryReturner.getDirrectory() + "\\data\\noPhotoAvailable.jpg"))
            {
                try
                {
                    String _GroupName = this.groupsComboBox.Text;
                    String _Name = this.nameTextBox.Text;
                    String _MiddleName = this.MidNameTextBox.Text;
                    String _SurName = this.surNameTextBox.Text;
                    String _PhotoPath = CurrentDirrectoryReturner.getDirrectory() + "\\data\\Photos\\" +
                    _GroupName + "_" + _SurName + "_" + _Name + "_" + _MiddleName + ".jpg";
                    File.Copy(this.currentPhotoPath, _PhotoPath, true);
                    MessageBox.Show("Фото обновленно успешно", "Успешно");
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка замены фотографии", "Ошибка");
                }
            }*/
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
                _GroupName + "_" + _SurName + "_" + _Name + "_" + _MiddleName + ".jpg"; 
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK){
                this.currentPhotoPath = openFileDialog1.FileName;
                var picStream = File.OpenRead(this.currentPhotoPath);
                this.photoPictureBox.Image = Image.FromStream(picStream);
                picStream.Close();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string _GroupName = this.groupsComboBox.SelectedItem.ToString();
            string _Name = this.nameTextBox.Text;
            string _MiddleName = this.MidNameTextBox.Text;
            string _SurName = this.surNameTextBox.Text;
            Person anyPerson = new Person(_GroupName, _Name, _MiddleName, _SurName, true);
            if (this.CurrentPerson != null)
            {
                try
                {
                    int res = anyPerson.delete();
                    if (res == 0)
                    {
                        this.clearGUI();
                        this.updatePersonsList();
                        if (anyPerson.PhotoPath != null)
                            File.Delete(anyPerson.PhotoPath);
                        MessageBox.Show("Успешное удаление!", "Успешно!");
                        this.CurrentPerson = null;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Удаление не было завершено! Попробуйте повторить попытку!", "Ошибка!");
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Ошибка! Удаление не было завершено! Попробуйте повторить попытку!", "Ошибка!");
                }
            }
        }
    }
}
