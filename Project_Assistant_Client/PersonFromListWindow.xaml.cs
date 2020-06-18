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
    /// Interaction logic for PersonFromListWindow.xaml
    /// </summary>
    public partial class PersonFromListWindow : Window
    {
        public PersonFromListWindow(Person person)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            FirstNameLabel.Content = person.FirstName;
            LastNameLabel.Content = person.LastName;
            DateOfArrivalLabel.Content = person.DateOfArrival;
            SocialSecurityNumberLabel.Content = person.SocialSecurityNumber;
            AddressLabel.Content = person.Address;
            SymptomLabel.Content = person.Symptom;
        }
    }
}
