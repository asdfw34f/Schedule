using ClosedXML.Excel;
using Schedule.Data.CRUDCabinet;
using Schedule.Infrastructure.Commands;
using Schedule.Models;
using Schedule.View.ViewCabinetTypeCRUDOperation;
using Schedule.ViewModel.Base;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Controls;
using System.Windows.Input;
using Day = Schedule.Models.Day;

namespace Schedule.ViewModel
{
    internal class MainWindowViewModel : TitleViewModel
    {
        private readonly CRUDCabinet CRUDCabinet = new();
        private readonly CRUDCabinetType CRUDCabinetType = new();
        private readonly CRUDDay CRUDDay = new();
        private readonly CRUDGroup CRUDGroup = new();
        private readonly CRUDLesson CRUDLesson = new();
        private readonly CRUDLessonNumber CRUDLessonNumber = new();
        private readonly CRUDSemester CRUDSemester = new();
        private readonly CRUDSubject CRUDSubject = new();
        private readonly CRUDTeacher CRUDTeacher = new();
        private readonly CRUDWeek CRUDWeek = new();
        private readonly CRUDWeekday CRUDWeekday = new();

        private ObservableCollection<Cabinet> _cabinets;
        private ObservableCollection<CabinetType> _cabinetTypes;
        private ObservableCollection<Day> _days;
        private ObservableCollection<Group> _groups;
        private ObservableCollection<Lesson> _lessons;
        private ObservableCollection<LessonNumber> _lessonNumbers;
        private ObservableCollection<Semester> _semesters;
        private ObservableCollection<Subject> _subjects;
        private ObservableCollection<Teacher> _teachers;
        private ObservableCollection<Week> _weeks;
        private ObservableCollection<Weekday> _weekdays;
        public ObservableCollection<Cabinet> Cabinets
        {
            get => _cabinets;
            set => Set(ref _cabinets, value);
        }

        public ObservableCollection<CabinetType> CabinetTypes
        {
            get => _cabinetTypes;
            set => Set(ref _cabinetTypes, value);
        }

        public ObservableCollection<Day> Days
        {
            get => _days;
            set => Set(ref _days, value);
        }

        public ObservableCollection<Group> Groups
        {
            get => _groups;
            set => Set(ref _groups, value);
        }

        public ObservableCollection<Lesson> Lessons
        {
            get => _lessons;
            set => Set(ref _lessons, value);
        }

        public ObservableCollection<LessonNumber> LessonNumbers
        {
            get => _lessonNumbers;
            set => Set(ref _lessonNumbers, value);
        }

        public ObservableCollection<Semester> Semesters
        {
            get => _semesters;
            set => Set(ref _semesters, value);
        }

        public ObservableCollection<Subject> Subjects
        {
            get => _subjects;
            set => Set(ref _subjects, value);
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => _teachers;
            set => Set(ref _teachers, value);
        }

        public ObservableCollection<Week> Weeks
        {
            get => _weeks;
            set => Set(ref _weeks, value);
        }

        public ObservableCollection<Weekday> Weekdays
        {
            get => _weekdays;
            set => Set(ref _weekdays, value);
        }

        public TabItem SelectedTabItem { get; set; }

        public static Cabinet SelectedCabinet { get; set; }
        public static CabinetType SelectedCabinetType { get; set; }
        public static Day SelectedDay { get; set; }
        public static Group SelectedGroup { get; set; }
        public static Lesson SelectedLesson { get; set; }
        public static LessonNumber SelectedLessonNumber { get; set; }
        public static Semester SelectedSemester { get; set; }
        public static Subject SelectedSubject { get; set; }
        public static Teacher SelectedTeacher { get; set; }
        public static Week SelectedWeek { get; set; }
        public static Weekday SelectedWeekday { get; set; }

        private LambdaCommand? _deleteItem;
        public ICommand DeleteItem => _deleteItem ??= new(_deleteItemCommandExecuted);

