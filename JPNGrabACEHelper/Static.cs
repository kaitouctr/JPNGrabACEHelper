// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

internal class Static
{
    public static IEnumerable<uint> Generator(
        uint seed,
        uint initialAdvances,
        uint maxAdvances,
        uint delay)
    {
        PokeRNG pokeRNG = new(seed);
        PokeRNG go = new(0);
        pokeRNG.Next(initialAdvances + delay);
        for (uint adv = 0; adv <= maxAdvances; adv++)
        {
            go.State = pokeRNG.State;
            uint pid = MethodPID.Generate(go);
            yield return pid;
            pokeRNG.Next();
        }
    }
}
