using Schedule.Data.CRUDCabinet;
using Schedule.Infrastructure.Commands;
using Schedule.ViewModel.Base;
using System.Windows.Input;

namespace Schedule.ViewModel.ViewModelCabinetType
{
    internal class ViewModelCreateCabinet : TitleViewModel
    {
        private string _cabinetName;
        private string _description;
        private readonly CRUDCabinetType _CRUDCabinetType = new();

        public string CabinetName
        {
            get => _cabinetName;
            set => Set(ref _cabinetName, value);
        }

        public string Description
        {
            get => _description;
            set => Set(ref _description, value);
        }

        private LambdaCommand _createCabinetType;
        public ICommand CreateCabinetType => _createCabinetType ??= new(_createCabinetTypeExecuted);
        public void _createCabinetTypeExecuted()
        {
            _ = _CRUDCabinetType.CreateCabinetType(CabinetName, Description);
        }

        public ViewModelCreateCabinet()
        {
            Title = "Создать кабинет";
        }
    }
}
