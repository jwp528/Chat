using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Constants;

public static class EnvironmentVariables
{
    public const string REGISTRY_KEY = "HKEY_CURRENT_USER\\Environment";
    public const string OPENAI_API_KEY = $"{SD.APP_NAME}_OPENAI_KEY";
}
