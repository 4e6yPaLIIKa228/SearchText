﻿using Microsoft.Win32;
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
using static System.Net.Mime.MediaTypeNames;
using Path = System.IO.Path;

namespace SearchText
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string GPSFailNew = null, GPSFailOld = null;
        string TextOld =null,TextNew=null;
        int Number1 = 0, Number2, Koll = 0;
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
            try
            {
                //TxtBlInfo.Text = null;
               // GPSFailNew = null;
                //GPSFailOld = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {

                    // TxtBlNamefail.Text = openFileDialog.FileName;
                    // string name = Path.GetFileName(TxtBlNamefail.Text);
                    TxtBlInfo.Text = null;
                    GPSFailNew = Path.GetFullPath(openFileDialog.FileName);
                    if (GPSFailNew == null)
                    {                       
                       GPSFailOld = Path.GetFullPath(openFileDialog.FileName); 
                    }
                    else
                    {
                        GPSFailOld = GPSFailNew;
                    }               
                    TxtBlNamefail.Text = (Path.GetFileName(openFileDialog.FileName));
                    //  TxtBlNamefail.Text = openFileDialog.FileName;
                    // TxtBlNamefail.Text = File.ReadAllText(openFileDialog.FileName);//Текс файла
                    //TxtBlNamefail.Text = name;
                    // MessageBox.Show(GPSFail);
                    //ReadIfnoTextAsync();                
                    FocusManager.SetFocusedElement(this, TxtBxNumber1);
                    TxtBxNumber1.Text = "1";
                    TxtBxNumber2.Text = "1";
                    // ReadInfoCommnet();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void ReadInfoCommnet()
        {
            try
            {
                using (StreamReader reader = new StreamReader(GPSFailOld))
                {
                    string[] lines = File.ReadAllLines(GPSFailOld);
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
            try
            {
                using (StreamReader reader = new StreamReader(GPSFailOld))
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
                    string[] lines = File.ReadAllLines(GPSFailOld);
                    Koll = 0;
                    for (int i = 0; i < lines.Length;)
                    {
                        string text = lines[i];
                        //*** Какой-то код ***
                        //if (i < 3)
                        //{
                        //    TxtBlInfo.Text += text + Environment.NewLine;
                        //}   

                        if (i >= 1)
                        {
                            if (text != " !")
                            {
                                //  MessageBox.Show(text);

                                ReadFoFormole(text); //Функция чтения, преобразования и вывода данных по формуле
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ReadFoFormole(string text)
        {
            Number1 = Convert.ToInt32(TxtBxNumber1.Text);
            Number2 = Convert.ToInt32(TxtBxNumber2.Text);
            string str = text;          
            string ID = null;
            int KollProbel = 0;            
            string textx = $@"sUTm()%rXL=";
            string numberx = null;
            string texty = "sUTm()%rXL=";
            string numbery = null;
            string textz = "sUTm()%rXL=";
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
                else if (KollProbel==0) //ID 
                {
                    ID += Convert.ToInt32(textc);
                    textx = $@"sUTm({ID})%rXL=";
                    texty = $@"sUTm({ID})%rYL=";
                    textz = $@"sUTm({ID})%rZL=";
                   // KollProbel++;
                }
                else if (KollProbel == 1) //определение x
                {
                    numberx += textc;
                }
                else if (KollProbel == 2) //определение y
                {
                    numbery += textc;

                }else if (KollProbel == 3) //определение z
                {
                    numberz += textc;
                }                
            }
            if (Convert.ToInt32(ID) >= Number1 && Convert.ToInt32(ID) <= Number2)            
            {
                TxtBlOutInfo.Text += Environment.NewLine;
                TxtBlOutInfo.Text += "\t" + textx + numberx + Environment.NewLine;
                TxtBlOutInfo.Text += "\t" + texty + numbery + Environment.NewLine;
                TxtBlOutInfo.Text += "\t" + textz + numberz + Environment.NewLine;
                Koll++;
                TxtBlkNumberKoll.Text = Convert.ToString(Koll);
                //TxtTest.Text += Environment.NewLine;
                //TxtTest.Text += "\t" + textx + numberx + Environment.NewLine;
                //TxtTest.Text += "\t" + texty + numbery + Environment.NewLine;
                //TxtTest.Text += "\t" + textz + numberz + Environment.NewLine;
                //TextOld = TxtTest.Text;
                //TextOld += Environment.NewLine;
                //TextOld += "\t" + textx + numberx + Environment.NewLine;
                //TextOld += "\t" + texty + numbery + Environment.NewLine;
                //TextOld += "\t" + textz + numberz + Environment.NewLine;
                //TextOld = TxtTest.Text;
                //TxtBlOutInfo.Text += Environment.NewLine;
            }

        }
       
        public void TextReadOfNewID()
        {           
            try
            {         
                
                // TextOld = TxtTest.Text;               
                TextNew = TxtBlOutInfo.Text;
                TxtBlOutInfo.Text = null;
                TxtBlOutInfo.Text += Environment.NewLine;
                int intxyz = 0;
                int indexid = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                int IDNew = 1;
                // string[] lines = File.ReadAllLines(GPSFailOld);
                string[] lines = TextNew.Split('\t');
               // lines = lines.ReadAllLines();
                for (int i = 0; i < lines.Length;)
                {
                    string text = lines[i];
                    string str = text;
                    string textnumber = text;
                    string textx = $@"sUTm()%rXL=";
                    string numberx = null;
                    string texty = "sUTm()%rXL=";
                    string numbery = null;
                    string textz = "sUTm()%rXL=";
                    string numberz = null;
                    if (str != "" || str != " " || str != "\t")
                    {
                        for (int j = 5; j < text.Length; j++)
                        {
                            numbecheack++;
                            char c = str[j];
                            int kollleng = text.Length;
                            string textc = Convert.ToString(c);
                            int lengidold = 0;
                            if (j == 5 && intoldnumber == 0) //определяем ID
                            {
                                for (int a = 5; textnumber != ")"; a++)
                                {  
                                    char f = str[a];
                                    //c = str[a];
                                    textnumber = Convert.ToString(f);
                                    //text = Convert.ToString(c);
                                    if (textnumber == ")")
                                    {

                                    }
                                    else
                                    {
                                        IDOld += textnumber;
                                    }                                    
                                }
                                intoldnumber = 1;
                            }
                            //Сделать проверку на длинну id
                            if (Convert.ToInt32(IDOld) >= 10)  //1 
                            {
                                lengidold = IDOld.Length-1;
                                //indexid = Convert.ToInt32(IDOld) % Convert.ToInt32(IDOld) + lengidold;
                            }
                            if (j >= 12 + lengidold && intxyz == 0)
                            {
                                numberx += textc;
                            }
                            else if (j >= 12 + lengidold && intxyz == 1) //определение x
                            {
                                numbery += textc;
                            }
                            else if (j >= 12 + lengidold && intxyz == 2) //определение y
                            {
                                numberz += textc;
                            }
                            if (j == kollleng - 1)
                            {
                                textx = $@"sUTm({IDNew})%rXL=";
                                texty = $@"sUTm({IDNew})%rYL=";
                                textz = $@"sUTm({IDNew})%rZL=";
                                if (intxyz == 0)
                                {
                                    TxtBlOutInfo.Text += "\t" + textx + numberx;
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    TxtBlOutInfo.Text += "\t" + texty + numbery;
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {
                                    TxtBlOutInfo.Text += "\t" + textz + numberz;
                                    intxyz = 0;
                                    IDNew = IDNew + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    TxtBlkNumberKoll.Text = Convert.ToString(IDNew - 1);
                                }
                            }
                        }
                    }
                    i++;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                TxtTest.Text = null;
                TextOld = null;
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
            string DirectoryFale = Path.GetDirectoryName(GPSFailOld);
            
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

        private void DelProbel_Click(object sender, RoutedEventArgs e) //Удалить !
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
        
        int MouseFirst = 0, MouseEnd = 0;

        public void FirstMouse()
        {
            MouseFirst = TxtBlOutInfo.CaretIndex;
            MessageBox.Show(MouseFirst.ToString());

        }
        public void EndMouse()
        {
            MouseEnd = TxtBlOutInfo.CaretIndex;
            MessageBox.Show(MouseEnd.ToString());
        }

        public void DeleteForFirsEndMouse()
        {
            try
            {
                TextOld = TxtBlOutInfo.Text;
                TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(MouseFirst-3, MouseEnd - MouseFirst+5);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnEndMouse_Click(object sender, RoutedEventArgs e)
        {
            EndMouse();
            //DeleteForFirsEndMouse();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            TxtBlOutInfo.Text = TextOld;
        }

        private void BtnFirstMouse_Click(object sender, RoutedEventArgs e)
        {
            FirstMouse();
        }

        private void DelInfo_Click(object sender, RoutedEventArgs e)
        {
            DeleteForFirsEndMouse();
            TextReadOfNewID();
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
            TxtBlOutInfo.Text = TxtBlOutInfo.Text.Insert(TxtBlOutInfo.CaretIndex, "!");
        }
    }
}
