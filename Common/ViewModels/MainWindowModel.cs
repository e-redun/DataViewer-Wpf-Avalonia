using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class MainWindowModel
    {
        public event Action? RequestClose;

        //[RelayCommand]
        private void CloseApplication()
        {
            // Вместо вызова метода конкретного окна, просто генерируем событие
            RequestClose?.Invoke();
        }

    }
}