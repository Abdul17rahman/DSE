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

namespace Questions
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<QuestionBank> _questions;

        private DispatcherTimer _timer;

        private int _questionindex = 0;

        private int _score = 0;

        private int _timeleft;

        public async void ShowMessage(string message, string name)
        {
            var dialogBox = new ContentDialog()
            {
                Content = message,
                Title = name,
                CloseButtonText = "Ok"
            };

            await dialogBox.ShowAsync();
        }
        public MainPage()
        {
            this.InitializeComponent();
            loadQuestions();
            initializeTimer();
            setQuestion();
        }

        private void setQuestion()
        {
            _timer.Stop();

            if (_questionindex < _questions.Count)
            {
                var currentquestion = _questions[_questionindex];

                question_box.Text = currentquestion.Question;

                Option1.Content = currentquestion.Option1;
                Option2.Content = currentquestion.Option2;
                Option3.Content = currentquestion.Option3;
                Option4.Content = currentquestion.Option4;

                score_box.Text = _score.ToString();
                _timeleft = 10;
                timer_box.Text = $"{_timeleft.ToString()} secs";
                _timer.Start();
                
            }
            else
            {
                score_box.Text = $"Quiz ended and your score is {_score.ToString()}.";
                timer_box.Text = "";
                _timer.Stop();
                Option1.IsEnabled = Option2.IsEnabled = Option3.IsEnabled = Option4.IsEnabled = false;

                if (_score >= 10)
                {
                    ShowMessage("Congrats, You passed the test.", "Result");
                }
                else
                {
                    ShowMessage("Sorry, You failed the test.", "Result");
                }
            }
        }

        private void initializeTimer()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            _timeleft--;

            timer_box.Text = _timeleft.ToString();

            if (_timeleft <= 0)
            {
                _timer.Stop();
                _questionindex++;
                setQuestion();
            }
        }

        private void loadQuestions()
        {
            _questions = new List<QuestionBank>()
            {
                new QuestionBank
                {
                    Question = "How many obligatory prayers are in a day?",
                    Option1 = "2",
                    Option2 = "10",
                    Option3 = "5",
                    Option4 = "7",
                    CorrectAns = 3
                },

                new QuestionBank
                {
                    Question = "Who is the first khaliphate?",
                    Option1 = "Abu Bakr",
                    Option2 = "Umar",
                    Option3 = "Ali",
                    Option4 = "Uthuman",
                    CorrectAns = 1
                },

                new QuestionBank
                {
                    Question = "How many rakats does the Fajr prayer have?",
                    Option1 = "3",
                    Option2 = "4",
                    Option3 = "5",
                    Option4 = "2",
                    CorrectAns = 4
                },

                new QuestionBank
                {
                    Question = "How many Juzz are in the Quran?",
                    Option1 = "10",
                    Option2 = "30",
                    Option3 = "15",
                    Option4 = "25",
                    CorrectAns = 2
                }
            };
        }

        private void submit_answer(object sender, RoutedEventArgs e)
        {
            int correctAnswer = -1;

            if (Option1.IsChecked == true) correctAnswer = 1;
            if (Option2.IsChecked == true) correctAnswer = 2;
            if (Option3.IsChecked == true) correctAnswer = 3; 
            if (Option4.IsChecked == true) correctAnswer= 4; 

            var currentquestion = _questions[_questionindex];

            if (correctAnswer == currentquestion.CorrectAns)
            {
                _score += 5;
            }

            _questionindex++;
            setQuestion();

            Option1.IsChecked = Option2.IsChecked = Option3.IsChecked = Option4.IsChecked = false;
        }
    }
}
