using System;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

/*This class is made to set session
 */

namespace PassbookManagement.Framework
{
    //session extension
    public class SessionHelper
    {
        
        public static void SetSession(HttpContext context, SessionData data)
        {
            context.Session.SetString("loginSession", JsonConvert.SerializeObject(data));
        }

        public static SessionData GetCurrentData(ISession session)
        {
            var data = session.GetString("loginSession");
            if (data == null)
                return null;
            else
                return JsonConvert.DeserializeObject(data) as SessionData;
        }
    }
}
