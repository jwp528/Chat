using Chat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatHistory
{
    public ChatHistory() { }

    public ChatHistory(OpenAI_MessageRoles role)
    {
        roleEnum = role;
    }

    private OpenAI_MessageRoles roleEnum { get; set; }

    public string role
    {
        get
        {
            return roleEnum.ToString();
        }
    }

    public string content { get; set; }

    public string name { get; set; }

    public object function_call { get; set; }

}
