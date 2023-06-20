using Chat.Enums;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat;

public class Options
{
    [Option('m', "Model", Required = false, HelpText = "Specifies the OpenAI Model to use for the request.")]
    public OpenAI_Models Model { get; set; } = OpenAI_Models.GPT3_5_TURBO;

    [Option('e', "Endpoint", Required = false, HelpText = "Specifies the Endpoint to execute the request at.")]
    public OpenAI_Endpoints Endpoint { get; set; } = OpenAI_Endpoints.CHAT_COMPLETIONS;

    [Option('q', "Query", Required = false, HelpText = "Specify the query you'd like to send.")]
    public string Query { get; set; }
}
