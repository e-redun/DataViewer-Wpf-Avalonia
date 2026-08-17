using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
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
    }
}