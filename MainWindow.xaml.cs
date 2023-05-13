using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        string GPSFailNew = null, GPSFailOld = null,TextFormuleTest=null,TextFormuleID=null;
        string TextOld = null,  KollOldText = null;
        Int64 Number1 = 0, Number2, Koll = 0;
        int MouseFirst = 0, MouseDelete = 0, MouseEnd = 0, IDNewText2 = 1, ProverkaComment = 0,ProverkaEnd=1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOpenFail_Click(object sender, RoutedEventArgs e)
        {
            OpenFail();
        }

        private void OpenFail()
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
                    TextFormuleID = null;
                    TxtBlOutInfo.Text = null;
                    TxtBlOutInfo2.Text = null;
                    TxtBxNumber1.Text = "1";
                    TxtBxNumber2.Text = "1";
                    TxtBxNumber1.IsEnabled = true;
                    TxtBxNumber2.IsEnabled = true;
                    BtnSelect.IsEnabled = true;
                    AddProbel.IsEnabled = true;
                    DelProbel.IsEnabled = true;
                    BtnFirstMouse.IsEnabled = true;
                    BtnFirstMouseDell.IsEnabled = true;
                    BtnEndMouse.IsEnabled = true;
                    BtnEndMouseDell.IsEnabled = true;
                    DelInfo.IsEnabled = true;
                    TxtBlOutInfo.IsEnabled = true;
                    BtnBack.IsEnabled = true;
                    IDNewText2 = 1;
                    ReadInfoCommnetAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //Открытие файла

        public async void /* или Task*/ ReadInfoCommnetAsync() //Чтение комментария
        {
            using (StreamReader reader = new StreamReader(GPSFailOld))
            {
                {
                    string txtcommnet = null;
                    // Создание, запуск и ожидание таска.
                    await Task.Run(localReadInfoCommnet);

                    TxtBlInfo.Text = txtcommnet;
                    void localReadInfoCommnet()
                    {
                        // чё-то тут делаем.

                        int EnnKomment = 0;
                        string[] lines = File.ReadAllLines(GPSFailOld);
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string text = lines[i];
                            if (text == "!")
                            {
                                ProverkaComment = 1;
                                txtcommnet += text + Environment.NewLine;
                                for (int j = i + 1; j < lines.Length; j++)
                                {
                                    text = lines[j];
                                    if (text != "!")
                                    {
                                        if (EnnKomment == 0)
                                        {
                                            txtcommnet += text + Environment.NewLine;
                                        }
                                    }
                                    else
                                    {
                                        txtcommnet += text + Environment.NewLine;
                                        EnnKomment++;
                                        break;
                                    }
                                }
                            }
                            char indxtext = text[0];
                            if (indxtext.ToString() == "i" || indxtext.ToString() == "I" || indxtext.ToString() == "1")
                            {
                                txtcommnet = "Нет описания";
                                ProverkaComment = 0;
                                break;
                            }
                            else if (EnnKomment == 1)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        } //new комментарий //Чтение комментрария к  файлу

        public void ReadIfnoTextAsync()  //Метод чтение файла 
        {
            try
            {
                using (StreamReader reader = new StreamReader(GPSFailOld))
                {
                    string[] lines = File.ReadAllLines(GPSFailOld);
                    char textid;
                    string sttxt = null;
                    int ProverkaNaKomment = 0;
                    Koll = 0;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string text = lines[i];
                        if (ProverkaComment == 0)//Если нет комментариев
                        {
                            if (text != "!" && text != "" && sttxt != "i" && sttxt != "I")
                            {
                                //ReadFoFormole(text); //Функция чтения, преобразования и вывода данных по формуле
                            }
                        }
                        else if (ProverkaComment == 1)
                        {
                            if (text != "" && text != "\n" && text != "\t")
                            {
                                textid = text[0];
                                sttxt = textid.ToString();
                                if (text == "!")
                                {
                                    ProverkaNaKomment++;
                                }
                                if (text != "!" && text != "" && sttxt != "i" && sttxt != "I" && ProverkaNaKomment == 2)
                                {
                                    //  ReadForFormoleSpeedBuilder(text);
                                    // ReadFoFormoleSpeed(text);
                                    // ReadFoFormole(text); //Функция чтения, преобразования и вывода данных по формуле                                   
                                    ReadInfoNewTask(text);
                                    //ReadForFormoleSpeedBuilder();
                                }
                            }
                        }
                    }
                    // TextReadOfNewIDText();//Функция для второго текса, начиная с 1 ID

                    // TxtBlOutInfo.Text += textfotonfo;
                    // TextReadNewIDSpeed();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        public Task  ReadInfoNewTask(string text) //Привидение к формуле используется(быстро) 
        {
            var outer =  Task.Factory.StartNew(() =>
            {
                StringBuilder infoBuilder = new StringBuilder();
                string str = text;
                string ID = null;
                int KollProbel = 0;
                string textx = "sUTm()%rXL=";
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
                        KollProbel++;
                    }
                    else if (KollProbel == 0) //ID 
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

                    }
                    else if (KollProbel == 3) //определение z
                    {
                        numberz += textc;
                    }
                }
                if (Convert.ToInt32(ID) >= Number1 && Convert.ToInt32(ID) <= Number2)
                {
                    infoBuilder.AppendLine();
                    infoBuilder.AppendLine('\t' + textx + numberx);
                    infoBuilder.AppendLine('\t' + textx + numbery);
                    infoBuilder.AppendLine('\t' + textx + numberz);
                    TextFormuleTest += infoBuilder.ToString();
                    Koll++;                    
                }
            });           
            outer.Wait();  // ожидаем выполнения внешней задач 
            return Task.CompletedTask;
        }

        public Task ReadInfoNewID()//Привидение к формуле по уникальному ID используется(быстро) 
        {
            var outer = Task.Factory.StartNew(() =>
            {
                StringBuilder infoBuilder = new StringBuilder();               
                int intxyz = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                string[] lines = TextFormuleTest.Split('\n');
                string text = lines[0];
                string str = text;
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    text = lines[i];
                    str = text;
                    string textnumber = text;
                    string textx = "sUTm()%rXL=";
                    string numberx = null;
                    string texty = "sUTm()%rXL=";
                    string numbery = null;
                    string textz = "sUTm()%rXL=";
                    string numberz = null;
                    int krat4 = i % 4;
                    if ( ((str == "\n") ||  (str == "\r\n") || (str == "\r\n") || (str == "\r")))
                    {
                        infoBuilder.Append('\n');
                    }
                    else if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && i == 0)
                    {
                        infoBuilder.AppendLine(str);
                    }
                    if (str != "" && str != " " && str != "\t" && str != "!" && str != "\r")
                    {
                        for (int j = 6; j < text.Length; j++)
                        {
                            numbecheack++;
                            char c = str[j];
                            int kollleng = text.Length;
                            string textc = Convert.ToString(c);
                            int lengidold = 0;
                            if (j == 6 && intoldnumber == 0) //определяем ID
                            {
                                for (int a = 6; textnumber != ")"; a++)
                                {
                                    char f = str[a];
                                    textnumber = Convert.ToString(f);
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
                           
                            if (Convert.ToInt32(IDOld) >= 10)  //1 
                            {
                                lengidold = IDOld.Length - 1;
                            }
                            if (j >= 13 + lengidold && intxyz == 0)
                            {
                                numberx += textc;
                            }
                            else if (j >= 13 + lengidold && intxyz == 1) //определение x
                            {
                                numbery += textc;
                            }
                            else if (j >= 13 + lengidold && intxyz == 2) //определение y
                            {
                                numberz += textc;
                            }
                            if (j == kollleng - 1)
                            {
                                textx = $@"sUTm({IDNewText2})%rXL=";
                                texty = $@"sUTm({IDNewText2})%rYL=";
                                textz = $@"sUTm({IDNewText2})%rZL=";
                                if (intxyz == 0)
                                {
                                    infoBuilder.Append('\t' + textx + numberx+ '\n');                                   
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    
                                    infoBuilder.Append('\t' + texty + numbery + '\n');
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {

                                    infoBuilder.Append('\t' + textz + numberz + '\n');
                                    intxyz = 0;
                                    IDNewText2 = IDNewText2 + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    //TextFormuleID += infoBuilder.AppendLine();
                                    TextFormuleID += infoBuilder.ToString();
                                    
                                    infoBuilder.Clear();
                                }
                            }
                        }
                    }                  
                }
                lines = TextFormuleID.Split('\n');
                //infoBuilder.Append(TextFormuleID);
                //infoBuilder.Remove(TextFormuleID.Length-2, 1);
                //TextFormuleID = null;
                //TextFormuleID = infoBuilder.ToString();
                //infoBuilder.Clear();
                // infoBuilder.Append(TextFormuleID);
            });

           outer.Wait();  // ожидаем выполнения внешней задач       
           return Task.CompletedTask;
        }  

        public Task ReadInfoNewIDDell() //Привидение к формуле по ID для удаления используется(быстро)
        {
            var outer = Task.Factory.StartNew(() =>
            {
                StringBuilder infoBuilder = new StringBuilder();
                int intxyz = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                string[] lines = TextFormuleTest.Split('\n');
                string text = lines[0];
                string str = text;
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    text = lines[i];
                    str = text;
                    string textnumber = text;
                    string textx = "sUTm()%rXL=";
                    string numberx = null;
                    string texty = "sUTm()%rXL=";
                    string numbery = null;
                    string textz = "sUTm()%rXL=";
                    string numberz = null;
                    int krat4 = i % 4;
                    if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && i == 0)
                    {
                        infoBuilder.AppendLine();
                    }
                    else if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && i == 0)
                    {
                        infoBuilder.AppendLine(str);
                    }
                    if (str != "" || str != " " || str != "\t" || str != "!" || str != "\r")
                    {
                        for (int j = 6; j < text.Length; j++)
                        {
                            numbecheack++;
                            char c = str[j];
                            int kollleng = text.Length;
                            string textc = Convert.ToString(c);
                            int lengidold = 0;
                            if (j == 6 && intoldnumber == 0) //определяем ID
                            {
                                for (int a = 6; textnumber != ")"; a++)
                                {
                                    char f = str[a];
                                    textnumber = Convert.ToString(f);
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

                            if (Convert.ToInt32(IDOld) >= 10)  //1 
                            {
                                lengidold = IDOld.Length - 1;
                            }
                            if (j >= 13 + lengidold && intxyz == 0)
                            {
                                numberx += textc;
                            }
                            else if (j >= 13 + lengidold && intxyz == 1) //определение x
                            {
                                numbery += textc;
                            }
                            else if (j >= 13 + lengidold && intxyz == 2) //определение y
                            {
                                numberz += textc;
                            }
                            if (j == kollleng - 1)
                            {
                                textx = $@"sUTm({IDNewText2})%rXL=";
                                texty = $@"sUTm({IDNewText2})%rYL=";
                                textz = $@"sUTm({IDNewText2})%rZL=";
                                if (intxyz == 0)
                                {
                                    infoBuilder.Append("\t" + textx + numberx);
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {

                                    infoBuilder.Append("\t" + texty + numbery);
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {

                                    infoBuilder.AppendLine("\t" + textz + numberz);
                                    intxyz = 0;
                                    IDNewText2 = IDNewText2 + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    TextFormuleID += infoBuilder.ToString();
                                    infoBuilder.Clear();
                                }
                            }
                        }
                    }
                }
                infoBuilder.Append(TextFormuleID);
                infoBuilder.Remove(TextFormuleID.Length - 2, 1);
                TextFormuleID = infoBuilder.ToString();
            });

            outer.Wait();  // ожидаем выполнения внешней задач       
            return Task.CompletedTask;
        }

        public void TextValidationTextBox(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space) e.Handled = true;
            if (e.Key == Key.Tab)
            {
                TxtBxNumber2.Text = TxtBxNumber1.Text;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }             

        private void BtnSelect_Click(object sender, RoutedEventArgs e) //Кнопка Выбрать
        {
            try
            {
                if (String.IsNullOrEmpty(TxtBxNumber1.Text) || String.IsNullOrEmpty(TxtBxNumber2.Text))
                {
                    MessageBox.Show("Напишите промежуток.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    TxtBxNumber1.Text = "1";
                    TxtBxNumber2.Text = "1";
                }
                else
                {
                    Number1 = Convert.ToInt64(TxtBxNumber1.Text);
                    Number2 = Convert.ToInt64(TxtBxNumber2.Text);
                    if (Number1 > Number2)
                    {
                        MessageBox.Show("Первое число не может быть больше второго числа.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    //else  if (Number2 + Number1 >= 1001)
                    //{
                    //    MessageBox.Show("Разница не должна быть  больше 1000", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                    //}
                    else
                    {
                        TxtBlOutInfo.IsEnabled = true;
                        TxtBlOutInfo.Text = null;                       
                        TxtTest.Text = null;
                        TextOld = null;
                        TextFormuleTest = null;
                        ReadIfnoTextAsync();
                        TxtBlOutInfo.Text = TextFormuleTest;
                        ReadInfoNewID();
                        TxtBlOutInfo2.Text = null;
                        TxtBlOutInfo2.Text += TextFormuleID;
                        TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);
                        //TextReadOfNewIDText();
                        //MouseDellFirst();
                        //FirstMouse();
                        //BtnFirstMouseDell.IsEnabled = false;
                        //BtnEndMouseDell.IsEnabled = false;
                        //BtnEndMouse.IsEnabled = false;
                        //DelInfo.IsEnabled = false;
                        //MouseFirst = 0;
                        //MouseEnd = 0;
                        //AddProbel.IsEnabled = true;
                        //DelProbel.IsEnabled = true;
                        OutDoc.IsEnabled = true;
                        //BtnFirstMouse.IsEnabled = true;
                        //BtnBack.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void SafeFaile() //Схранение файла 
        {
            try
            {
                TxtBlOutInfo2.Focus(); //Передаем фокус в текстовое поле            
                                      //TxtBlOutInfo.SelectionLength(0,TxtBlOutInfo.Text.Length); //Выделяем текст
                TxtBlOutInfo2.Select(0, TxtBlOutInfo2.Text.Length);
                //MessageBox.Show(TxtBlOutInfo.SelectedText);
                string DirectoryFale = Path.GetDirectoryName(GPSFailOld);
                MessageBox.Show("Сохранение начинается, дождитесь окончания сохранения.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Warning);
                DirectoryInfo di = new DirectoryInfo(DirectoryFale);
                FileInfo[] TXTFiles = di.GetFiles("out.txt");
                for (int i = 1; i != 0;)
                {
                    FileInfo[] TXTFilesi = di.GetFiles($@"out{i}.txt");
                    if (TXTFiles.Length == 0)
                    {
                        //log.Info("no files present");
                        StreamWriter sw = new StreamWriter($@"{DirectoryFale}\out.txt");
                        sw.Write(TxtBlOutInfo2.SelectedText);
                        sw.Close();
                        i = 0;
                    }
                    else if (TXTFilesi.Length == 0)
                    {
                        StreamWriter sw = new StreamWriter($@"{DirectoryFale}\out{i}.txt");
                        sw.Write(TxtBlOutInfo2.SelectedText);
                        sw.Close();
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                MessageBox.Show("Сохранение прошло успешно.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                FocusManager.SetFocusedElement(this, TxtBxNumber1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }  

        private void DelProbel_Click(object sender, RoutedEventArgs e) //Удалить !
        {
            try
            {
                MouseDelete = TxtBlOutInfo2.CaretIndex;
                if (MouseDelete != 0)
                {
                    // int adasd = TxtBlOutInfo.CaretIndex;
                    //string fdfds = TxtBlOutInfo.Select(TxtBlOutInfo.CaretIndex,1);
                    // MessageBox.Show(adasd.ToString());
                    //string asda = TxtBlOutInfo.Text.Select(TxtBlOutInfo.Text.Length, 0);
                    //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex, TxtBlOutInfo.Text.Length);
                    //int adasd_0 = TxtBlOutInfo.CaretIndex;
                    //int adasd_1 = TxtBlOutInfo.CaretIndex - 1;
                    //int adasd_2 = TxtBlOutInfo.CaretIndex + 1;
                    //MessageBox.Show(adasd_0.ToString() + "    " + adasd_1.ToString() + "   " + adasd_2.ToString());
                    //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex - 1, 2);
                    //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Remove(TxtBlOutInfo.CaretIndex - 1, 1);
                    
                    TxtBlOutInfo2.Select(MouseDelete, 1);
                    string strokatxt = TxtBlOutInfo2.SelectedText;
                    if (strokatxt == "")
                    {
                        MouseDelete = TxtBlOutInfo2.CaretIndex - 1;
                        TxtBlOutInfo2.Select(MouseDelete, 1);
                        strokatxt = TxtBlOutInfo2.SelectedText;
                    }
                    for (int i = 1; i != 0;) //Поиск !
                    {
                        char c = strokatxt[0];
                        string textc = Convert.ToString(c);
                        if (textc == "!")
                        {
                            TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Remove(MouseDelete, 1);
                            break;
                        }
                        else
                        {
                            TxtBlOutInfo2.Select(MouseDelete - 1, 1);
                            MouseDelete--;
                            strokatxt = TxtBlOutInfo2.SelectedText;
                        }

                    }
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void FirstMouse() //
        {
            //MouseFirst = TxtBlOutInfo.CaretIndex;
            //TextOld = TxtBlOutInfo.Text;
            //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Insert(TxtBlOutInfo.CaretIndex, "<");
            BtnEndMouse.IsEnabled = true;
            BtnFirstMouseDell.IsEnabled = true;
            BtnFirstMouse.IsEnabled = false;
           // CheckFirst();

            //MessageBox.Show(MouseFirst.ToString());

        }

        public void EndMouse()//Координаты мыши конца, для удаления
        {
            //MouseEnd = TxtBlOutInfo.CaretIndex;
            //TextOld = TxtBlOutInfo.Text;
            //TxtBlOutInfo.Text = TxtBlOutInfo.Text.Insert(TxtBlOutInfo.CaretIndex, "<");
            DelInfo.IsEnabled = true;
            BtnFirstMouseDell.IsEnabled = false;
            BtnEndMouseDell.IsEnabled = true;
            BtnEndMouse.IsEnabled = false;
            //MessageBox.Show(MouseEnd.ToString());
        }

        public void DeleteForFirsEndMouse()
        {
           
            try
            {
                int TextIndexMax = 0;
                TextIndexMax = TxtBlOutInfo2.Text.Length;
                //TextOld = TxtBlOutInfo.Text;
                if (TextIndexMax <= MouseEnd+3)
                {
                    TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Remove(MouseFirst - 2, MouseEnd - MouseFirst + 5);
                }
                else
                {
                    TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Remove(MouseFirst - 2, MouseEnd - MouseFirst + 5);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void MouseDellFirst()
        {
            try
            {
                if (MouseEnd != 0)
                {
                    MouseDellEnd();
                    DelInfo.IsEnabled = false;
                    BtnEndMouseDell.IsEnabled = false;
                }
                TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Remove(MouseFirst, 1);
                MouseFirst = 0;
                DelInfo.IsEnabled = false;
                BtnFirstMouse.IsEnabled = true;
                BtnEndMouseDell.IsEnabled = false;
                BtnFirstMouseDell.IsEnabled = false;
                BtnEndMouse.IsEnabled = false;
            }
            catch
            {
                MouseFirst = 0;
                DelInfo.IsEnabled = false;
                BtnFirstMouse.IsEnabled = true;
                BtnFirstMouseDell.IsEnabled = false;
                BtnEndMouse.IsEnabled = false;
            }
            
        }

        public void CheckFirst() //Определение начало строки для начала вырезки
        {
            try
            {
                MouseFirst = TxtBlOutInfo2.CaretIndex;
                if (MouseFirst == 0)
                {
                    MessageBox.Show("Выберите место в тексте.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (TxtBlOutInfo2.Text.Length == MouseFirst)
                    {
                        MouseFirst = MouseFirst - 2;
                    }
                    TxtBlOutInfo2.Select(MouseFirst, 1);
                    string strokatxt = TxtBlOutInfo2.SelectedText;
                    if (strokatxt == "!")
                    {
                        MouseFirst = MouseFirst - 2;
                    }
                    for (int i = 1; i != 0;) //Поиск идем вправо
                    {

                        TxtBlOutInfo2.Select(MouseFirst + 1, 1);
                        MouseFirst = MouseFirst + 1;
                        strokatxt = TxtBlOutInfo2.SelectedText;
                        if (strokatxt == "")
                        {
                            TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                            MouseFirst = MouseFirst - 1;
                            strokatxt = TxtBlOutInfo2.SelectedText;
                        }
                        char c = strokatxt[0];
                        string textc = Convert.ToString(c);                      
                        if (textc == "X") //Нашили X
                        {
                            for (i =1; i != 0;) //Поиск начало строки, идем влево
                            {
                                TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                MouseFirst = MouseFirst - 1;
                                //MessageBox.Show(MouseFirst.ToString());
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "s") //Нашли начало строки 
                                {
                                    TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Insert(MouseFirst, "<");
                                    i = 0;
                                    break;
                                }
                            }
                        }
                        else if (textc == "Y") //Нашили Y
                        {
                            for (i = 1; i != 0;) //Поиск начало строки, идем влево
                            {
                                TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                MouseFirst = MouseFirst - 1;
                                //MessageBox.Show(MouseFirst.ToString());
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "s") //Нашли начало строки 
                                {                                    
                                    MouseFirst = MouseFirst - 4;
                                    break;
                                }
                            }
                        }
                        else if (textc == "Z")
                        {
                            for (i = 1; i != 0;) //Поиск начало строки, идем влево
                            {
                                TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                MouseFirst = MouseFirst - 1;
                                //MessageBox.Show(MouseFirst.ToString());
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "s") //Нашли начало строки 
                                {                                  
                                    MouseFirst = MouseFirst - 4;
                                    break;
                                }
                            }
                        }
                        if (textc == "" || textc == "\r") //X,Y,Z были левее, нашли конец строки
                        {
                            for (i = 1; i != 0;) //Идем влево
                            {
                                TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                MouseFirst = MouseFirst - 1;
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "X") //Если X
                                {
                                    for (i = 1; i != 0;) //Идем влево
                                    {
                                        TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                        MouseFirst = MouseFirst - 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "s") //Нашли начало строки 
                                        {
                                            TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Insert(MouseFirst, "<");
                                            i = 0;
                                            break;
                                        }
                                    }
                                }
                                else if (textc == "Y")
                                {
                                    for (i = 1; i != 0;) //Идем влево
                                    {
                                        TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                        MouseFirst = MouseFirst - 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "s") //Нашли начало строки 
                                        {
                                            MouseFirst = MouseFirst - 4;
                                            break;
                                        }
                                    }
                                }
                                else if (textc == "Z")
                                {
                                    for (i = 1; i != 0;) //Идем влево
                                    {
                                        TxtBlOutInfo2.Select(MouseFirst - 1, 1);
                                        MouseFirst = MouseFirst - 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "s") //Нашли начало строки 
                                        {
                                            MouseFirst = MouseFirst - 4;
                                            break;
                                        }
                                    }
                                }                             
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void CheckEnd() //Определение начало строки для начала вырезки
        {
            try
            {
                MouseEnd = TxtBlOutInfo2.CaretIndex;
                if (MouseEnd == 0)
                {
                    MessageBox.Show("Выберете место в тексте");
                }
                else
                {
                    if (TxtBlOutInfo2.Text.Length == MouseEnd)
                    {
                        MouseEnd = MouseEnd - 2;
                    }
                    if (MouseEnd <= MouseFirst)
                    {
                        MouseEnd = MouseFirst;
                    }
                    TxtBlOutInfo2.Select(MouseEnd, 1);
                    string strokatxt = TxtBlOutInfo2.SelectedText;
                    if (strokatxt == "!")
                    {
                        MouseEnd = MouseEnd - 2;
                    }
                    for (int i = 1; i != 0;) //Поиск идем вправо
                    {
                        int j = 0;
                        TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                        MouseEnd = MouseEnd + 1;
                        strokatxt = TxtBlOutInfo2.SelectedText;
                        if (strokatxt == "")
                        {
                            TxtBlOutInfo2.Select(MouseEnd - 1, 1);
                            MouseEnd = MouseEnd - 1;
                            strokatxt = TxtBlOutInfo2.SelectedText;
                        }
                        char c = strokatxt[0];
                        string textc = Convert.ToString(c);
                        if (textc == "X") //Нашили X
                        {
                            for (i = 1; i != 0;) //Поиск конца строки, идем вправо
                            {
                                TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                                MouseEnd = MouseEnd + 1;
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "\r") //Нашли конец строки
                                {
                                    MouseEnd = MouseEnd + 4;
                                    break;
                                }
                            }
                        }
                        else if (textc == "Y") //Нашили Y
                        {
                            for (i = 1; i != 0;) //Поиск начало строки, идем влево
                            {
                                TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                                MouseEnd = MouseEnd + 1;
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "\r") //Нашли начало строки 
                                {
                                    MouseEnd = MouseEnd + 4;
                                    break;
                                }
                            }
                        }
                        else if (textc == "Z")
                        {
                            for (i = 1; i != 0;) //Поиск начало строки, идем влево
                            {
                                TxtBlOutInfo2.Select(MouseEnd   + 1, 1);
                                MouseEnd = MouseEnd + 1;
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "\r") //Нашли начало строки 
                                {
                                    TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Insert(MouseEnd, "<");
                                    i = 0;
                                    break;
                                }
                            }
                        }
                        if ((textc == "" || textc == "\r") && i!= 0) //X,Y,Z были левее, нашли конец строки
                        {
                            for ( j = 1; j != 0;) //Идем влево
                            {
                                TxtBlOutInfo2.Select(MouseEnd - 1, 1);
                                MouseEnd = MouseEnd - 1;
                                strokatxt = TxtBlOutInfo2.SelectedText;
                                c = strokatxt[0];
                                textc = Convert.ToString(c);
                                if (textc == "X") //Если X
                                {
                                    for (i = 1; i != 0;) //Идем вправо
                                    {
                                        TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                                        MouseEnd = MouseEnd + 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "\r") //Нашли конец строки 
                                        {                                            
                                            MouseEnd = MouseEnd + 4;
                                            j = 0;
                                            break;
                                        }
                                    }
                                }
                                else if (textc == "Y")//Если Y
                                {
                                    for (i = 1; i != 0;) //Идем вправо
                                    {
                                        TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                                        MouseEnd = MouseEnd + 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "\r") //Нашли конец строки 
                                        {
                                            MouseEnd = MouseEnd + 4;
                                            j = 0;
                                            break;
                                        }
                                    }
                                }
                                else if (textc == "Z")//Если Z
                                {
                                    for (i = 1; i != 0;) //Идем вправо
                                    {
                                        TxtBlOutInfo2.Select(MouseEnd + 1, 1);
                                        MouseEnd = MouseEnd + 1;
                                        strokatxt = TxtBlOutInfo2.SelectedText;
                                        c = strokatxt[0];
                                        textc = Convert.ToString(c);
                                        if (textc == "\r") //Нашли конец строки 
                                        {
                                            TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Insert(MouseEnd, "<");
                                            j = 0;
                                            i= 0;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnFirstMouseDell_Click(object sender, RoutedEventArgs e) //Координаты мыши начало, для сброса
        {
            MouseDellFirst();
        }

        public void MouseDellEnd()
        {
            try
            {
                TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Remove(MouseEnd, 1);
                MouseEnd = 0;
                DelInfo.IsEnabled = false;
                BtnEndMouseDell.IsEnabled = false;
                BtnEndMouse.IsEnabled = true;
                BtnFirstMouseDell.IsEnabled = true;
            }
            catch
            {
                MouseEnd = 0;
                DelInfo.IsEnabled = false;
                BtnEndMouseDell.IsEnabled = false;
                BtnEndMouse.IsEnabled = true;
                BtnFirstMouseDell.IsEnabled = true;
            }
        }

        private void BtnEndMouseDell_Click(object sender, RoutedEventArgs e)
        {
            MouseDellEnd();
        }

        private void BtnEndMouse_Click(object sender, RoutedEventArgs e)
        {
            CheckEnd();
            if (MouseEnd != 0)
            {
                EndMouse();
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            TxtBlOutInfo2.Text = TextOld;
            TxtBlkNumberKoll.Text = KollOldText;
        }
        
        private void BtnFirstMouse_Click(object sender, RoutedEventArgs e)
        {
            //MouseFirst = TxtBlOutInfo.CaretIndex;
            //MessageBox.Show(MouseFirst.ToString());
            TextOld = TxtBlOutInfo2.Text;
            CheckFirst();
            if (MouseFirst != 0)
            {
                FirstMouse();
            }

        }

        private void DelInfo_Click(object sender, RoutedEventArgs e)
        {
            KollOldText = Convert.ToString(IDNewText2 - 1);
            DeleteForFirsEndMouse();
            IDNewText2 = 1;
            TextFormuleTest = TxtBlOutInfo2.Text;           
            TextFormuleID = null;
            TxtBlOutInfo2.Text = null;
            ReadInfoNewIDDell();
            TxtBlOutInfo2.Text += TextFormuleID;
            TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);            
            BtnEndMouseDell.IsEnabled = false;
            BtnFirstMouse.IsEnabled = true;
            DelInfo.IsEnabled = false;
        }

        private void OutDoc_Click(object sender, RoutedEventArgs e)
        {
            SafeFaile();
        }

        public void AddProvells()
        {
            try
            {
                if (MouseFirst > 0 || MouseEnd > 0)
                {
                    MessageBox.Show("Удалите границы удаления, перед тем как ставить комментарий.", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    TxtBlOutInfo2.Text = TxtBlOutInfo2.Text.Insert(TxtBlOutInfo2.CaretIndex, "!");
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }     
        }

        private void AddProbel_Click(object sender, RoutedEventArgs e)
        {
            AddProvells();
        }
    }
}
