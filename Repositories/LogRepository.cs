using login_system.Interfaces;
using login_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login_system.Repositories
{
    internal class LogRepository : ILog
    {
        private const string path = "database/log.txt";

        public LogRepository()
        {
            CreateFolderFile(path);
        }

        private static string PrepareLine(User user,string status)
        {
            return $"O usuário {user.Name} ({user.Id}) {status} no sistema às {DateTimeOffset.Now.ToString("T")} do dia {DateTimeOffset.Now.ToString("d")}";
        }

        public static void CreateFolderFile(string path)
        {
            string folder = path.Split("/")[0];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        public void RegisterAccess(User user, string status)
        {
            string line = PrepareLine(user,status);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(line);
            }

        }
    }
}
