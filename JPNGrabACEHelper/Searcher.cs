// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

internal class ResultEntry(
    uint advances,
    uint pid,
    Dictionary<MonEntry, List<WordEntry>> results)
{
    public uint Advances { get; } = advances;
    public uint PID { get; } = pid;
    public Dictionary<MonEntry, List<WordEntry>> Results { get; } = results;
}

internal class Searcher
{
    public static Dictionary<MonEntry, WordEntry>? DetermineCompatibility(
        ushort tid,
        ushort sid,
        uint pid,
        GameVersion game)
    {
        Dictionary<MonEntry, WordEntry> results = new();
        uint otid = (uint)((sid << 16) | tid);
        uint pidSStruct = pid % 24;
        ushort encryptionKey = (ushort)((otid ^ pid) & 0xFFFF);
        List<uint> compatibleSStructs = [6, 7, 8, 12, 13, 18, 19, 22];
        if (compatibleSStructs.Contains(pidSStruct))
        {
            List<MonEntry> glitchMonList;
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
            foreach(MonEntry mon in glitchMonList)
            {
                ushort wordIndex = (ushort)(mon.Index ^ encryptionKey);
                WordEntry? word = EasyChatSystem.ECSWords
                    .Find(entry => entry.Index == wordIndex);
                if (word == null)
                {
                    continue;
                }
                results.Add(mon, word);
            }
        }
        return results;
    }
}
