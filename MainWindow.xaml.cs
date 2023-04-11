using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using Path = System.IO.Path;

namespace SearchText
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string GPSFail;
            int Number1 =0,Number2;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenFail_Click(object sender, RoutedEventArgs e)
        {
            OpenFail();
        }
        public void OpenFail()
        {
            TxtBlInfo.Text = null;
            GPSFail = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                // TxtBlNamefail.Text = openFileDialog.FileName;
                // string name = Path.GetFileName(TxtBlNamefail.Text);
                GPSFail = Path.GetFullPath(openFileDialog.FileName);
                 TxtBlNamefail.Text = (Path.GetFileName(openFileDialog.FileName));
                //  TxtBlNamefail.Text = openFileDialog.FileName;
                // TxtBlNamefail.Text = File.ReadAllText(openFileDialog.FileName);//Текс файла
                //TxtBlNamefail.Text = name;
               // MessageBox.Show(GPSFail);
                ReadIfnoTextAsync();                
                FocusManager.SetFocusedElement(this, TxtBxNumber1);
                TxtBxNumber1.Text = "1";
                TxtBxNumber2.Text = "1";
            }
           
        }

        public void  ReadIfnoTextAsync()
        {

            using (StreamReader reader = new StreamReader(GPSFail))
            {
                // string line;
                //while ((line = reader.ReadLine()) != null)
                //{
                //    while ((line = reader.ReadLine()) != null)
                //    {
                //        TxtBlInfo.Text = line;
                //    }
                //}
                //String line;
                //int i = 0;
                //for (int j = 0; j < 3; j++)
                //{
                //    while ((line = reader.ReadLine()) != null) //читаем по одной линии(строке) пока не вычитаем все из потока (пока не достигнем конца файла)
                //    {

                //        TxtBlInfo.Text += line + Environment.NewLine;
                //        i++;
                //    }
                //}
                string[] lines = File.ReadAllLines(GPSFail);
                for (int i = 0; i < lines.Length;)
                {
                    string text = lines[i];
                    //*** Какой-то код ***
                    if (i < 3)
                    {
                        TxtBlInfo.Text += text + Environment.NewLine;
                    } 
                    //if (i > 5)
                    //{
                    //    if (i<lines.Length)
                    //    TxtBlOutInfo.Text += text + Environment.NewLine;
                    //}
                    //i = 19; //Вернуться на 20 строку и начать считать снова  с неё
                    i++; // Переход на следующую строку

                }

            }
        }        
    }
}
