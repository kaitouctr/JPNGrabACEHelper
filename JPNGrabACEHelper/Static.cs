// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

internal class Static
{
    public static List<Dictionary<string, uint>> Generator(
        uint seed,
        uint initialAdvances,
        uint maxAdvances,
        uint delay)
    {
        PokeRNG pokeRNG = new(seed);
        PokeRNG go = new(0);
        pokeRNG.Next(initialAdvances + delay);
        List<Dictionary<string, uint>> pids = new((int)maxAdvances + 1);
        for (uint adv = 0; adv <= maxAdvances; adv++)
        {
            go.State = pokeRNG.State;
            uint pid = MethodPID.Generate(go);
            Dictionary<string, uint> entry = new Dictionary<string, uint>();
            entry.Add("Advance", (initialAdvances + adv));
            entry.Add("PID", pid);
            pids.Add(entry);
            pokeRNG.Next();
        }
        return pids;
    }
}
