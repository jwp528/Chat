using Chat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatRequest
{
    public ChatRequest() { }

    public ChatRequest(Options options)
    {
        Endpoint = options.Endpoint;
        Model = options.Model;
        Query = options.Query;
    }

    public OpenAI_Endpoints Endpoint { get; set; } = OpenAI_Endpoints.CHAT_COMPLETIONS;

    public OpenAI_Models Model { get; set; } = OpenAI_Models.GPT3_5_TURBO;

    public string Query { get; set; }
}
