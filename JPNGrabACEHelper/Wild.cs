// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

internal class Wild
{
    public static List<Dictionary<string, uint>> Generator(
        uint seed,
        uint initialAdvances,
        uint maxAdvances,
        uint delay)
    {
        PokeRNG pokeRNG = new(seed);
        PokeRNG advRNG = new(0);
        pokeRNG.Next(initialAdvances + delay);
        List<Dictionary<string, uint>> pids = new((int)maxAdvances + 1);
        for (uint adv = 0; adv <= maxAdvances; adv++)
        {
            advRNG.State = pokeRNG.State;
            advRNG.Next(2);
            int searchNature = advRNG.Next16() % 25;
            uint pid;
            do
            {
                pid = MethodPID.Generate(advRNG);
            } while ((pid % 25) != searchNature);
            Dictionary<string, uint> entry = new Dictionary<string, uint>();
            entry.Add("Advance", (initialAdvances + adv));
            entry.Add("PID", pid);
            pids.Add(entry);
            pokeRNG.Next();
        }
        return pids;
    }
}
