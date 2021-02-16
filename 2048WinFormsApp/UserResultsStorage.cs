using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace _2048WinFormsApp
{
    public class UserResultsStorage
    {
        public static string path = "userResults.json";
        public static string pathBest = "bestResult.txt";
        public static void Add(User user)
        {
            var userResults = GetAll();
            userResults.Add(user);
            Save(userResults);
        }

        public static List<User> GetAll()
        {
            if (!FileProvider.Exists(path))
            {
                return new List<User>();
            }
            var fileData = FileProvider.Show(path);

            var userResults = JsonConvert.DeserializeObject<List<User>>(fileData);

            return userResults;
        }

        static void Save(List<User> userResults)
        {
            var jsonData = JsonConvert.SerializeObject(userResults, Formatting.Indented);
            FileProvider.Replace(path, jsonData);

        }

        public static void SaveBestUser(User bestUser)
        {
            var writer = new StreamWriter(pathBest, false);
            writer.WriteLine(bestUser.Name);
            writer.WriteLine(bestUser.Score);
            writer.Close();
        }

        public static User GetBestUser()
        {
            if (File.Exists(pathBest))
            {
                var reader = new StreamReader(pathBest);
                string bestUserName = reader.ReadLine();
                string bestScore = reader.ReadLine();
                var bestUser = new User(bestUserName);
                bestUser.Score = Convert.ToInt32(bestScore);
                reader.Close();
                return bestUser;
            }
            else
            {
                return new User("");
            }
        }
        
    }
}
