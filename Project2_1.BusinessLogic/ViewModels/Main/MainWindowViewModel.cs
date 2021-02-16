using Project2_1.BusinessLogic.ViewModels.Base;
using Project2_1.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project2_1.BusinessLogic.Models;
using Project2_1.BusinessLogic.Services.Dialog;
using Project2_1.BusinessLogic.ViewModels.EmployeeEditor;
using Unity;
using Container = Project2_1.Dependencies.Container;

namespace Project2_1.BusinessLogic.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Private fields -----------------------------------------------------

        private readonly IMainWindowAccess access;
        private readonly IDialogService dialogService;

        // Private methods ----------------------------------------------------

        private void DoDeleteEmployee()
        {
            var selectedElement = SelectedEmployee;
            SelectedEmployee = null;
            Employees.Remove(selectedElement);
        }

        private void DoEditEmployee()
        {
            var selectedEmployee = SelectedEmployee;
            dialogService.ShowEmployeeDialog(selectedEmployee);
        }

        private void DoAddEmployee()
        {
            EmployeeEditorViewModel newEmployee = new EmployeeEditorViewModel(null);
            bool employeeAccepted = dialogService.ShowEmployeeDialog(newEmployee);
            if (!employeeAccepted)
            {
                return;
            }

            Employees.Add(newEmployee);
        }

        // Public methods -----------------------------------------------------

        public MainWindowViewModel(IMainWindowAccess access)
        {
            this.access = access;
            this.dialogService = Container.Instance.Resolve<IDialogService>();
            
            this.AddCommand = new AppCommand(obj => DoAddEmployee());
            this.EditCommand = new AppCommand(obj => DoEditEmployee());
            this.DeleteCommand = new AppCommand(obj => DoDeleteEmployee());

            Employees = new ObservableCollection<EmployeeEditorViewModel>();
        }

        // Public properties --------------------------------------------------

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public ObservableCollection<EmployeeEditorViewModel> Employees { get; set; }
        public EmployeeEditorViewModel SelectedEmployee { get; set; }
    }
}
