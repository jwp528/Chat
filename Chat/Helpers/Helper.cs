using Chat.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Chat.Helpers;

public static class Helper
{
    public static object[] GetMessages(List<ChatMessage> chatHistory, string userMessage)
    {
        List<object> messages = new List<object>();

        foreach (ChatMessage message in chatHistory)
        {
            messages.Add(new { role = message.Role, content = message.Content });
        }

        return messages.ToArray();
    }

    // update the chat tool
    public static void UpdateChat()
    {
        // adjust the version
        var csproj = XDocument.Load("C:/cmd_extensions/Chat/Chat/Chat.csproj");
        var versionTag = csproj.Descendants("Version").Single();
        var versionParts = versionTag.Value.Split(".");

        int major = int.Parse(versionParts[0]);
        int minor = int.Parse(versionParts[1]);
        int build = int.Parse(versionParts[2]);

        // increment the build.
        versionTag.Value = $"{major}.{minor}.{++build}";

        // run the update file
        string updateFilePath = @"C:\cmd_extensions\chat\chat\update.cmd";

        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = "cmd.exe";
        startInfo.Verb = "runas";
        startInfo.Arguments = "/c " + updateFilePath;

        Process.Start(startInfo);
    }
}
