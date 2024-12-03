// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;
using System.Linq;

namespace JPNGrabACEHelper;


public enum AdjustmentType
{
    EV,
    Experience
}

internal class Searcher
{
    public static AdjustmentType? CheckPIDSubstructure(uint pid)
    {
        uint pidSStruct = pid % 24;
        uint[] evSStructs = [8, 22];
        uint[] expSStructs = [6, 7, 12, 13, 18, 19];
        if (evSStructs.Contains(pidSStruct))
        {
            return AdjustmentType.EV;
        }
        if (expSStructs.Contains(pidSStruct))
        {
            return AdjustmentType.Experience;
        }
        return null;
    }

    public static Dictionary<MonEntry, WordEntry>? CalculateMonWord(
        ushort tid,
        ushort sid,
        uint pid,
        GameVersion game)
    {
        Dictionary<MonEntry, WordEntry> results = [];
        uint otid = (uint)((sid << 16) | tid);
        ushort encryptionKey = (ushort)((otid ^ pid) & 0xFFFF);
        MonEntry[] glitchMonList;
        switch (game)
        {
            case GameVersion.FireRed:
                glitchMonList = GlitchSpecies.fireRedData;
                break;
            case GameVersion.LeafGreen:
                glitchMonList = GlitchSpecies.leafGreenData;
                break;
            default:
                return null;
        }
        foreach (MonEntry mon in glitchMonList)
        {
            ushort wordIndex = (ushort)(mon.Index ^ encryptionKey);
            WordEntry? word = Array.Find(EasyChatSystem.ECSWords, (entry => entry.Index == wordIndex));
            if (word == null)
            {
                continue;
            }
            results.Add(mon, word);
        }
        return results;
    }
}
