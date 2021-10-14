using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            GetTextFromTxtFiledInZipArchive("Иван Иванов [001245678]", "полный путь до каталога с полученными файлами", "полный путь до файла для результата");
           // GetTextFromTxtFiledInZipArchive метод для зип архивов с текстовыми файлами
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
        static void GetTextFromTxtFiledInZipArchive(string nameAndId, string pathToArchive, string pathToResultFile)
        {
            List<string> strFull = new();
            List<string> result = new();
            string[] arrFile = Directory.GetFiles(@pathToArchive);

            foreach (var item in arrFile)
            {
                strFull.AddRange(File.ReadAllLines(item));
            }
            for (int i = 0; i < strFull.Count; i++)
            {
                if (strFull[i].Trim() == nameAndId)
                {
                    result.Add(strFull[i + 1].Contains(']') ? strFull[i + 3].Trim() : strFull[i + 1].Trim());
                }
            }
            result = result.Distinct().ToList();
            using (StreamWriter sw = new StreamWriter(pathToResultFile, false, System.Text.Encoding.Default))
            {
                foreach (var item in result)
                {
                    if (!string.IsNullOrEmpty(item) && !item.Contains('[') && !item.Contains(']'))
                        sw.WriteLine(item);
                }
            }
        }
    }
}
