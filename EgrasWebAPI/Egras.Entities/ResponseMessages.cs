using Newtonsoft.Json;

namespace Egras.Entities
{
    public class ResponseMessages
    {
        public string Message { get; set; }
        public string status { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
