using Project2_1.BusinessLogic.Services.Dialog;
using Project2_1.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2_1.BusinessLogic.ViewModels.EmployeeEditor;

namespace Project2_1.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public bool ShowEmployeeDialog(EmployeeEditorViewModel employeeEditorViewModel)
        {
            var window = new EmployeeEditorWindow(employeeEditorViewModel);
            var result = window.ShowDialog();
            if (result == true)
            {
                return true;
            }

            return false;
        }
    }
}
