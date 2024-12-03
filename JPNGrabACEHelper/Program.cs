// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace JPNGrabACEHelper;


class Program
{
    static void Main(string[] args)
    {
        GameVersion game = CLIInput.GetGameVersion();
        CLIInput.EncounterType encounterType = CLIInput.GetEncounterType();
        ushort tid = (ushort)(CLIInput.NumberInputLoop("TID") & 0xFFFF);
        ushort sid = (ushort)(CLIInput.NumberInputLoop("SID") & 0xFFFF);
        uint initialAdvances = CLIInput.NumberInputLoop("Initial Advances");
        uint maxAdvances = CLIInput.NumberInputLoop("Max Advances");
        uint seed = CLIInput.HexNumberInputLoop("Seed");
        uint delay = CLIInput.NumberInputLoop("Delay");
        
        IEnumerable<uint> pidGenerator;
        switch(encounterType)
        {
            case CLIInput.EncounterType.Static:
                pidGenerator = Static.Generator(seed, initialAdvances, maxAdvances, delay);
                break;
            case CLIInput.EncounterType.Wild:
                pidGenerator = Wild.Generator(seed, initialAdvances, maxAdvances, delay);
                break;
            default:
                return;
        }
        Dictionary<uint, uint> results = [];
        foreach (
            (int advance, uint pid) in pidGenerator
                                       .Select((x, i) => (i, x)))
        {
            Dictionary<MonEntry, WordEntry>? searcherResults
                = Searcher.DetermineCompatibility(tid, sid, pid, game);
            if (searcherResults == null || !(searcherResults.Count > 0))
            {
                continue;
            }
            results.Add((initialAdvances + (uint)advance), pid);
        }
        string output = string.Join("\n", 
                (
                 from entry in results
                 select $"Advance: {entry.Key} | PID: {entry.Value:X8}"
                )
            );
        Console.WriteLine(output);
        Console.Write("Press any key to close this window…");
        Console.ReadKey();
    }
}