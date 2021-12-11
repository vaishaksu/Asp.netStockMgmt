using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.Controllers
{
    public static class MySession
    {
        public static void SetObject<T>(this ISession session, string key, T value) {
            string strvalue = JsonConvert.SerializeObject(value);
            session.SetString(key, strvalue);
        }

        public static T GetObject<T>(this ISession session, string key) {
            var valJson = session.GetString(key);
            return JsonConvert.DeserializeObject<T>(valJson);
        }
    }
}
