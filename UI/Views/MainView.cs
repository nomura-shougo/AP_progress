using Domain.Entities;
using UI.ViewModels;

namespace UI.Views
{
    public partial class MainView : Form
    {
        private MainViewModel _viewModel = new MainViewModel();
        public MainView()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            BindControls();
            RefreshSolvedDatePlot();
        }

        private void BindControls()
        {
            examYearTextBox.DataBindings.Add(
                nameof(examYearTextBox.Text),
                _viewModel,
                nameof(_viewModel.ExamYearTextBoxText)
                );
            scoreTextBox.DataBindings.Add(
                nameof(scoreTextBox.Text),
                _viewModel,
                nameof(_viewModel.ScoreTextBoxText)
                );
            solvedDateDateTimePicker.DataBindings.Add(
                nameof(solvedDateDateTimePicker.Value),
                _viewModel,
                nameof(_viewModel.SolvedDateDateTimePickerValue)
                );
            haruakiComboBox.DataBindings.Add(
                nameof(haruakiComboBox.DataSource),
                _viewModel,
                nameof(_viewModel.HaruakiComboSource)
                );
            haruakiComboBox.ValueMember = nameof(HaruakiComboModel.Value);
            haruakiComboBox.DisplayMember = nameof(HaruakiComboModel.DisplayValue);

            haruakiComboBox.DataBindings.Add(
                nameof(haruakiComboBox.SelectedValue),
                _viewModel,
                nameof(_viewModel.HaruakiComboBoxSelectedValue),
                false,
                DataSourceUpdateMode.OnPropertyChanged
                );
        }

        private void RefreshSolvedDatePlot()
        {
            ExamResultsFormsPlot.Plot.Clear();

            IReadOnlyList<ExamResultsEntity> examResults =  _viewModel.GetData();
            List<ExamResultsEntity> examResultsList = examResults.ToList();
            var sortedExamResultsList = examResultsList.OrderBy(e => e.SolvedDate.Value);
            List<Double> dataX = new List<Double>();
            List<Double> dataY = new List<Double>();
            foreach(ExamResultsEntity examResult in sortedExamResultsList)
            {
                double solvedDate = examResult.SolvedDate.Value.ToOADate();
                dataX.Add(solvedDate);
                double score = Convert.ToDouble(examResult.Score.Value);
                dataY.Add(score);
            }
            ExamResultsFormsPlot.Plot.Title("AP_Progress");
            ExamResultsFormsPlot.Plot.XLabel("日付");
            ExamResultsFormsPlot.Plot.YLabel("点数");

            ExamResultsFormsPlot.Plot.AddScatter(dataX.ToArray(), dataY.ToArray());
            ExamResultsFormsPlot.Plot.XAxis.DateTimeFormat(true);
            ExamResultsFormsPlot.Plot.Legend();
            ExamResultsFormsPlot.Refresh();
        }

        private void RefreshExamYearPlot()
        {
            ExamResultsFormsPlot.Plot.Clear();

            IReadOnlyList<ExamResultsEntity> examResults = _viewModel.GetData();
            List<ExamResultsEntity> examResultsList = examResults.ToList();
            var sortedExamResultsList =  examResultsList.OrderBy(e => e.ExamYear.Value).ThenBy(e => e.Haruaki.Value);
            List<Double> dataX = new List<Double>();
            List<Double> dataY = new List<Double>();
            foreach (ExamResultsEntity examResult in sortedExamResultsList)
            {
                double examYear = (double)examResult.ExamYear.Value;
                if(examResult.Haruaki.Value == 2)
                {
                    examYear += 0.5;
                }
                dataX.Add(examYear);
                double score = Convert.ToDouble(examResult.Score.Value);
                dataY.Add(score);
            }
            ExamResultsFormsPlot.Plot.Title("AP_Progress");
            ExamResultsFormsPlot.Plot.XLabel("年度");
            ExamResultsFormsPlot.Plot.YLabel("点数");

            ExamResultsFormsPlot.Plot.AddScatter(dataX.ToArray(), dataY.ToArray());
            ExamResultsFormsPlot.Plot.XAxis.DateTimeFormat(false);
            ExamResultsFormsPlot.Plot.Legend();
            ExamResultsFormsPlot.Refresh();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if(Int32.TryParse(_viewModel.ExamYearTextBoxText, out int examYear) == false){
                ViewHelper.InputErrorProc(examYearTextBox, "数字を入力してください");
                return;
            }

            if(Int32.TryParse(_viewModel.ScoreTextBoxText, out int score) == false){
                ViewHelper.InputErrorProc(scoreTextBox, "数字を入力してください");
                return;
            }

            if (score < 0 || score > 100)
            {
                ViewHelper.InputErrorProc(scoreTextBox, "0～100点を入力してください");
                return;
            }

            _viewModel.SaveData();
            RefreshSolvedDatePlot();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            _viewModel.SetFindData();
        }

        private void SolvedDateButton_Click(object sender, EventArgs e)
        {
            RefreshSolvedDatePlot();
        }

        private void ExamYearButton_Click(object sender, EventArgs e)
        {
            RefreshExamYearPlot();
        }
    }
}
