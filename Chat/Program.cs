// See https://aka.ms/new-console-template for more information
using Chat;
using Chat.Constants;
using Chat.Exceptions;
using Chat.Helpers;
using Chat.Models;
using Chat.Services;
using CommandLine;


var parser = new CommandLine.Parser();

var result = parser.ParseArguments<Options>(args);

await result.WithParsedAsync(HandleOptions);


async Task HandleOptions(Options options)
{
    if (options.Query is null)
    {
        options.Query = string.Join(' ', args);
    }

    while (true)
    {
        if (string.IsNullOrEmpty(options.Query))
        {
            Console.Write("Chat:>");
            options.Query = Console.ReadLine();
        }

        if (SD.EXIT_TRIGGERS.Contains(options.Query))
        {
            break;
        }

        if (options.Query == "update")
        {
            Helper.UpdateChat();
            options.Query = "";
            continue;
        }

        try
        {
            ChatRequest request = new ChatRequest()
            {
                Query = options.Query,
                Endpoint = options.Endpoint,
                Model = options.Model,
            };

            ChatService chat = new ChatService();
            var response = await chat.Chat(request);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n{response.Choices[0].Message.Content}\n");
            Console.ResetColor();

            options.Query = string.Empty;
        }
        catch (ChatAuthenticationException exception)
        {
            Console.Write($"{exception.Message}>");
            var key = Console.ReadLine();

            ChatService.SetKey(key);
        }
    }
       
}

void HandleParseError(IEnumerable<Error> errors)
{
    // Handle parse errors if any
    Console.WriteLine("Failed to parse arguments.");
}