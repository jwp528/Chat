using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Constants.OpenAI;

public static class ChatModels
{
    public const string GPT4 = "gpt-4";

    public const string GPT4_0613 = "gpt-4-0613";

    public const string GPT4_32K = "gpt-4-32k";

    public const string GPT4_32K_0613 = "gpt-4-32k-0613";

    public const string GPT3_5_TURBO = "gpt-3.5-turbo";

    public const string GPT3_5_TURBO_0613 = "gpt-3.5-turbo-0613";

    public const string GPT3_5_TURBO_16K = "gpt-3.5-turbo-16k";

    public const string GPT3_5_TURBO_16K_0613 = "gpt-3.5-turbo-16k-0613";

    public static List<string> All => new()
    {
        GPT4,
        GPT4_0613,
        GPT4_32K,
        GPT4_32K_0613,
        GPT3_5_TURBO,
        GPT3_5_TURBO_0613,
        GPT3_5_TURBO_16K,
        GPT3_5_TURBO_16K_0613,
    };
}
