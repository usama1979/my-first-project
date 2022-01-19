using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using HtmlAgilityPack;

namespace USDbot
{
    internal class Program
    {
        static TelegramBotClient botClient = new TelegramBotClient("5068770631:AAElTCbwnhvvLDPocZo_khTJn3ji2VAOYy4");
        static void Main(string[] args)
        {
            botClient.OnMessage += botClient_OnMessage;
            botClient.StartReceiving();

            Console.ReadKey();
        }
        private static void botClient_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "/start")
            {
                botClient.SendTextMessageAsync(e.Message.Chat.Id, "Hi, " + e.Message.Chat.FirstName + "\n Press: /azansobh\n Press: /azanzohr\n Press: /azanmaghreb");
            }
            if (e.Message.Text == "/azansobh")
            {

                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://www.bahesab.ir/time/prayer/");
                var title1 = document.DocumentNode.SelectSingleNode("//span[@id='azan-time1']").InnerText;
                botClient.SendTextMessageAsync(e.Message.Chat.Id, " azan sobh :" + title1);
            }
            if (e.Message.Text == "/azanzohr")
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://www.bahesab.ir/time/prayer/");
                var title2 = document.DocumentNode.SelectSingleNode("//span[@id='azan-time3']").InnerText;
                botClient.SendTextMessageAsync(e.Message.Chat.Id, " azan zohr :" + title2);
            }
            if (e.Message.Text == "/azanmaghreb")
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("https://www.bahesab.ir/time/prayer/");
                var title3 = document.DocumentNode.SelectSingleNode("//span[@id='azan-time5']").InnerText;
                botClient.SendTextMessageAsync(e.Message.Chat.Id, " azan zohr :" + title3);

            }
        }
    }
}

