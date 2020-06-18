using Project_Assistant_Client.DataProviders;
using Project_Assistant_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Assistant_Client
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        private readonly Person _person;
        public PersonWindow(Person person)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if(person != null)
            {
                Console.WriteLine(FirstNameTextBox.Text);
                _person = person;
                FirstNameTextBox.Text = person.FirstName;
                LastNameTextBox.Text = person.LastName;
                DateOfArrivalPicker.SelectedDate = person.DateOfArrival;
                SocialSecurityNumberTextBox.Text = person.SocialSecurityNumber;
                AddressTextBox.Text = person.Address;
                SymptomTextBox.Text = person.Symptom;

                CreateButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                _person = new Person();
                FirstNameTextBox.Text="First name";
                LastNameTextBox.Text="Last name";
                SocialSecurityNumberTextBox.Text = "XXX XXX XXX";
                AddressTextBox.Text = "Postal code, city, street address";
                SymptomTextBox.Text = "Symptom(s)";
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePerson())
            {
                _person.FirstName = FirstNameTextBox.Text;
                _person.LastName = LastNameTextBox.Text;
                _person.DateOfArrival = DateOfArrivalPicker.SelectedDate.Value;
                _person.SocialSecurityNumber = SocialSecurityNumberTextBox.Text;
                _person.Address = AddressTextBox.Text;
                _person.Symptom = SymptomTextBox.Text;

                PersonDataProvider.CreatePerson(_person);
                DialogResult = true;
                Close();
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePerson())
            {
                _person.FirstName = FirstNameTextBox.Text;
                _person.LastName = LastNameTextBox.Text;
                _person.DateOfArrival = DateOfArrivalPicker.SelectedDate.Value;
                _person.SocialSecurityNumber = SocialSecurityNumberTextBox.Text;
                _person.Address = AddressTextBox.Text;
                _person.Symptom = SymptomTextBox.Text;

                PersonDataProvider.UpdatePerson(_person);
                DialogResult = true;
                Close();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Do you really want to delete?" , "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                PersonDataProvider.DeletePerson(_person.Id);
                DialogResult = true;
                Close();
            }
        }

        private bool ValidatePerson()
        {
            if (string.IsNullOrEmpty(FirstNameTextBox.Text) || FirstNameTextBox.Text.ToString().Equals("First name"))
            {
                MessageBox.Show("First name should not be empty.");
                return false;
            }
            if (string.IsNullOrEmpty(LastNameTextBox.Text) || LastNameTextBox.Text.ToString().Equals("Last name"))
            {
                MessageBox.Show("Last name should not be empty.");
                return false;
            }
            if (!DateOfArrivalPicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a date of arrival.");
                return false;
            }
            if (string.IsNullOrEmpty(SocialSecurityNumberTextBox.Text) || SocialSecurityNumberTextBox.Text.ToString().Equals("XXX XXX XXX"))
            {
                MessageBox.Show("Social security number should not be empty.");
                return false;
            }
            if (string.IsNullOrEmpty(AddressTextBox.Text) || AddressTextBox.Text.ToString().Equals("Postal code, city, street address"))
            {
                MessageBox.Show("Address should not be empty.");
                return false;
            }
            if (string.IsNullOrEmpty(SymptomTextBox.Text) || SymptomTextBox.Text.ToString().Equals("Symptom(s)"))
            {
                MessageBox.Show("Symptom should not be empty.");
                return false;
            }
            if (!NameIsValid(FirstNameTextBox.Text.ToString()) || !NameIsValid(LastNameTextBox.Text.ToString())  || !SocialSecurityNumberIsValid(SocialSecurityNumberTextBox.Text.ToString()))
            {
                return false;
            }
            return true;
        }

        public bool NameIsValid(string name)
        {
            if (!Char.IsUpper(name[0]) || !Char.IsLetter(name[0]))
            {
                return false;
            }
            for(int i=1; i<name.Length; i++)
            {
                if(!Char.IsLower(name[i]) || !Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool SocialSecurityNumberIsValid(string ssn)
        {
            if(ssn[3]!=' ' || ssn[7]!=' ' || ssn.Length!=11)
            {
                return false;
            }
            for(int i=0; i<11; i++)
            {
                if(i==3 || i == 7)
                {
                    i++;
                }
                if (!Char.IsDigit(ssn[i)){
                    return false;
                }
            }
            return true;
        }

        private void FirstNameTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (FirstNameTextBox.Text == "First name")
            {
                FirstNameTextBox.Text = "";
                FirstNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void FirstNameTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (FirstNameTextBox.Text == "")
            {
                FirstNameTextBox.Text = "First name";
                FirstNameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void LastNameTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (LastNameTextBox.Text == "Last name")
            {
                LastNameTextBox.Text = "";
                LastNameTextBox.Foreground = Brushes.Black;
            }
        }

        private void LastNameTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (LastNameTextBox.Text == "")
            {
                LastNameTextBox.Text = "Last name";
                LastNameTextBox.Foreground = Brushes.Gray;
            }
        }

        private void SocialSecurityNumberTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (SocialSecurityNumberTextBox.Text == "XXX XXX XXX")
            {
                SocialSecurityNumberTextBox.Text = "";
                SocialSecurityNumberTextBox.Foreground = Brushes.Black;
            }
        }

        private void SocialSecurityNumberTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (SocialSecurityNumberTextBox.Text == "")
            {
                SocialSecurityNumberTextBox.Text = "XXX XXX XXX";
                SocialSecurityNumberTextBox.Foreground = Brushes.Gray;
            }
        }

        private void AddressTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (AddressTextBox.Text == "Postal code, city, street address")
            {
                AddressTextBox.Text = "";
                AddressTextBox.Foreground = Brushes.Black;
            }
        }

        private void AddressTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (AddressTextBox.Text == "")
            {
                AddressTextBox.Text = "Postal code, city, street address";
                AddressTextBox.Foreground = Brushes.Gray;
            }
        }

        private void SymptomTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            if (SymptomTextBox.Text == "Symptom(s)")
            {
                SymptomTextBox.Text = "";
                SymptomTextBox.Foreground = Brushes.Black;
            }
        }

        private void SymptomTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            if (SymptomTextBox.Text == "")
            {
                SymptomTextBox.Text = "Symptom(s)";
                SymptomTextBox.Foreground = Brushes.Gray;
            }
        }
    }
}
