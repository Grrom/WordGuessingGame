using System;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordGuessingGame
{
    public partial class Form1 : Form
    {
        public StringBuilder ActualAnswer = new StringBuilder();
        public ArrayList QuestionList = new ArrayList();

        public int CurrentQuestion = 0;

        public Form1()
        {
            object[] questionList = {
                new WordQuestion("Who Wrote this code", "jerome"),
                new WordQuestion("Describe the guy who wrote this code in one word", "great"),
                new WordQuestion("What language was this written in", "c-sharp"),
                new WordQuestion("Will Jerome get perfect score for this activity", "ofcourse"),
                new WordQuestion("What species are you", "human"),
                new WordQuestion("In what planet do we live in", "earth"),
            };

            for (int i = 0; i < questionList.Length; i++)
            {
                QuestionList.Add(questionList[i]);
            }


            InitializeComponent();
            BuildForm();
        }

        private void BuildForm()
        {
            WordQuestion current = (WordQuestion)QuestionList[CurrentQuestion];
            GenerateOptions(current.Answer);
            SetQuestion(current.Question);
        }

        private void GenerateOptions(string answer)
        {
            int top = 0;
            int left = 290;

            Random num = new Random();
            string options = new string(answer.ToCharArray().
                            OrderBy(s => (num.Next(2) % 2) == 0).ToArray());

            for (int i = 0; i < options.Length; i++)
            {
                string current = options[i].ToString();
                Button button = new Button
                {
                    Left = left,
                    Top = top,
                    Text = current,
                    Height = 30,
                    Width = 30,
                    Font = new Font("Arial", 12),
                };

                button.Click += (s, e) =>
                {
                    ActualAnswer.Append(current);
                    answerLabel.Text = ActualAnswer.ToString();
                };

                optionsPanel.Controls.Add(button);
                left += button.Width + 2;
            }
        }

        private void SetQuestion(string questionText)
        {
            question.Text = questionText;
            question.Text += " ?";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ActualAnswer.Clear();
            answerLabel.Text = ActualAnswer.ToString();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            if (answerLabel.Text == (QuestionList[CurrentQuestion] as WordQuestion).Answer)
            {
                MessageBox.Show("Correct!");
                if (CurrentQuestion < QuestionList.Count - 1) CurrentQuestion++;
                else CurrentQuestion = 0;
                ActualAnswer.Clear();
                answerLabel.Text = ActualAnswer.ToString();
                optionsPanel.Controls.Clear();
                BuildForm();
            }
            else MessageBox.Show("Wrong Answer!");
        }
    }
}
