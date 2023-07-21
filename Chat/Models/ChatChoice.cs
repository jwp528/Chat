using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models;

public class ChatChoice
{
    public int Index { get; set; }

    public ChatMessage Message { get; set; }

    public string FinishReason { get; set; }
}
