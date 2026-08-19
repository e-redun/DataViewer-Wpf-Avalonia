using Common.Models;
using Common.Services;
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


        public MainWindowModel(
            DataBasesViewModel dataBasesVM,
            TablesViewModel tablesVM,
            TableContentViewModel tableContentVM,
            PropertiesViewModel propertiesVM)
        {
            _dataBasesVM = dataBasesVM;
            _tablesVM = tablesVM;
            _tableContentVM = tableContentVM;
            _propertiesVM = propertiesVM;

            _dataBasesVM.DatabaseChanged += _tablesVM.LoadTablesFromDatabase;
            _tablesVM.TableChanged += _tableContentVM.LoadContentFromTable;
            _tableContentVM.RowChanged += _propertiesVM.LoadProperties;
            
            _dataBasesVM.LoadDatabases();
        }

   

        [RelayCommand]
        private void CloseApplication()
        {
            CloseRequest?.Invoke();
        }

    }
}