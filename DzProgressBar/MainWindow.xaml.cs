using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DancingProgressBars
{
    public partial class MainWindow : Window
    {
        private Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberOfBarsTextBox.Text, out int numberOfBars))
            {
                ProgressBarStackPanel.Children.Clear();

                for (int i = 0; i < numberOfBars; i++)
                {
                    ProgressBar progressBar = new ProgressBar();
                    progressBar.Height = 25;
                    progressBar.Margin = new Thickness(5);
                    ProgressBarStackPanel.Children.Add(progressBar);

                    Thread thread = new Thread(() =>
                    {
                        for (int j = 0; j <= 100; j++)
                        {
                            Dispatcher.Invoke(() =>
                            {
                                progressBar.Value = j;
                                progressBar.Foreground = new SolidColorBrush(Color.FromRgb((byte)_random.Next(256), (byte)_random.Next(256), (byte)_random.Next(256)));
                            });
                            Thread.Sleep(_random.Next(10, 100));
                        }
                    });
                    thread.Start();
                }
            }
        }
    }
}