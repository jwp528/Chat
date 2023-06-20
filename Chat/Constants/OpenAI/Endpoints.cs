using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Constants.OpenAI;

public static class Endpoints
{
    private const string BASE_URL = "https://api.openai.com";

    public const string VERSION = "v1";

    public const string COMPLETIONS = $"{BASE_URL}/{VERSION}/completions";

    public const string CHAT_COMPLETIONS = $"{BASE_URL}/{VERSION}/chat/completions";
}
