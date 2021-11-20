using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WordGuessingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WordQuestion x = new WordQuestion("Who Wrote this code?", "jerome");

            GenerateOptions(x.Answer);
            SetQuestion(x.Question);
        }

        private void GenerateOptions(string answer)
        {
            int top = 160;
            int left = 50;

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
                    answerLabel.Text += current;
                };

                Controls.Add(button);
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
            answerLabel.Text = "";
        }

        private void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}
