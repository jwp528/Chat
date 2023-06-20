using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Constants;

public static class SD
{
    public const string APP_NAME = "Chat";

    public static List<string> EXIT_TRIGGERS = new()
    {
        "goodbye",
        "bye",
        "quit",
        "q",
        "exit",
    };
}
