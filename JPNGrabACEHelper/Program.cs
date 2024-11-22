// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

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
        
        List<Dictionary<string, uint>> pidGenerator;
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
        foreach (Dictionary<string, uint> pid in pidGenerator) {
            Dictionary<MonEntry, List<WordEntry>>? results
                = Searcher.DetermineCompatibility(tid, sid, pid["PID"], game);
            if (results == null) {
                continue;
            }
            if (results.Count == 0) {
                continue;
            }
            Console.WriteLine($"{pid["Advance"]}: {pid["PID"]:X8}");
        }
    }
}