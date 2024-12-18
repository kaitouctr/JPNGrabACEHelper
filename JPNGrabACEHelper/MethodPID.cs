﻿// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

internal class MethodPID
{
    public static string[] pidSStructs = [
        "GAEM",
        "GAME",
        "GEAM",
        "GEMA",
        "GMAE",
        "GMEA",
        "AGEM",
        "AGME",
        "AEGM",
        "AEMG",
        "AMGE",
        "AMEG",
        "EGAM",
        "EGMA",
        "EAGM",
        "EAMG",
        "EMGA",
        "EMAG",
        "MGAE",
        "MGEA",
        "MAGE",
        "MAEG",
        "MEGA",
        "MEAG",
    ];
    public static uint Generate(PokeRNG rng)
    {
        ushort low = rng.Next16();
        ushort high = rng.Next16();
        return (uint)((high << 16) | low);
    }
}
