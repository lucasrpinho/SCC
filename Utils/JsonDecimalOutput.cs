using System.Globalization;
using Newtonsoft.Json;

namespace Utils
{
    public class JsonDecimalOutput : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {            
            return objectType == typeof(double);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(string.Format("{0:N2}", value));
        }   

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
