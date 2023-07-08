using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.Runtime.Remoting.Contexts;
using static System.Net.WebRequestMethods;

namespace BankPiter
{
    internal class Program
    {
        static string AnswerCode;
        static bool _isAllFine;
        static void Main(string[] args)
        {
            transcation(args);
            
        }
        static async void transcation(string[] args)
        {
            using (WebClient webClient = new WebClient())
            {
                TransactionModel newTransact = new TransactionModel(Convert.ToInt32(args[0]), args[1],
                    Convert.ToInt32(args[2]), Convert.ToSingle(args[3]),
                    args[4], Convert.ToInt32(args[5]), args[6]);
                var url = "https://localhost:7011/api/BankTransactions";
                webClient.Headers[HttpRequestHeader.Accept] = "text/plain";
                webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                string data = JsonConvert.SerializeObject(newTransact);
                var response = webClient.UploadString(url, data);
            }
            Random rand = new Random();
            int isAllowed = rand.Next(1, 2);
            if (isAllowed == 1)
            {
                AnswerCode = DateTime.Now.ToString("G");
            }
            else if (isAllowed == 2)
            {
                AnswerCode = "00000000-000000";
            }
            if(isTimeFine())
            {
                _isAllFine = true;
            }

        }
        static bool isTimeFine()
        {
            Random rand = new Random();
            int time = rand.Next(1, 20);
            for (int i = 0; i < time; i++)
            {
                Thread.Sleep(1000);
            }
            if (time <= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
