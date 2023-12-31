﻿using System.Text;
using Newtonsoft.Json;

if (args.Length > 0)
{
    HttpClient client = new();

//askGPT2 - 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
    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");

    var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \""+ args[0] +"\",\"temperature\": 1,\"max_tokens\": 100}",
    Encoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/completions", content);

    string responseString = await response.Content.ReadAsStringAsync();
    try
    {
        var dynamicData = JsonConvert.DeserializeObject<dynamic>(responseString);
        string neededWords = dynamicData!.choices[0].text;
        string guess = GuessCommand(neededWords);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"--> My guess at the command prompt is: {guess}");
        Console.ResetColor();
    }
    catch (System.Exception ex)
    {
        
        Console.WriteLine($"--> Could not deserialize the JSON: {ex.Message}");
    }

    //Console.WriteLine(responseString);
}
else
{
    Console.WriteLine("--->You need to provide some input");
}

static string GuessCommand(string raw)
{
    Console.WriteLine("--> GPT 3 API returned text:");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(raw);

    var lastIndex = raw.LastIndexOf('\n');
    string guess =raw.Substring(lastIndex + 1);
    Console.ResetColor();

    TextCopy.ClipboardService.SetText(guess);

    return guess;
}