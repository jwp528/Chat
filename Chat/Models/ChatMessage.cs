using Chat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatMessage
{
    public ChatMessage() { }

    public ChatMessage(OpenAI_MessageRoles role)
    {
        Role = role.ToString();
    }

    public string Role { get; set; }

    public string Content { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(new { Role, Content });
    }
}
