using HunterConsole.Hunter.Response;
using Newtonsoft.Json;
using System.Net;

namespace HunterApi.Hunter
{
    /// <summary>
    /// In order to obtain an API key, create a user account at https://hunter.io this will allow you to
    /// obtain the API key. A free account will give you 50 attempts. We a
    /// re only interested in the email verification
    /// and where the boolean flag is returned if the email address is webmail
    /// </summary>
    internal sealed class HunterClient        
    {
        private readonly string api_key = "YOUR_API_KEY";
        private readonly string BaseUrl = "https://api.hunter.io/v2/";

        /// <summary>
        /// Check if a given email address is deliverable and has been found on the internet. We need to determine
        /// if the email is webmail or not, this API call returns a boolean stating whether the email addrsss is a
        /// free webmail account or not
        /// </summary>
        /// <param name="email">The email address to verify</param>
        /// <returns>Properties that indicate where the email address is webmain or not</returns>
        public async Task<bool> IsWebmail(string email)
        {
            if (!RegexUtilities.IsValidEmail(email))
            {
                throw new FormatException("Invalid email address. Please eneter a valid Email address");
            }
         
            HttpClient client = new HttpClient();
            var root = new Root();

            try
            {

                client.DefaultRequestHeaders.Accept.Clear();
                var query = BaseUrl + $"email-verifier?email={email}&api_key={api_key}";
                var json = await client.GetStringAsync(query);
                root = JsonConvert.DeserializeObject<Root>(json);
            }
            catch (WebException ex)
            {
                var res = ex.Response;

                if (res != null)
                {
                    using (var stream = res.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                    {
                        Console.WriteLine(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Dispose();
            }
            return root.data.webmail;
        }
    }
}
