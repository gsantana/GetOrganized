using System.IO;
using System.Net;

namespace GetOrganizedTest
{
    internal class WebServiceUtil
    {
        public static HttpWebResponse AuthenticateWithForms(string username,
    string password, string url)
        {
            string parameters = "Email=" + username +
            "&Password=" + password + "&RememberMe=True&returnUrl=localhost";

            return SendWebRequest(url, parameters,
              "application/x-www-form-urlencoded");
        }

        public static HttpWebResponse SendWebRequest(string uri,
          string parameters, string contentType, params Cookie[] cookies)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.CookieContainer = new CookieContainer();
            if (cookies != null)
            {
                foreach (var cookie in cookies)
                {
                    request.CookieContainer.Add(cookie);
                }
            }

            request.AllowAutoRedirect = false;
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = parameters.Length;

            using (var requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII))
            {
                requestWriter.Write(parameters);
            }

            return (HttpWebResponse)request.GetResponse();
        }
    }
}