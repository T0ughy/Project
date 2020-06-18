using Newtonsoft.Json;
using Project_Doctor_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_Doctor_Client.DataProviders
{
    public static class PersonDataProvider
    {
        private static string _url = "http://localhost:5000/api/person";

        public static IList<Person> GetPeople()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_url).Result;

                if (response.IsSuccessStatusCode)
                {
                    var rawData = response.Content.ReadAsStringAsync().Result;
                    var people = JsonConvert.DeserializeObject<IList<Person>>(rawData);

                    return people;
                }
                else
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void CreatePerson(Person person)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(person);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = client.PostAsync(_url, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void UpdatePerson(Person person)
        {
            using (var client = new HttpClient())
            {
                var rawData = JsonConvert.SerializeObject(person);
                var content = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = client.PutAsync(_url + "/" + person.Id, content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(response.StatusCode.ToString());
                }
            }
        }

        public static void DeletePerson(long id)
        {
            using (var client = new HttpClient())
            {
                var respone = client.DeleteAsync(_url + "/" + id).Result;

                if (!respone.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(respone.StatusCode.ToString());
                }
            }
        }
    }
}
