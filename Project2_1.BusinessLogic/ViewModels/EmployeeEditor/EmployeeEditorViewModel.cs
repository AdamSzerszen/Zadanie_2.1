using Project2_1.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Project2_1.BusinessLogic.ViewModels.Base;

namespace Project2_1.BusinessLogic.ViewModels.EmployeeEditor
{
  public class EmployeeEditorViewModel : BaseViewModel
  {
    // Private fields -----------------------------------------------------

    private IEmployeeEditorAccess access;
    private string name;
    private string surname;

    // Private methods ----------------------------------------------------

    private void DoCancel()
    {
      access.Close(false);
    }

    private void DoOk()
    {
      access.Close(true);
    }

    // Public methods -----------------------------------------------------

    public EmployeeEditorViewModel(IEmployeeEditorAccess access)
    {
      this.access = access;

      OkCommand = new AppCommand(obj => DoOk());
      CancelCommand = new AppCommand(obj => DoCancel());
    }

    public void SetAccess(IEmployeeEditorAccess editorAccess)
    {
      this.access = editorAccess;
    }

    // Public properties --------------------------------------------------

    public ICommand OkCommand { get; }
    public ICommand CancelCommand { get; }

    public string Name
    {
      get => name;
      set => Set(ref name, value);
    }

    public string Surname
    {
      get => surname;
      set => Set(ref surname, value);
    }
  }
}