using Project2_1.BusinessLogic.ViewModels.EmployeeEditor;
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
using Unity;
using Unity.Resolution;

namespace Project2_1.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeEditor.xaml
    /// </summary>
    public partial class EmployeeEditorWindow : Window, IEmployeeEditorAccess
    {
        private readonly EmployeeEditorViewModel viewModel;

        public EmployeeEditorWindow(EmployeeEditorViewModel employeeEditorViewModel)
        {
            InitializeComponent();

            viewModel = employeeEditorViewModel;
            DataContext = viewModel;
            employeeEditorViewModel.SetAccess(this);
        }

        public void Close(bool result)
        {
            DialogResult = result;
            Close();
        }
    }
}
