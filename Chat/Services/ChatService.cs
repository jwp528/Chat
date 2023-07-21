using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Chat.Constants;
using Chat.Constants.OpenAI;
using Chat.Enums;
using Chat.Exceptions;
using Chat.Helpers;
using Chat.Models;
using Microsoft.Win32;

namespace Chat.Services;
public class ChatService
{
    private readonly HttpClient client;
    private const int HISTORY_LIMIT = 10;
    private Queue<ChatMessage> messageQueue;
    public ChatService()
    {
        string key = (string) Registry.GetValue("HKEY_CURRENT_USER\\Environment", $"{EnvironmentVariables.OPENAI_API_KEY}", string.Empty);

        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ChatAuthenticationException("Please provide your OpenAI API key");
        }

        client = new HttpClient();
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");
        messageQueue = new Queue<ChatMessage>();
    }

    private string ParseEndpoint(OpenAI_Endpoints endpoint)
    {
        return endpoint switch
        {
            //OpenAI_Endpoints.COMPLETIONS => Endpoints.COMPLETIONS,
            OpenAI_Endpoints.CHAT_COMPLETIONS => Endpoints.CHAT_COMPLETIONS,
            _ => Endpoints.CHAT_COMPLETIONS
        };
    }

    // commented out models are models that I haven't tested or have received 404 errors for.
    private string ParseModel(OpenAI_Models model)
    {
        return model switch
        {
            //OpenAI_Models.GPT4 => ChatModels.GPT4,
            //OpenAI_Models.GPT4_0613 => ChatModels.GPT4_0613,
            //OpenAI_Models.GPT4_32K => ChatModels.GPT4_32K,
            //OpenAI_Models.GPT4_32K_0613 => ChatModels.GPT4_32K_0613,
            //OpenAI_Models.GPT3_5_TURBO_0613 => ChatModels.GPT3_5_TURBO_0613,
            //OpenAI_Models.GPT3_5_TURBO_16K => ChatModels.GPT3_5_TURBO_16K,
            //OpenAI_Models.GPT3_5_TURBO_16K_0613 => ChatModels.GPT3_5_TURBO_16K_0613,
            OpenAI_Models.GPT3_5_TURBO => ChatModels.GPT3_5_TURBO,
            _ => ChatModels.GPT3_5_TURBO
        };
    }

    public async Task<ChatResponse> Chat(ChatRequest request)
    {
        ChatMessage message = new()
        {
            Role = "user",
            Content = request.Query
        };

        messageQueue.Enqueue(message);

        if (messageQueue.Count >= HISTORY_LIMIT)
        {
            messageQueue.Dequeue();
        }

        var requestBody = new
        {
            model = ParseModel(request.Model),
            messages = messageQueue.ToList()
        };

        string endpoint = ParseEndpoint(request.Endpoint);

        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, requestBody);
            if (!response.IsSuccessStatusCode)
            {
                // TODO: handle potential errors
            }

            ChatResponse chatResponse = await response.Content.ReadFromJsonAsync<ChatResponse>();

            messageQueue.Enqueue(chatResponse.Choices[0].Message);

            return chatResponse;

        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static void SetKey(string apikey)
    {
        // TODO: refactor to use User secrets to make this multi platform.
        Registry.SetValue(EnvironmentVariables.REGISTRY_KEY, EnvironmentVariables.OPENAI_API_KEY, apikey);
    }
}