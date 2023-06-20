using Chat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatRequest
{
    public OpenAI_Endpoints Endpoint { get; set; } = OpenAI_Endpoints.CHAT_COMPLETIONS;

    public OpenAI_Models Model { get; set; } = OpenAI_Models.GPT4;

    public string Query { get; set; }
}
