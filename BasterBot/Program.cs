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
                accesToken = "", // ваш токен
                fileDialogs = @"", //путь до файла с полученными диалогами
                groupId = 111111, // id группы вашего бота
                maxCountMassage = 10 // максимальное количество сообщений за раз
            };

            FullWork work = new(halper);







        }
    }
}
