using Common.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class TableContentViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Таблица " + _tableData?.Name;


        [ObservableProperty] 
        private TableModel? _tableData;

        [ObservableProperty]
        public ObservableCollection<RowModel> Rows { get; set; } = new();


        internal void LoadContent(TableModel content)
        {
            TableData = content;
            Rows.Clear();
        
            foreach (var row in content.Rows)
            {
                Rows.Add(row);
            }

            OnPropertyChanged(nameof(Header));
        }

        internal void Clear()
        {
            TableData = null;
            Rows.Clear();
        }
    }
}