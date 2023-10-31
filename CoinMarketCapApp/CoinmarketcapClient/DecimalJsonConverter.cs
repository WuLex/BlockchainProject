using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoobsMuc.Coinmarketcap.Client
{
    public class DecimalJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(decimal));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            decimal result = 0;
            if (reader.Value == null) return result;
            decimal.TryParse(reader.Value.ToString(), out result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
