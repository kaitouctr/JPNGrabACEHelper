// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPNGrabACEHelper;

class Program
{
    public enum EncounterType
    {
        Static,
        Wild
    }
    static void Main(string[] args)
    {
        ushort tid;
        ushort sid;
        uint initialAdvances;
        uint maxAdvances;
        uint seed;
        uint delay;
        EncounterType encounterType;
        while (true)
        {
            try
            {
                Console.Write("Static/Wild: ");
                string? encounterInput = Console.ReadLine();
                if (encounterInput == null)
                {
                    continue;
                }
                switch (encounterInput.ToLower())
                {
                    case "static":
                        encounterType = EncounterType.Static;
                        break;
                    case "wild":
                        encounterType = EncounterType.Wild;
                        break;
                    default:
                        continue;
                }
                break;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("TID: ");
                string? tidInput = Console.ReadLine();
                if (tidInput != null) {
                    tid = ushort.Parse(tidInput);
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while(true)
        {
            try
            {
                Console.Write("SID: ");
                string? sidInput = Console.ReadLine();
                if (sidInput != null)
                {
                    sid = ushort.Parse(sidInput);
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Initial Advances: ");
                string? iAdvancesInput = Console.ReadLine();
                if (iAdvancesInput != null)
                {
                    initialAdvances = uint.Parse(iAdvancesInput);
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Max Advances: ");
                string? mAdvancesInput = Console.ReadLine();
                if (mAdvancesInput != null)
                {
                    maxAdvances = uint.Parse(mAdvancesInput);
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Seed: ");
                string? seedInput = Console.ReadLine();
                if (seedInput != null)
                {
                    seed = Convert.ToUInt32(seedInput, 16);
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        while (true)
        {
            try
            {
                Console.Write("Delay: ");
                string? delayInput = Console.ReadLine();
                if (delayInput != null)
                {
                    delay = uint.Parse(delayInput);
                    break;
                }
                else
                {
                    delay = 0;
                    break;
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        List<Dictionary<string, uint>> pidGenerator;
        switch(encounterType)
        {
            case EncounterType.Static:
                pidGenerator = Static.Generator(seed, initialAdvances, maxAdvances, delay);
                break;
            case EncounterType.Wild:
                pidGenerator = Wild.Generator(seed, initialAdvances, maxAdvances, delay);
                break;
            default:
                return;
        }
        foreach (Dictionary<string, uint> pid in pidGenerator) {
            Dictionary<MonEntry, List<WordEntry>>? results
                = Searcher.DetermineCompatibility(tid, sid, pid["PID"], GameVersion.LeafGreen);
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