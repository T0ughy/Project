using Project_Doctor_Client.DataProviders;
using Project_Doctor_Client.Models;
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

namespace Project_Doctor_Client
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        private Person _person;
        public PersonWindow(Person person)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            if (person != null)
            {
                _person = person;
                FirstNameTextBox.Text = _person.FirstName;
                LastNameTextBox.Text = _person.LastName;
                DateOfArrivalPicker.SelectedDate = _person.DateOfArrival;
                SocialSecurityNumberTextBox.Text = _person.SocialSecurityNumber;
                AddressTextBox.Text = _person.Address;
                SymptomTextBox.Text = _person.Symptom;
                DiagnosisTextBox.Text = _person.Diagnosis;
            }
        }

        private void ModifyPatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidatePerson())
            {
                _person.FirstName = FirstNameTextBox.Text;
                _person.LastName = LastNameTextBox.Text;
                _person.DateOfArrival = DateOfArrivalPicker.SelectedDate.GetValueOrDefault();
                _person.SocialSecurityNumber = SocialSecurityNumberTextBox.Text;
                _person.Address = AddressTextBox.Text;
                _person.Symptom = SymptomTextBox.Text;
                _person.Diagnosis = DiagnosisTextBox.Text;
                _person.LastTimeEdited = DateTime.Now;
                PersonDataProvider.UpdatePerson(_person);
                DialogResult = true;
                Close();
            }
        }

        private void DeletePatientButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete?", "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
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
            if (!NameIsValid(FirstNameTextBox.Text.ToString()) || !NameIsValid(LastNameTextBox.Text.ToString()) || !SocialSecurityNumberIsValid(SocialSecurityNumberTextBox.Text.ToString()))
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
            for (int i = 1; i < name.Length; i++)
            {
                if (!Char.IsLower(name[i]) || !Char.IsLetter(name[i]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool SocialSecurityNumberIsValid(string ssn)
        {
            if (ssn[3] != ' ' || ssn[7] != ' ' || ssn.Length != 11)
            {
                return false;
            }
            for (int i = 0; i < 11; i++)
            {
                if (i == 3 || i == 7)
                {
                    i++;
                }
                if (!Char.IsDigit(ssn[i])){
                    return false;
                }
            }
            return true;
        }
    }
}
