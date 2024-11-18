using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Quiz
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<QuestionBank> _questions;

        private int _questionindex = 0;
        private int _score = 0;
        private int _timeleft;
        private DispatcherTimer _timer;

        public MainPage()
        {
            this.InitializeComponent();
            loadQuestion();
            initializeTimer();
            setQuestion();
        }

        private void initializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        public void loadQuestion()
        {
            _questions = new List<QuestionBank>()
            {
                new QuestionBank
                {
                    Question = "Who is the president of USA",
                    Option1 = "Biden",
                    Option2 = "Trump",
                    Option3 = "Obama",
                    Option4 = "Harris",
                    CorrectOption = 2
                },

                new QuestionBank
                {
                    Question = "How many states does USA has?",
                    Option1 = "20",
                    Option2 = "40",
                    Option3 = "55",
                    Option4 = "50",
                    CorrectOption = 4
                },

                new QuestionBank
                {
                    Question = "What is the largest state in USA?",
                    Option1 = "California",
                    Option2 = "Washington",
                    Option3 = "Arizona",
                    Option4 = "Michigan",
                    CorrectOption = 1
                },

                new QuestionBank
                {
                    Question = "How many terms does a US president rule?",
                    Option1 = "4",
                    Option2= "1",
                    Option3 = "2",
                    Option4= "5",
                    CorrectOption = 3
                }
            };
        }

        public void setQuestion()
        {
            _timer.Stop();

            if (_questionindex < _questions.Count)
            {
                var question = _questions[_questionindex];

                question_label.Text = question.Question;

                Option1.Content = question.Option1;
                Option2.Content = question.Option2;
                Option3.Content = question.Option3;
                Option4.Content = question.Option4;

                score_lable.Text = _score.ToString();
                _timeleft = 10;
                timer_box.Text = $"{_timeleft.ToString()} seconds";
                _timer.Start();
            }
            else
            {
                score_lable.Text = $"Quiz is done and your score is {_score.ToString()}.";
                Option1.IsEnabled = Option2.IsEnabled = Option3.IsEnabled = Option4.IsEnabled = false;
                _timer.Stop();
                timer_box.Text = "";
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            _timeleft--;

            timer_box.Text = $"{_timeleft.ToString()} seconds";

            if ( _timeleft <= 0 )
            {
                _timer.Stop();
                _questionindex++;
                setQuestion();
            }
        }

        private void submit_answer(object sender, RoutedEventArgs e)
        {
            int selectedAnswer = -1;

            if (Option1.IsChecked == true) selectedAnswer = 0;
            if (Option2.IsChecked == true) selectedAnswer = 1;
            if (Option3.IsChecked == true) selectedAnswer = 2;
            if (Option4.IsChecked == true) selectedAnswer= 3;

            var currentquestion = _questions[_questionindex];

            if (currentquestion.CorrectOption == selectedAnswer + 1)
            {
                _score += 5;
            }

            _questionindex++;
            setQuestion();

            Option1.IsChecked = Option2.IsChecked = Option3.IsChecked = Option4.IsChecked = false;

        }
    }
}
