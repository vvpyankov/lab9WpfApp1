using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab9zadachaWpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("LightTheme.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("DarkTheme.xaml", UriKind.Relative);
            ResourceDictionary resource = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);
        }


        #region Обработчики текста

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = (sender as ComboBox).SelectedItem as String;
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontHeight = Convert.ToDouble((sender as ComboBox).SelectedItem as String);
            if (textBox != null)
                textBox.FontSize = fontHeight;
        }

        #endregion

        #region Обработчики ToolBar "Кнопки"

        bool isBold;
        bool isItalic;
        bool isDecoration;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isBold)
                textBox.FontWeight = FontWeights.Bold;
            else
                textBox.FontWeight = FontWeights.Normal;
            isBold = !isBold;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isItalic)
                textBox.FontStyle = FontStyles.Italic;
            else
                textBox.FontStyle = FontStyles.Normal;
            isItalic = !isItalic;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (!isDecoration)
                textBox.TextDecorations = TextDecorations.Underline;
            else
                textBox.TextDecorations = null;
            isDecoration = !isDecoration;
        }

        #endregion

        #region Обработчики "Радиокнопки"

        private void radio1_Click(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Black;
        }

        private void radio2_Click(object sender, RoutedEventArgs e)
        {
            textBox.Foreground = Brushes.Red;
        }

        #endregion

        private void OpenExecute(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All types(*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecute(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All types (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, textBox.Text);
            }
        }

        private void CloseExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
