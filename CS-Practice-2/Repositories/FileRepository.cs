using CS_Practice_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CS_Practice_2.Repositories
{
    class FileRepository
    {
        private static readonly string Folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UserStorage");

        public FileRepository()
        {
            if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
        }

        public async Task AddOrUpdateAsync(DBPerson obj)
        {
            var stringObj = JsonSerializer.Serialize(obj);

            using (StreamWriter sw = new(Path.Combine(Folder, obj.Name), false))
            {
                await sw.WriteAsync(stringObj);
            }
        }

        public async Task<DBPerson> GetAsync(string name)
        {
            string stringObj = null;
            string filePath = Path.Combine(Folder, name);

            if (!File.Exists(filePath))
                return null;

            using(StreamReader sr = new StreamReader(filePath))
            {
                stringObj = await sr.ReadToEndAsync();
            }

            return JsonSerializer.Deserialize<DBPerson>(stringObj);
        }

        public async Task<List<DBPerson>> GetAllAsync()
        {
            var res = new List<DBPerson>();

            foreach(var file in Directory.EnumerateFiles(Folder))
            {
                string stringObj = null;

                using(StreamReader sr = new StreamReader(file))
                {
                    stringObj = await sr.ReadToEndAsync();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(stringObj));
            }

            return res;
        }

        public List<DBPerson> GetAll()
        {
            var res = new List<DBPerson>();

            foreach (var file in Directory.EnumerateFiles(Folder))
            {
                string stringObj = null;

                using (StreamReader sr = new StreamReader(file))
                {
                    stringObj = sr.ReadToEnd();
                }

                res.Add(JsonSerializer.Deserialize<DBPerson>(stringObj));
            }

            return res;
        }
    }
}