        public void _deleteItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "CabinetTab" && SelectedCabinet != null)
            {
                _ = CRUDCabinet.DeleteCabinet(SelectedCabinet);
                Cabinets = CRUDCabinet.ReadCabinet();
            }
            if (SelectedTabItem.Name == "CabinetTypeTab" && SelectedCabinetType != null)
            {
                _ = CRUDCabinetType.DeleteCabinetType(SelectedCabinetType);
                CabinetTypes = CRUDCabinetType.ReadCabinetType();
            }
            if (SelectedTabItem.Name == "DayTab" && SelectedDay != null)
            {
                _ = CRUDDay.DeleteDay(SelectedDay);
                Days = CRUDDay.ReadDay();
            }
            if (SelectedTabItem.Name == "GroupTab" && SelectedGroup != null)
            {
                _ = CRUDGroup.DeleteGroup(SelectedGroup);
                Groups = CRUDGroup.ReadGroup();
            }
            if (SelectedTabItem.Name == "LessonTab" && SelectedLesson != null)
            {
                _ = CRUDLesson.DeleteLesson(SelectedLesson);
                Lessons = CRUDLesson.ReadLesson();
            }
            if (SelectedTabItem.Name == "LessonNumberTab" && SelectedLessonNumber != null)
            {
                _ = CRUDLessonNumber.DeleteLessonNumber(SelectedLessonNumber);
                LessonNumbers = CRUDLessonNumber.ReadLessonNumber();
            }
            if (SelectedTabItem.Name == "SemesterTab" && SelectedSemester != null)
            {
                _ = CRUDSemester.DeleteSemester(SelectedSemester);
                Semesters = CRUDSemester.ReadSemester();
            }
            if (SelectedTabItem.Name == "SubjectTab" && SelectedSubject != null)
            {
                _ = CRUDSubject.DeleteSubject(SelectedSubject);
                Subjects = CRUDSubject.ReadSubject();
            }
            if (SelectedTabItem.Name == "TeacherTab" && SelectedTeacher != null)
            {
                _ = CRUDTeacher.DeleteTeacher(SelectedTeacher);
                Teachers = CRUDTeacher.ReadTeacher();
            }
            if (SelectedTabItem.Name == "WeekTab" && SelectedWeek != null)
            {
                _ = CRUDWeek.DeleteWeek(SelectedWeek);
                Weeks = CRUDWeek.ReadWeek();
            }
            if (SelectedTabItem.Name == "WeekdayTab" && SelectedWeekday != null)
            {
                _ = CRUDWeekday.DeleteWeekday(SelectedWeekday);
                Weekdays = CRUDWeekday.ReadWeekday();
            }
        }

        private LambdaCommand? _openCreateCabinetCommand;
        public ICommand OpenCreateCabinetCommand => _openCreateCabinetCommand ??= new(_onOpenCreateCabinetCommandExecuted);
        private void _onOpenCreateCabinetCommandExecuted()
        {
            CreateCabinetTypeWindow createCabinetTypeWindow = new();
            _ = createCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _openCreateCabinetTypeCommand;
        public ICommand OpenCreateCabinetTypeCommand => _openCreateCabinetTypeCommand ??= new(_onOpenCreateCabinetTypeCommandExecuted);
        private void _onOpenCreateCabinetTypeCommandExecuted()
        {
            CreateCabinetTypeWindow createCabinetTypeWindow = new();
            _ = createCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _openUpdateCabinetCommand;
        public ICommand OpenUpdateCabinetCommand => _openUpdateCabinetCommand ??= new(_onOpenUpdateCabinetCommandExecuted);
        private void _onOpenUpdateCabinetCommandExecuted()
        {
            UpdateCabinetTypeWindow updateCabinetTypeWindow = new();
            _ = updateCabinetTypeWindow.ShowDialog();
        }

        private LambdaCommand? _updateItem;
        public ICommand UpdateItem => _updateItem ??= new(_updateItemCommandExecuted);

        public void _updateItemCommandExecuted()
        {
            if (SelectedTabItem.Name == "CabinetTab" && SelectedCabinet != null)
            {
                UpdateCabinetTypeWindow updateCabinetTypeWindow = new();
                _ = updateCabinetTypeWindow.ShowDialog();
            }
            if (SelectedTabItem.Name == "CabinetTypeTab" && SelectedCabinetType != null)
            {
                UpdateCabinetTypeWindow updateCabinetTypeWindow = new();
                _ = updateCabinetTypeWindow.ShowDialog();
            }
        }

        private LambdaCommand? _exportExcelCabinetType;
        public ICommand ExportExcelCabinetType => _exportExcelCabinetType ??= new(ExportExcelCabinetTypeCommandExecuted);


        public void ExportExcelCabinetTypeCommandExecuted()
        {
            ObservableCollection<CabinetType> data = CRUDCabinetType.ReadCabinetType();
            string path = Path.Combine(Environment.CurrentDirectory, "Export", "cabinetType.xlsx");
            //var rows = data.Select(c => $"{c.CabinetName},{c.Discription}");
            //File.WriteAllLines(path, rows);

            XLWorkbook wb = new();
            IXLWorksheet sh = wb.Worksheets.Add("CabinetType.ru");
            for (int i = 0; i < data.Count(); i++)
            {
                _ = sh.Cell(i + 1, 1).SetValue(data.ElementAt(i).CabinetName);
                _ = sh.Cell(i + 1, 2).SetValue(data.ElementAt(i).Discription);
            }
            wb.SaveAs(path);
        }
        public MainWindowViewModel()
        {
            Title = "Главное окно";
            Cabinets = new ObservableCollection<Cabinet>(CRUDCabinet.ReadCabinet());
            CabinetTypes = new ObservableCollection<CabinetType>(CRUDCabinetType.ReadCabinetType());
            Days = new ObservableCollection<Day>(CRUDDay.ReadDay());
            Groups = new ObservableCollection<Group>(CRUDGroup.ReadGroup());
            Lessons = new ObservableCollection<Lesson>(CRUDLesson.ReadLesson());
            LessonNumbers = new ObservableCollection<LessonNumber>(CRUDLessonNumber.ReadLessonNumber());
            Semesters = new ObservableCollection<Semester>(CRUDSemester.ReadSemester());
            Subjects = new ObservableCollection<Subject>(CRUDSubject.ReadSubject());
            Teachers = new ObservableCollection<Teacher>(CRUDTeacher.ReadTeacher());
            Weeks = new ObservableCollection<Week>(CRUDWeek.ReadWeek());
            Weekdays = new ObservableCollection<Weekday>(CRUDWeekday.ReadWeekday());
        }
    }
}
