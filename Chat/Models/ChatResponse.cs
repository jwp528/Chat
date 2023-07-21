using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatResponse
{
    public string Id { get; set; }

    public string Object { get; set; }

    public long Created { get; set; }

    public ChatChoice[] Choices { get; set; }

    public ChatUsage Usage { get; set; }
}
