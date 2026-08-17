using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class TablesViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Таблицы";

        public ObservableCollection<string> Tables { get; set; } = new();

        internal void Clear()
        {
            Tables.Clear();
        }

        internal void LoadTables(List<string> tables)
        {
            Tables.Clear();

            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
    }
}