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
    public static Dictionary<MonEntry, List<WordEntry>>? DetermineCompatibility(
        ushort tid,
        ushort sid,
        uint pid,
        GameVersion game)
    {
        Dictionary<MonEntry, List<WordEntry>> results = new();
        uint otid = (uint)((sid << 16) | tid);
        string pidSStruct = MethodPID.pidSStructs[(int)(pid % 24)];
        ushort encryptionKey = (ushort)((otid ^ pid) & 0xFFFF);
        List<string> compatibleSStructs = new()
        {
            MethodPID.pidSStructs[6],
            MethodPID.pidSStructs[7],
            MethodPID.pidSStructs[8],
            MethodPID.pidSStructs[12],
            MethodPID.pidSStructs[13],
            MethodPID.pidSStructs[18],
            MethodPID.pidSStructs[19],
            MethodPID.pidSStructs[22]
        };
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
                List<WordEntry> words = EasyChatSystem.ECSWords
                    .FindAll(entry => entry.Index == wordIndex);
                if (words.Count <= 0)
                {
                    continue;
                }
                results.Add(mon, words);
            }
        }
        return results;
    }
}
