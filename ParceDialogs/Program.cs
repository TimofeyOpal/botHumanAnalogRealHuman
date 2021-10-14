using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ParceDialogs
{
    class Program
    {
        static void Main(string[] args)
        {
            ParceWriteText("1111111", "C:/json.json", "D:/result.txt");
            //в путях до файлов указываете полные пути до них
            // idUser - ID пользователя вк 

        }




        static void ParceWriteText(string idUser, string pathJsonFile,string pathResultFile )
        {
            string text = $"    \"user_id\": {idUser},";
            string[] lines = System.IO.File.ReadAllLines(@pathJsonFile);

            List<string> needText = new();
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == text)
                {
                    if (lines[i - 1] != "" || lines[i - 1] == " ")
                    {
                        string txt = lines[i - 1].Remove(0, 13);
                        txt = txt.Remove(txt.Length - 2);
                        needText.Add(txt);
                    }
                }
            }
            StreamWriter f = new StreamWriter(@pathResultFile, false, new UnicodeEncoding());
            for (int i = 0; i < needText.Count; i++)
            {
                if (!string.IsNullOrEmpty(needText[i]))
                {
                    f.WriteLine(needText[i]);
                }
            }
        }    
    }
}
