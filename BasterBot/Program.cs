using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;

namespace BasterBot
{
    class Program
    {
        static void Main(string[] args)
        {

            Halper halper = new()
            {
                accesToken = "",
                fileDialogs = @"С:\WriteLines.txt", // файл с диалогами для бота
                groupId = 1111111, // id группы бота 
                maxCountMassage = 10 // макс количество сообщений
            };

            FullWork work = new(halper);


        }
    }
}
