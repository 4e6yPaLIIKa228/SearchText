using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SearchText
{
    internal class Narobotku
    {
        /*  public void ReadInfoCommnet()
         {
             try
             {
                 using (StreamReader reader = new StreamReader(GPSFailOld))
                 {
                     int EnnKomment = 0;                    
                     TxtBlInfo.Text = string.Empty;
                     string[] lines = File.ReadAllLines(GPSFailOld);
                     for (int i = 0; i < lines.Length;i++)
                     {
                         string text = lines[i];
                         if (text == "!")
                         {
                             ProverkaComment = 1;
                             TxtBlInfo.Text += text + Environment.NewLine;
                             for (int j = i+1; j < lines.Length; j++)
                             {
                                 text = lines[j];
                                 if (text != "!")
                                 {
                                     if (EnnKomment == 0)
                                     {
                                         TxtBlInfo.Text += text + Environment.NewLine;
                                     }                                    
                                 }
                                 else
                                 {
                                     TxtBlInfo.Text += text + Environment.NewLine;
                                     EnnKomment++;
                                     break;
                                 }                               
                             }
                         }
                         char indxtext = text[0];
                         if (indxtext.ToString() == "i" || indxtext.ToString() == "I" || indxtext.ToString() == "1")
                         {
                             TxtBlInfo.Text = "Нет описания";
                             ProverkaComment = 0;
                             break;
                         }else if (EnnKomment == 1)
                         {
                             break;
                         }
                     }
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
         }*/

        /* public async void ReadFoFormoleSpeed(string text)//new первое поле по формуле
         {
             // Здесь создаём поля которые будут использоваться в таске,
             // чтобы из него не обращаться к UI элементам.
             //Number1 = Convert.ToInt64(TxtBxNumber1.Text);
             //Number2 = Convert.ToInt64(TxtBxNumber2.Text);
             // Присваивание полученных результатов.
             //TxtBlkNumberKoll.Text = Convert.ToString(Koll);
             // KollOldText = Convert.ToString(Koll);
             // TextNew = null;
             TextNew = textfoformule;
             // Создание, запуск и ожидание таска.
             await Task.Run(localReadInfoCommnet);
             void localReadInfoCommnet()
             {
                 string str = text;
                 string ID = null;
                 int KollProbel = 0;
                 string textx = "sUTm()%rXL=";
                 string numberx = null;
                 string texty = "sUTm()%rXL=";
                 string numbery = null;
                 string textz = "sUTm()%rXL=";
                 string numberz = null;
                 // чё-то тут делаем.
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
                     textfoformule += Environment.NewLine;
                     textfoformule += "\t" + textx + numberx + Environment.NewLine;
                     textfoformule += "\t" + texty + numbery + Environment.NewLine;
                     textfoformule += "\t" + textz + numberz + Environment.NewLine;
                     Koll++;
                 }
             }


         }*/

        /* public async void ReadForFormoleSpeedBuilder(string text) //new первое поле по формуле
        {
            // Здесь создаём поля которые будут использоваться в таске,
            // чтобы из него не обращаться к UI элементам.
            //Number1 = Convert.ToInt64(TxtBxNumber1.Text);
            //Number2 = Convert.ToInt64(TxtBxNumber2.Text);                   
            // string txtonvoid = null;
            await Task.Run(localReadForFormul);
            // TextNew += txtonvoid;
            // textfotonfo += txtonvoid;

            // MessageBox.Show(textfotonfo);           
            //TextNew = TxtBlOutInfo.Text;

            void localReadForFormul()
            {
                StringBuilder infoBuilder = new StringBuilder();
                //infoBuilder = null;
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
                    infoBuilder.AppendLine("\t" + textx + numberx);
                    infoBuilder.AppendLine("\t" + textx + numbery);
                    infoBuilder.AppendLine("\t" + textx + numberz);
                    TextNew += infoBuilder.ToString();
                    Koll++;
                    // return infoBuilder.ToString();
                }
                // return infoBuilder.ToString();
            }
        }*/

        /* public void ReadIfnoTextAsync()  //Метод чтение файла 
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
        }*/

        /* public void ReadFoFormole(string text)
         {
             try
             {
                 Number1 = Convert.ToInt64(TxtBxNumber1.Text);
                 Number2 = Convert.ToInt64(TxtBxNumber2.Text);
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
                     TxtBlOutInfo.Text += Environment.NewLine;
                     TxtBlOutInfo.Text += "\t" + textx + numberx + Environment.NewLine;
                     TxtBlOutInfo.Text += "\t" + texty + numbery + Environment.NewLine;
                     TxtBlOutInfo.Text += "\t" + textz + numberz + Environment.NewLine;
                     Koll++;
                     TxtBlkNumberKoll.Text = Convert.ToString(Koll);
                     KollOldText = Convert.ToString(Koll);
                 }
             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }

         }*/

        /*public void TextReadOfNewID()
       {
           try
           {

               // TextOld = TxtTest.Text;               
               TextNew = TxtBlOutInfo2.Text;
               TxtBlOutInfo2.Text = null;
               //TxtBlOutInfo.Text += Environment.NewLine;
               int intxyz = 0;
               //int indexid = 0;
               int intoldnumber = 0;
               int numbecheack = 0;
               string IDOld = null;
               int IDNew = 1;
               // string[] lines = File.ReadAllLines(GPSFailOld);
               string[] lines = TextNew.Split('\n'); //
               string text = lines[0];
               string str = text;
               // lines = lines.ReadAllLines();
               //MessageBox.Show(str);                
               //else if (str != "!\r\n" && str != "!")
               //{
               //    TxtBlOutInfo.Text += Environment.NewLine;
               //}
               for (int i = 0; i < lines.Length-1;i++)
               {
                   text = lines[i];
                   str = text;
                   string textnumber = text;
                   string textx = $@"sUTm()%rXL=";
                   string numberx = null;
                   string texty = "sUTm()%rXL=";
                   string numbery = null;
                   string textz = "sUTm()%rXL=";
                   string numberz = null;
                   int krat4 = i % 4;
                   if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && i == 0)    
                   {
                       TxtBlOutInfo2.Text += Environment.NewLine;
                   }
                   else if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && i == 0)
                   {
                       TxtBlOutInfo2.Text += str;
                   }
                   if (str != "" || str != " " || str != "\t" || str !="!")
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
                               textx = $@"sUTm({IDNew})%rXL=";
                               texty = $@"sUTm({IDNew})%rYL=";
                               textz = $@"sUTm({IDNew})%rZL=";
                               if (intxyz == 0)
                               {
                                   TxtBlOutInfo2.Text += "\t" + textx + numberx + "\n";
                                   intxyz++;
                               }
                               else if (intxyz == 1)
                               {
                                   TxtBlOutInfo2.Text += "\t" + texty + numbery + "\n";
                                   intxyz++;
                               }
                               else if (intxyz == 2)
                               {
                                   TxtBlOutInfo2.Text += "\t" + textz + numberz + "\n";
                                   intxyz = 0;
                                   IDNew = IDNew + 1;
                                   IDNewText2 = IDNew;
                                   IDOld = null;
                                   intoldnumber = 0;
                                   TxtBlkNumberKoll.Text = Convert.ToString(IDNew - 1);
                               }
                           }
                       }                        
                       if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && (i % 4 == 0) && i !=0)
                       {
                           TxtBlOutInfo2.Text += str;
                       }
                       else if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && (i % 4 == 0) && i!= 0)
                       {
                           TxtBlOutInfo2.Text += Environment.NewLine;
                       }                       
                   }

               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }
       } //не рабоает*/

        /* public async void ReadForFormoleSpeedBuilder(string text) //new первое поле по формуле
         {
             // Здесь создаём поля которые будут использоваться в таске,
             // чтобы из него не обращаться к UI элементам.
             //Number1 = Convert.ToInt64(TxtBxNumber1.Text);
             //Number2 = Convert.ToInt64(TxtBxNumber2.Text);                   
             // string txtonvoid = null;
             await Task.Run(localReadForFormul);
             // TextNew += txtonvoid;
             // textfotonfo += txtonvoid;

             // MessageBox.Show(textfotonfo);           
             //TextNew = TxtBlOutInfo.Text;

             void localReadForFormul()
             {
                 StringBuilder infoBuilder = new StringBuilder();
                 //infoBuilder = null;
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
                     infoBuilder.AppendLine("\t" + textx + numberx);
                     infoBuilder.AppendLine("\t" + textx + numbery);
                     infoBuilder.AppendLine("\t" + textx + numberz);
                     TextNew += infoBuilder.ToString();
                     Koll++;
                     // return infoBuilder.ToString();
                 }
                 // return infoBuilder.ToString();
             }
         }*/

        /* public void ReadFoFormole(string text)
        {
            try
            {
                Number1 = Convert.ToInt64(TxtBxNumber1.Text);
                Number2 = Convert.ToInt64(TxtBxNumber2.Text);
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
                    TxtBlOutInfo.Text += Environment.NewLine;
                    TxtBlOutInfo.Text += "\t" + textx + numberx + Environment.NewLine;
                    TxtBlOutInfo.Text += "\t" + texty + numbery + Environment.NewLine;
                    TxtBlOutInfo.Text += "\t" + textz + numberz + Environment.NewLine;
                    Koll++;
                    TxtBlkNumberKoll.Text = Convert.ToString(Koll);
                    KollOldText = Convert.ToString(Koll);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }*/

        /*public void TextReadOfNewID()
        {
            try
            {

                // TextOld = TxtTest.Text;               
                TextNew = TxtBlOutInfo2.Text;
                TxtBlOutInfo2.Text = null;
                //TxtBlOutInfo.Text += Environment.NewLine;
                int intxyz = 0;
                //int indexid = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                int IDNew = 1;
                // string[] lines = File.ReadAllLines(GPSFailOld);
                string[] lines = TextNew.Split('\n'); //
                string text = lines[0];
                string str = text;
                // lines = lines.ReadAllLines();
                //MessageBox.Show(str);                
                //else if (str != "!\r\n" && str != "!")
                //{
                //    TxtBlOutInfo.Text += Environment.NewLine;
                //}
                for (int i = 0; i < lines.Length-1;i++)
                {
                    text = lines[i];
                    str = text;
                    string textnumber = text;
                    string textx = $@"sUTm()%rXL=";
                    string numberx = null;
                    string texty = "sUTm()%rXL=";
                    string numbery = null;
                    string textz = "sUTm()%rXL=";
                    string numberz = null;
                    int krat4 = i % 4;
                    if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && i == 0)    
                    {
                        TxtBlOutInfo2.Text += Environment.NewLine;
                    }
                    else if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && i == 0)
                    {
                        TxtBlOutInfo2.Text += str;
                    }
                    if (str != "" || str != " " || str != "\t" || str !="!")
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
                                textx = $@"sUTm({IDNew})%rXL=";
                                texty = $@"sUTm({IDNew})%rYL=";
                                textz = $@"sUTm({IDNew})%rZL=";
                                if (intxyz == 0)
                                {
                                    TxtBlOutInfo2.Text += "\t" + textx + numberx + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    TxtBlOutInfo2.Text += "\t" + texty + numbery + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {
                                    TxtBlOutInfo2.Text += "\t" + textz + numberz + "\n";
                                    intxyz = 0;
                                    IDNew = IDNew + 1;
                                    IDNewText2 = IDNew;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    TxtBlkNumberKoll.Text = Convert.ToString(IDNew - 1);
                                }
                            }
                        }                        
                        if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && (i % 4 == 0) && i !=0)
                        {
                            TxtBlOutInfo2.Text += str;
                        }
                        else if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && (i % 4 == 0) && i!= 0)
                        {
                            TxtBlOutInfo2.Text += Environment.NewLine;
                        }                       
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } //не рабоает*/

        /*  public async void TextReadNewIDSpeed() //NewSpedStringBulder Добавление с ID 1 и до бесконечности
        {
            //TextNew = TxtBlOutInfo.Text;
            //string TexNew2 = TextNew;
            TxtBlOutInfo2.Text += await Task.Run(localReadInfoCommnet);
            TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);
           
            string localReadInfoCommnet()
            {
                StringBuilder infoBuilder = new StringBuilder();
                int intxyz = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                string[] lines = TextNew.Split('\n');
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
                    if (str != "" || str != " " || str != "\t" || str != "!" || str !="\r")
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
                            //Сделать проверку на длинну id
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
                                    // TxtBlOutInfo2.Text += "\t" + textx + numberx + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    // infoBuilder.Append("\t" + texty + numbery + "\n");
                                    infoBuilder.Append("\t" + texty + numbery);
                                    //TxtBlOutInfo2.Text += "\t" + texty + numbery + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {
                                    //infoBuilder.Append("\t" + textz + numberz + "\n");
                                    // TxtBlOutInfo2.Text += "\t" + textz + numberz + "\n";
                                    infoBuilder.AppendLine("\t" + textz + numberz);
                                    //infoBuilder.AppendLine();
                                    intxyz = 0;
                                    IDNewText2 = IDNewText2 + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                   // TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);
                                    //Thread.Sleep(1);

                                }
                            }
                        }
                    }
                }
                infoBuilder.Remove(infoBuilder.Length - 2, 1);
                return infoBuilder.ToString();
            }
        }*/

        /*  public async void TextReadNewIDSpeedDell() //NewSpedStringBulder Добавление с ID 1 и до бесконечности
        {
            //TextNew = TxtBlOutInfo.Text;
            //string TexNew2 = TextNew;
            textnefordell += await Task.Run(localReadInfoCommnet);
            TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);

            string localReadInfoCommnet()
            {
                StringBuilder infoBuilder = new StringBuilder();
                int intxyz = 0;
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;
                string[] lines = TextNew.Split('\n');
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
                            //Сделать проверку на длинну id
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
                                    // TxtBlOutInfo2.Text += "\t" + textx + numberx + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    // infoBuilder.Append("\t" + texty + numbery + "\n");
                                    infoBuilder.Append("\t" + texty + numbery);
                                    //TxtBlOutInfo2.Text += "\t" + texty + numbery + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {
                                    //infoBuilder.Append("\t" + textz + numberz + "\n");
                                    // TxtBlOutInfo2.Text += "\t" + textz + numberz + "\n";
                                    infoBuilder.AppendLine("\t" + textz + numberz);
                                    //infoBuilder.AppendLine();
                                    intxyz = 0;
                                    IDNewText2 = IDNewText2 + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    // TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);
                                    //Thread.Sleep(1);

                                }
                            }
                        }
                    }
                }
                infoBuilder.Remove(infoBuilder.Length - 2, 1);
                return infoBuilder.ToString();
            }
        }*/

        /* public void TextReadOfNewIDText()// Новая форма 
        {
            try
            {
                TextNew = null;
                TextNew = TxtBlOutInfo.Text;
                int intxyz = 0;               
                int intoldnumber = 0;
                int numbecheack = 0;
                string IDOld = null;               
                string[] lines = TextNew.Split('\n'); //

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
                       TxtBlOutInfo2.Text += Environment.NewLine;
                    }
                    else if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && i == 0)
                    {
                        TxtBlOutInfo2.Text += str;
                    }
                    if (str != "" || str != " " || str != "\t" || str != "!")
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
                                    TxtBlOutInfo2.Text += "\t" + textx + numberx + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 1)
                                {
                                    TxtBlOutInfo2.Text += "\t" + texty + numbery + "\n";
                                    intxyz++;
                                }
                                else if (intxyz == 2)
                                {
                                    TxtBlOutInfo2.Text += "\t" + textz + numberz + "\n";
                                    intxyz = 0;
                                    IDNewText2 = IDNewText2 + 1;
                                    IDOld = null;
                                    intoldnumber = 0;
                                    TxtBlkNumberKoll.Text = Convert.ToString(IDNewText2 - 1);
                                    //Thread.Sleep(1);
                                }
                            }
                        }
                        if (((str == "!\n") || (str == "!") || (str == "!\r\n") || (str == "!\r\n") || (str == "!\r")) && (i % 4 == 0) && i != 0)
                        {
                            TxtBlOutInfo2.Text += str;
                        }
                        else if (((str != "!\n") && (str != "!") && (str != "!\r\n") && (str != "!\r\n") && (str != "!\r")) && (i % 4 == 0) && i != 0)
                        {
                            TxtBlOutInfo2.Text += Environment.NewLine;
                        }                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } // не рабоатет*/
    }
}
