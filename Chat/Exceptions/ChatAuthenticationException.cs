using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Exceptions;

public class ChatAuthenticationException : Exception
{
    public string query { get; set; }

    public ChatAuthenticationException(string message) 
        :base(message) { }

    public ChatAuthenticationException(string message, string query)
        :base(message)
    {
        this.query = query;
    }
}
