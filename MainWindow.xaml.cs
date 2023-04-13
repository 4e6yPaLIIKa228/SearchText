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
            //TestRead();
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
                //ReadIfnoTextAsync();                
                FocusManager.SetFocusedElement(this, TxtBxNumber1);
                TxtBxNumber1.Text = "1";
                TxtBxNumber2.Text = "1";
                ReadInfoCommnet();
            }
           
        }

        public void ReadInfoCommnet()
        {
            try
            {
                using (StreamReader reader = new StreamReader(GPSFail))
                {
                    string[] lines = File.ReadAllLines(GPSFail);
                    for (int i = 0; i < lines.Length;)
                    {
                        string text = lines[i];
                        //*** Какой-то код ***
                        if (i <= 3)
                        {
                            TxtBlInfo.Text += text + Environment.NewLine;
                        }
                        i++;
                    }
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
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
                    
                    if (i > 4)
                    {
                        if (text != " !")
                        {
                            //  MessageBox.Show(text);
                           
                            TestRead(text);
                        }
                        else
                        {
                            TxtBlOutInfo.Text += text;
                           // MessageBox.Show(text + "Erro");

                        }
                    }
                    i++; 
                }
            }
        }

        public void TestRead(string text)
        {
            Number1 = Convert.ToInt32(TxtBxNumber1.Text);
            Number2 = Convert.ToInt32(TxtBxNumber2.Text);
            string str = text;          
            string ID = null;
            int KollProbel = 0;
            string textx = $@"sUTm()%rXL = ";
            string numberx = null;
            string texty = "sUTm()%rXL = ";
            string numbery = null;
            string textz = "sUTm()%rXL = ";
            string numberz = null;
            for (int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                string textc = Convert.ToString(c);
               
                if (textc == " ")
                {
                   // MessageBox.Show("Пусто");
                    KollProbel ++;
                }
                else if (KollProbel== 1) //ID 
                {
                    ID += Convert.ToInt32(textc);
                    textx = $@" sUTm({ID})%rXL = ";
                    texty = $@" sUTm({ID})%rYL = ";
                    textz = $@" sUTm({ID})%rZL = ";
                }
                else if (KollProbel == 2) //определение x
                {
                    numberx += textc;
                }
                else if (KollProbel == 3) //определение y
                {
                    numbery += textc;

                }else if (KollProbel == 4) //определение z
                {
                    numberz += textc;
                }                
            }
            if (Convert.ToInt32(ID) >= Number1 && Convert.ToInt32(ID) <= Number2)            
            {
                TxtBlOutInfo.Text += Environment.NewLine;
                TxtBlOutInfo.Text += " " + ID + textx + numberx + Environment.NewLine;
                TxtBlOutInfo.Text += " " + "  " + texty + numbery + Environment.NewLine;
                TxtBlOutInfo.Text += " " + "  " + textz + numberz + Environment.NewLine;                
                //TxtBlOutInfo.Text += Environment.NewLine;
            }

        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtBxNumber1.Text) || String.IsNullOrEmpty(TxtBxNumber2.Text))
            {
                MessageBox.Show("Напишите промежуток");
                TxtBxNumber1.Text = "1";
                TxtBxNumber2.Text = "1";
            }
            else
            {
                TxtBlOutInfo.Text = null;
                ReadIfnoTextAsync();
                AddProbel.IsEnabled = true;
                DelProbel.IsEnabled= true;
                OutDoc.IsEnabled = true;
            }
        }

        public void SafeFaile()
        {
            TxtBlOutInfo.Focus(); //Передаем фокус в текстовое поле            
                                  //TxtBlOutInfo.SelectionLength(0,TxtBlOutInfo.Text.Length); //Выделяем текст
            TxtBlOutInfo.Select(0, TxtBlOutInfo.Text.Length);
            //MessageBox.Show(TxtBlOutInfo.SelectedText);
            string DirectoryFale = Path.GetDirectoryName(GPSFail);
            
            DirectoryInfo di = new DirectoryInfo(DirectoryFale);
            FileInfo[] TXTFiles = di.GetFiles("out.txt");
            for (int i = 1; i != 0;)
            {
                FileInfo[] TXTFilesi = di.GetFiles($@"out{i}.txt");
                if (TXTFiles.Length == 0)
                {
                    //log.Info("no files present");
                    StreamWriter sw = new StreamWriter($@"{DirectoryFale}\out.txt");
                    sw.Write(TxtBlOutInfo.SelectedText);
                    sw.Close();
                    i = 0;                    
                }
                else if (TXTFilesi.Length == 0 )
                {
                    StreamWriter sw = new StreamWriter($@"{DirectoryFale}\out{i}.txt");
                    sw.Write(TxtBlOutInfo.SelectedText);
                    sw.Close();
                    i = 0;
                }
                else
                {                               
                    i++;
                } 
            }
           

        }

        private void DelProbel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // int adasd = TxtBlOutInfo.CaretIndex;
                //string fdfds = TxtBlOutInfo.Select(TxtBlOutInfo.CaretIndex,1);
                // MessageBox.Show(adasd.ToString());
                //string asda = TxtBlOutInfo.Text.Select(TxtBlOutInfo.Text.Length, 0);
                //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex, TxtBlOutInfo.Text.Length);
                int adasd_0 = TxtBlOutInfo.CaretIndex;
                int adasd_1 = TxtBlOutInfo.CaretIndex-1;
                int adasd_2 = TxtBlOutInfo.CaretIndex+1;
                MessageBox.Show(adasd_0.ToString() + "    " + adasd_1.ToString() + "   " + adasd_2.ToString());
                TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex-1, 2);
                //SelectedText                
                // string sldtxt = TxtBlOutInfo.SelectedText.Remove(Convert.ToInt32(TxtBlOutInfo.Cursor),0);
                //  MessageBox.Show(sldtxt.ToString());

                //string a = f.GetPosition((Rectangle)sender).ToString();
                //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.SelectedText + 1, TxtBlOutInfo.Text.Length);
                //MessageBox.Show(a);
                //TxtBlOutInfo.Focus();
                //TxtBlOutInfo.Select(0, TxtBlOutInfo.Text.Length);
                //TxtBlOutInfo.Select(TxtBlOutInfo.CaretIndex-1, TxtBlOutInfo.CaretIndex);
                //TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex - 1);
                //TxtBlOutInfo.SelectedText.Remove(TxtBlOutInfo.CaretIndex-1, TxtBlOutInfo.Text.Length);
            }
            catch (Exception ex) 
            { 

            }
        }

        private void TxtBlOutInfo_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
        }

        private void TxtBlOutInfo_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void OutDoc_Click(object sender, RoutedEventArgs e)
        {
            SafeFaile();
        }

        private void AddProbel_Click(object sender, RoutedEventArgs e)
        {
            TxtBlOutInfo.Text = TxtBlOutInfo.Text.Insert(TxtBlOutInfo.CaretIndex, " !");
        }
    }
}
