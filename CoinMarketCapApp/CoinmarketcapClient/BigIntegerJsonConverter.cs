using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using System;

namespace NoobsMuc.Coinmarketcap.Client
{
    public class BigIntegerJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Org.BouncyCastle.Math.BigInteger));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {

            //if (reader.Value.GetType == double)
            //{
            //}
            Int64 largenum =Convert.ToInt64(reader.Value);
            System.Numerics.BigInteger big = (System.Numerics.BigInteger)largenum;
            return new Org.BouncyCastle.Math.BigInteger(big.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }

    //public class BigIntegerConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type objectType)
    //    {
    //        return objectType == typeof(BigInteger);
    //    }

    //    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    //    {
    //        return new BigInteger(System.Convert.FromBase64String((string)reader.Value));
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        writer.WriteValue(new BigInteger((byte[])value));
    //    }
    //}

    //public class BigIntegerJsonConverter : JsonConverter
    //{
    //    public override bool CanConvert(Type type)
    //    {
    //        return type == typeof(BigInteger);
    //    }

    //    public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
    //    {
    //        string value =Convert.ToString(reader.Value);
    //        return new BigInteger(value);
    //    }

    //    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    //    {
    //        BigInteger bigInteger = (BigInteger)value;
    //        writer.WriteValue(bigInteger.ToString());
    //    }
    //}
}
