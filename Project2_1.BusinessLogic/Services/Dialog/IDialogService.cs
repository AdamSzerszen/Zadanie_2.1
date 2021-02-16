using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2_1.BusinessLogic.ViewModels.EmployeeEditor;

namespace Project2_1.BusinessLogic.Services.Dialog
{
    public interface IDialogService
    {
        bool ShowEmployeeDialog(EmployeeEditorViewModel employeeEditorViewModel);
    }
}
