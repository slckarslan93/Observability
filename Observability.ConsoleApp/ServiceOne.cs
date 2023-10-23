using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observability.ConsoleApp
{
    public class ServiceOne
    {
        static HttpClient httpClient = new HttpClient();
        public async Task<int> MakeRequestToGoogle()
        {

            using var activity = ActivitySourceProvider.Source.StartActivity(kind:System.Diagnostics.ActivityKind.Producer,name: "CustomMakeRequestToGoogle");
            {
                try
                {
                    var eventTags = new ActivityTagsCollection();


                    activity?.AddEvent(new("google'a şstek başladı", tags: eventTags));
                    activity?.AddTag("request.schema", "https");
                    activity?.AddTag("request.method", "get");

                    var result = await httpClient.GetAsync("http://www.goggle.com");

                    var responseContent = await result.Content.ReadAsStringAsync();

                    activity.AddTag("response.lenght", responseContent.Length);

                    eventTags.Add("google body length", responseContent.Length);
                    activity?.AddEvent(new("google'a istek tamamlandı", tags: eventTags));

                    var serviceTwo = new ServiceTwo();

                    var fileLenght = serviceTwo.WriteToFile("Merhaba Dünya");

                    return responseContent.Length;
                }
                catch (Exception ex)
                {

                    activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                    return -1;
                }

            }

        }
    }
}
