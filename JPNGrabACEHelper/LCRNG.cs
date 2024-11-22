// SPDX-License-Identifer: MIT

using System;

namespace JPNGrabACEHelper;
class PokeRNG(uint seed)
{
    public uint State = seed;

    public ushort Next16(uint adv = 1)
    {
        return (ushort)(Next(adv) >> 16);
    }

    public uint Next(uint adv = 1)
    {
        for (int i = 0; i < adv; i++)
        {
            State = 0x41C64E6D * State + 0x6073;
        }
        return State;
    }
}