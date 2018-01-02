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

namespace EmployersAndDepartments
{
    /// <summary>
    /// Логика взаимодействия для AddEmployer.xaml
    /// </summary>
    public partial class AddEmployer : Window
    {
        public Employer newEmp;
        public AddEmployer()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //newEmp = new Employer(newEmpLastName.Text, newEmpName.Text, newEmpSecondName.Text, Int32.Parse(newEmpAge.Text), Int32.Parse(newEmpSalary.Text), newEmpDepId.Text);
            this.DialogResult = true;
            this.Close();
        }
    }
}
