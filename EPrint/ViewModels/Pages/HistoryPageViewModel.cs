using EPrint.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPrint.ViewModels.Pages
{
    public class HistoryPageViewModel : ViewModelBase, IIconChange
    {
        #region Properties
        bool isSelected;
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (SetProperty(ref isSelected, value))
                {
                    OnPropertyChanged(nameof(CurrentIcon));
                    OnPropertyChanged(nameof(CurrentTitle));
                }

            }
        }

        public string CurrentTitle
        {
            get => IsSelected ? "Historial" : "";
        }
        public string CurrentIcon
        {
            get => IsSelected ? "historySelected.png" : "history.png";
        }
        #endregion

    }
}
