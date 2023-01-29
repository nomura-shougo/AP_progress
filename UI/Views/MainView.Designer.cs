namespace UI.Views
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.examYearTextBox = new System.Windows.Forms.TextBox();
            this.scoreTextBox = new System.Windows.Forms.TextBox();
            this.solvedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.haruakiComboBox = new System.Windows.Forms.ComboBox();
            this.registerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.examDateLabel = new System.Windows.Forms.Label();
            this.ExamResultsFormsPlot = new ScottPlot.FormsPlot();
            this.findButton = new System.Windows.Forms.Button();
            this.ExamYearButton = new System.Windows.Forms.Button();
            this.SolvedDateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // examYearTextBox
            // 
            this.examYearTextBox.Location = new System.Drawing.Point(138, 78);
            this.examYearTextBox.MaxLength = 4;
            this.examYearTextBox.Name = "examYearTextBox";
            this.examYearTextBox.Size = new System.Drawing.Size(113, 39);
            this.examYearTextBox.TabIndex = 0;
            // 
            // scoreTextBox
            // 
            this.scoreTextBox.Location = new System.Drawing.Point(381, 79);
            this.scoreTextBox.MaxLength = 3;
            this.scoreTextBox.Name = "scoreTextBox";
            this.scoreTextBox.Size = new System.Drawing.Size(67, 39);
            this.scoreTextBox.TabIndex = 1;
            // 
            // solvedDateDateTimePicker
            // 
            this.solvedDateDateTimePicker.Location = new System.Drawing.Point(467, 79);
            this.solvedDateDateTimePicker.Name = "solvedDateDateTimePicker";
            this.solvedDateDateTimePicker.Size = new System.Drawing.Size(254, 39);
            this.solvedDateDateTimePicker.TabIndex = 2;
            // 
            // haruakiComboBox
            // 
            this.haruakiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.haruakiComboBox.FormattingEnabled = true;
            this.haruakiComboBox.Location = new System.Drawing.Point(274, 78);
            this.haruakiComboBox.Name = "haruakiComboBox";
            this.haruakiComboBox.Size = new System.Drawing.Size(78, 40);
            this.haruakiComboBox.TabIndex = 3;
            // 
            // registerButton
            // 
            this.registerButton.Location = new System.Drawing.Point(747, 76);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(107, 45);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "登録";
            this.registerButton.UseVisualStyleBackColor = true;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "年";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "春秋";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(381, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "点数";
            // 
            // examDateLabel
            // 
            this.examDateLabel.AutoSize = true;
            this.examDateLabel.Location = new System.Drawing.Point(467, 44);
            this.examDateLabel.Name = "examDateLabel";
            this.examDateLabel.Size = new System.Drawing.Size(101, 32);
            this.examDateLabel.TabIndex = 8;
            this.examDateLabel.Text = "解いた日";
            // 
            // ExamResultsFormsPlot
            // 
            this.ExamResultsFormsPlot.Location = new System.Drawing.Point(78, 182);
            this.ExamResultsFormsPlot.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.ExamResultsFormsPlot.Name = "ExamResultsFormsPlot";
            this.ExamResultsFormsPlot.Size = new System.Drawing.Size(929, 512);
            this.ExamResultsFormsPlot.TabIndex = 9;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(747, 138);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(107, 45);
            this.findButton.TabIndex = 10;
            this.findButton.Text = "呼び出し";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // 
            // ExamYearButton
            // 
            this.ExamYearButton.Location = new System.Drawing.Point(257, 150);
            this.ExamYearButton.Name = "ExamYearButton";
            this.ExamYearButton.Size = new System.Drawing.Size(107, 45);
            this.ExamYearButton.TabIndex = 11;
            this.ExamYearButton.Text = "年度別";
            this.ExamYearButton.UseVisualStyleBackColor = true;
            this.ExamYearButton.Click += new System.EventHandler(this.ExamYearButton_Click);
            // 
            // SolvedDateButton
            // 
            this.SolvedDateButton.Location = new System.Drawing.Point(138, 150);
            this.SolvedDateButton.Name = "SolvedDateButton";
            this.SolvedDateButton.Size = new System.Drawing.Size(104, 45);
            this.SolvedDateButton.TabIndex = 12;
            this.SolvedDateButton.Text = "日付別";
            this.SolvedDateButton.UseVisualStyleBackColor = true;
            this.SolvedDateButton.Click += new System.EventHandler(this.SolvedDateButton_Click);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 735);
            this.Controls.Add(this.SolvedDateButton);
            this.Controls.Add(this.ExamYearButton);
            this.Controls.Add(this.findButton);
            this.Controls.Add(this.ExamResultsFormsPlot);
            this.Controls.Add(this.examDateLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.haruakiComboBox);
            this.Controls.Add(this.solvedDateDateTimePicker);
            this.Controls.Add(this.scoreTextBox);
            this.Controls.Add(this.examYearTextBox);
            this.Name = "MainView";
            this.Text = "MainView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox examYearTextBox;
        private TextBox scoreTextBox;
        private DateTimePicker solvedDateDateTimePicker;
        private ComboBox haruakiComboBox;
        private Button registerButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label examDateLabel;
        private ScottPlot.FormsPlot ExamResultsFormsPlot;
        private Button findButton;
        private Button ExamYearButton;
        private Button SolvedDateButton;
    }
}