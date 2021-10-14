using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;

namespace BasterBot
{
    class FullWork
    {
        Halper _halper;
        public FullWork(Halper halper)
        {
            _halper = halper;
            Talk();
        }

        private void Talk()
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);
            api.Authorize(new ApiAuthParams
            {
                AccessToken = _halper.accesToken
            });


            string[] list = File.ReadAllLines(_halper.fileDialogs);
            Random random = new Random();
            List<int> listId = Enumerable.Range(0, 17).ToList();

            while (true)
            {
                int startIndexStringForDialogs = random.Next(1, list.Length);
                int count = random.Next(1, _halper.maxCountMassage);

                for (int i = startIndexStringForDialogs; i < startIndexStringForDialogs + count; i++)
                {

                    for (int a = 0; a < listId.Count; a++)
                    {
                        try
                        {
                            Console.WriteLine(api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                            {
                                GroupId = _halper.groupId,
                                RandomId = new Random().Next(), 
                                ChatId = listId[a],
                                Message = list[i],
                            }));
                        }
                        catch
                        {
                            listId.Remove(listId[a]);
                        }
                    }
                    int c = random.Next(1000, 5000);
                    System.Threading.Thread.Sleep(c);
                }
                int l = random.Next(300000, 600000);
                System.Threading.Thread.Sleep(l);
            }

        }

    }
    }

