using Domain.Entities;
using Domain.Repositories;
using Domain.ValueObjects;
using Infrastructure.MariaDB;
using System.ComponentModel;

namespace UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IExamResultsRepository _examResultsRepository;

        private string _examYearTextBoxText = string.Empty;
        public string ExamYearTextBoxText
        {
            get { return _examYearTextBoxText; }
            set
            {
                SetProperty(ref _examYearTextBoxText, value);
            }
        }

        private string _scoreTextBoxText = string.Empty;
        public string ScoreTextBoxText
        {
            get { return _scoreTextBoxText; }
            set
            {
                SetProperty(ref _scoreTextBoxText, value);
            }
        }
        private DateTime _solvedDateDateTimePickerValue = DateTime.Today;
        public DateTime SolvedDateDateTimePickerValue
        {
            get { return _solvedDateDateTimePickerValue; }
            set
            {
                SetProperty(ref _solvedDateDateTimePickerValue, value);
            }
        }

        public BindingList<HaruakiComboModel> HaruakiComboSource { get; set; }

        private object _haruakiComboBoxSelectedValue = 1;
        public object HaruakiComboBoxSelectedValue
        {
            get { return _haruakiComboBoxSelectedValue; }
            set
            {
                SetProperty(ref _haruakiComboBoxSelectedValue, value);
            }
        }


        public MainViewModel()
            : this(new ExamResultsMariaDB())
        {
        }

        public MainViewModel(
            IExamResultsRepository examResults)
        {
            _examResultsRepository = examResults;
            HaruakiComboSource = new BindingList<HaruakiComboModel>();
            InitializeHaruakiComboSource();
        }

        void InitializeHaruakiComboSource()
        {
            foreach (Haruaki haruaki in Haruaki.GetAll())
            {
                HaruakiComboSource.Add(new HaruakiComboModel(haruaki.Value, haruaki.DisplayValue));
            }
        }

        internal IReadOnlyList<ExamResultsEntity> GetData()
        {
            return _examResultsRepository.GetData();
        }

        public void SetFindData()
        {
            if (ExamYearTextBoxText == string.Empty)
            {
                return;
            }

            int.TryParse(ExamYearTextBoxText, out int examYear);

            ExamResultsEntity? entity = _examResultsRepository.GetSingleData(
                    new ExamResultsEntity(
                            examYear,
                            (int)HaruakiComboBoxSelectedValue,
                            SolvedDateDateTimePickerValue,
                            0
                        )
                );
            if(entity is null)
            {
                return;
            }

            ScoreTextBoxText = Convert.ToString(entity.Score.Value) ?? string.Empty;
        }

        public void SaveData()
        {
            int.TryParse(ExamYearTextBoxText, out int examYear);
            int.TryParse(ScoreTextBoxText, out int score);
            _examResultsRepository.Save(
                new ExamResultsEntity(
                    examYear,
                    Convert.ToInt32(HaruakiComboBoxSelectedValue),
                    SolvedDateDateTimePickerValue,
                    score
                    )
                );
        }
    }
}
