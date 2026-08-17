using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class MainWindowModel : ObservableObject
    {
        public event Action? CloseRequest;

        [ObservableProperty]
        private DataBasesViewModel _dataBasesVM;

        public MainWindowModel()
        {
            InitViewModels();
        }
        private void InitViewModels()
        {
            _dataBasesVM = new DataBasesViewModel();
        }


        [RelayCommand]
        private void CloseApplication()
        {
            CloseRequest?.Invoke();
        }

    }
}