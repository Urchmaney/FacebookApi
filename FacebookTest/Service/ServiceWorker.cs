using FacebookTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace FacebookTest.Service
{
    public class ServiceWorker
    {
        public static string GetFromAccessTokenUrl(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    var serialiser = new JavaScriptSerializer();
                    TokenModel model = serialiser.Deserialize<TokenModel>(json);
                    return model.access_token;
                }
            }

            catch (Exception e)
            {
                var message = e.Message;
                return null;
            }
            //HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //using(HttpWebResponse response=request.GetResponse() as HttpWebResponse)
            //{
            //    StreamReader reader = new StreamReader(response.GetResponseStream());

            //    string value = reader.ReadToEnd();
            //    foreach(string valuePair in value.Split('&'))
            //    {
            //        UrlDicionary.Add(valuePair.Substring(0, valuePair.IndexOf('=')), valuePair.Substring(valuePair.IndexOf('=') + 1, valuePair.Length - valuePair.IndexOf('=') - 1));
            //    }
            //}

        }

        public static T GetFromUrlClient<T>(string url)
        {

            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    var serialiser = new JavaScriptSerializer();
                    T model = serialiser.Deserialize<T>(json);
                    return model;
                }

            }
            catch (Exception e)
            {
                var message = e.Message;
                return default(T);
            }
        }
    }
}