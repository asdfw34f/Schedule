using Schedule.Data.CRUDCabinet;
using Schedule.Infrastructure.Commands;
using Schedule.Models;
using Schedule.ViewModel.Base;
using System.Windows.Input;

namespace Schedule.ViewModel.ViewModelCabinetType
{
    internal class ViewModelUpdateCabinet : TitleViewModel
    {
        public CabinetType CabinetSelectedTabItem { get; set; }
        private readonly CRUDCabinetType _CRUDCabinetType = new();

        private LambdaCommand _updateCabinetType;
        public ICommand UpdateCabinetType => _updateCabinetType ??= new(_updateCabinetTypeExecuted);
        public void _updateCabinetTypeExecuted()
        {
            _ = _CRUDCabinetType.UpdateCabinetType(CabinetSelectedTabItem);
        }

        public ViewModelUpdateCabinet()
        {
            Title = "Создать кабинет";
            CabinetSelectedTabItem = MainWindowViewModel.SelectedCabinetType;
        }
    }
}
