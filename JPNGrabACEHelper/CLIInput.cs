using System;
using System.Globalization;

namespace JPNGrabACEHelper;

internal class CLIInput
{
    internal enum EncounterType
    {
        Static,
        Wild
    }
    internal static GameVersion GetGameVersion()
    {
        string? userInput;
        do
        {
            Console.Write("Game (FireRed (0) / LeafGreen (1)): ");
            userInput = Console.ReadLine();
        } while (userInput != "0" && userInput != "1");
        switch(userInput)
        {
            case "0":
                return GameVersion.FireRed;
            case "1":
                return GameVersion.LeafGreen;
            default:
                return GameVersion.FireRed;
        }
    }
    internal static EncounterType GetEncounterType()
    {
        string? userInput;
        do
        {
            Console.Write("Encounter Type (Static (0) / Wild (1)): ");
            userInput = Console.ReadLine();
        } while (userInput != "0" && userInput != "1");
        switch (userInput)
        {
            case "0":
                return EncounterType.Static;
            case "1":
                return EncounterType.Wild;
            default:
                return EncounterType.Static;
        }
    }
    internal static uint NumberInputLoop(string prompt)
    {
        uint output;
        while (true) { 
            Console.Write($"{prompt}: ");
            if (uint.TryParse(Console.ReadLine(), out output))
            {
                break;
            }
            else
            {
                Console.WriteLine("Bad input");
            }
        }
        return output;
    }

    internal static uint HexNumberInputLoop(string prompt)
    {
        uint output;
        while (true)
        {
            Console.Write($"{prompt}: ");
            if (uint.TryParse(Console.ReadLine(),
                              NumberStyles.HexNumber,
                              CultureInfo.InvariantCulture,
                              out output))
            {
                break;
            }
            else
            {
                Console.WriteLine("Bad input");
            }
        }
        return output;
    }
}
