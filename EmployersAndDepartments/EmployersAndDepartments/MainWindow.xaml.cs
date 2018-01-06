using System;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployersAndDepartments
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// 
    /// Попытался оставить здесь поменьше логики
    /// </summary>
    public partial class MainWindow : Window
    {
        public CompanyStructure cs = new CompanyStructure();

        public MainWindow()
        {
            InitializeComponent();
            MainPanel.DataContext = cs;
        }

        /// <summary>
        /// Изменение выбора в выпадающем списке подразделений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentViewCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Department curDep = (Department)comboBox.SelectedItem;
            if (curDep != null)
            {
                cs.ChangeDep(curDep.Id);
            }
        }
    }
}
