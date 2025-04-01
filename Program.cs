    ```csharp
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Hosting;

    var builder = WebApplication.CreateBuilder(args);
    var app = builder.Build();

    app.UseStaticFiles();

    app.MapGet("/", () => "سلام! به چت‌بات C# من خوش اومدی! صفحه چت رو تو /chat-page باز کن.");
    app.MapGet("/chat-page", () => Results.File("wwwroot/chat.html", "text/html"));
    app.MapGet("/chat", (HttpContext context) =>
    {
        string question = context.Request.Query["q"].ToString().ToLower();
        string answer = GetAnswer(question);
        return $"من: {answer}";
    });

    app.Run();

    static string GetAnswer(string question)
    {
        if (string.IsNullOrEmpty(question))
            return "هی! چیزی نپرسیدی! یه سوال در مورد C# بپرس!";
        if (question.Contains("if") || question.Contains("شرط"))
            return "دستور if برای تصمیم‌گیریه! مثلاً:\nint x = 10;\nif (x > 5) { Console.WriteLine(\"بزرگ‌تر از 5!\"); }\nساده‌ست، نه؟";
        if (question.Contains("for") || question.Contains("حلقه for"))
            return "حلقه for برای تکراره! مثلاً:\nfor (int i = 0; i < 5; i++) { Console.WriteLine(i); }\nاز 0 تا 4 می‌ره!";
        if (question.Contains("while"))
            return "حلقه while تا وقتی شرط درسته کار می‌کنه:\nint i = 0;\nwhile (i < 3) { Console.WriteLine(i); i++; }";
        return "سوالتو واضح‌تر بپرس! مثلاً 'if چیه؟' یا 'حلقه for چطوره؟'";
    }
    ```
