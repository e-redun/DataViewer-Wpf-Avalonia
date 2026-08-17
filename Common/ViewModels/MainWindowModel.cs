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

        [ObservableProperty]
        private TablesViewModel _tablesVM;

        [ObservableProperty]
        private TableContentViewModel _tableContentVM;

        [ObservableProperty]
        private PropertiesViewModel _propertiesVM;

        public MainWindowModel()
        {
            InitViewModels();
        }
        private void InitViewModels()
        {
            _dataBasesVM = new DataBasesViewModel();
            _tablesVM = new TablesViewModel();
            _tableContentVM = new TableContentViewModel();
            _propertiesVM = new PropertiesViewModel();
        }


        [RelayCommand]
        private void CloseApplication()
        {
            CloseRequest?.Invoke();
        }

    }
}