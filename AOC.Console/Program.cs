using AOC.Console;
using CommandLine;
using System;
using System.Collections.Generic;
using System.Reflection;

Parser.Default.ParseArguments<CommandLineOptions>(args)
    .WithParsed(o =>
    {
        string paddedDay = o.Day.ToString().PadLeft(2, '0');
        var lines = Utils.ReadInput(o.Year.ToString(), paddedDay, o.InputType.ToString());

        string cSharpType = $"AOC.CSharp.AOC{o.Year}_{paddedDay}";
        string cSharpMethod = $"Solve{o.Part}";

        string fSharpType = $"AOC.FSharp.AOC{o.Year}_{paddedDay}";
        string fSharpMethod = $"solve{o.Part}";

        Assembly cSharpAssembly = typeof(AOC.CSharp.AOC2015_09).Assembly;
        Assembly fSharpAssembly = typeof(AOC.FSharp.AOC2015_01).Assembly;

        var foundMethod =
            cSharpAssembly.GetType(cSharpType)?.GetMethod(cSharpMethod)
            ?? fSharpAssembly.GetType(fSharpType)?.GetMethod(fSharpMethod);

        List<object> invokeParams = new()
        {
            lines,
        };

        if (o.Extra != null)
        {
            invokeParams.Add(o.Extra);
        }

        string result = foundMethod.Invoke(null, invokeParams.ToArray()).ToString();

        Console.WriteLine(result);
    });