using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

/* I don't know :))) Maybe this class is made for remembering a session
 * of a user
 */

namespace PassbookManagement.Framework
{
    [Serializable]
    public class SessionData 
    {
        public string Username { get; set; }
        public string Type { get; set; }
       
    }
}
