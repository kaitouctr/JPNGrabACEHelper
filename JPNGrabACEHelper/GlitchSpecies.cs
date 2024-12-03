// SPDX-License-Identifer: MIT

using System;
using System.Collections.Generic;

namespace JPNGrabACEHelper;

public enum CPUMode
{
    ARM,
    Thumb
}

public enum GameVersion
{
    FireRed,
    LeafGreen
}

public class MonEntry(ushort index, uint rawAddress, uint actualAddress, CPUMode cpuMode, string entrypoint)
{
    public ushort Index { get; } = index;
    public uint RawAddress { get; } = rawAddress;
    public uint ActualAddress { get; } = actualAddress;
    public CPUMode CPUMode { get; } = cpuMode;
    public string Entrypoint { get; } = entrypoint;
}

internal class GlitchSpecies
{
    public static MonEntry[] fireRedData = [
        new(0x03F8, 0x021F0046, 0x02030046, CPUMode.ARM, "Box12/21~"),
        new(0x060C, 0x021F0046, 0x02030046, CPUMode.ARM, "Box12/21~"),
        new(0x15BC, 0x020F1404, 0x02031404, CPUMode.ARM, "Box14/24~"),
        new(0x1626, 0x020F0000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0x4312, 0x0202FC01, 0x0202FC01, CPUMode.Thumb, "Box12/ 7~"),
        new(0x4317, 0x0202FC01, 0x0202FC01, CPUMode.Thumb, "Box12/ 7~"),
        new(0x4D12, 0x02030000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0x7912, 0x02031013, 0x02031013, CPUMode.Thumb, "Box14/11~"),
        new(0x89FA, 0x0277050B, 0x0203050B, CPUMode.Thumb, "Box13/ 6~"),
        new(0xA253, 0x021B1333, 0x02031333, CPUMode.Thumb, "Box14/21~"),
        new(0xB2A9, 0x021705EC, 0x020305EC, CPUMode.ARM, "Box13/ 9~"),
        new(0xC7FE, 0x021B06DB, 0x020306DB, CPUMode.Thumb, "Box13/12~"),
        new(0xC950, 0x024706D0, 0x020306D0, CPUMode.ARM, "Box13/12~"),
        new(0xCAA2, 0x022B0066, 0x02030066, CPUMode.ARM, "Box12/21~"),
        new(0xCD48, 0x02EEBB7F, 0x0202BB7F, CPUMode.Thumb, "Box 5/11~"),
        new(0xCF8B, 0x02030007, 0x02030007, CPUMode.Thumb, "Box12/20~"),
        new(0xD624, 0x02230199, 0x02030199, CPUMode.Thumb, "Box12/25~"),
        new(0xDD37, 0x02070023, 0x02030023, CPUMode.Thumb, "Box12/20~"),
        new(0xE07C, 0x02FF0155, 0x02030155, CPUMode.Thumb, "Box12/24~"),
        new(0xE472, 0x021B02A0, 0x020302A0, CPUMode.ARM, "Box12/28~"),
        new(0xE69D, 0x02E2ED20, 0x0202ED20, CPUMode.ARM, "Box10/20~"),
        new(0xFF3B, 0x026F026E, 0x0203026E, CPUMode.ARM, "Box12/28~"),
        new(0xFF41, 0x025F025E, 0x0203025E, CPUMode.ARM, "Box12/28~"),
        new(0xFF61, 0x027F027E, 0x0203027E, CPUMode.ARM, "Box12/28~"),
        new(0xFF6B, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF78, 0x027F0000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0xFF79, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF7B, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF7E, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF81, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF83, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF86, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF8B, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF8E, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF96, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF99, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF9B, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF9E, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFA1, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFA3, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFAB, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFAE, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB1, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB3, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB6, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFBB, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC3, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC6, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFCE, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFD3, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFF8, 0x027F0000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0xFFF9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~")
    ];
    public static MonEntry[] leafGreenData = [
        new(0x03F8, 0x021F0046, 0x02030046, CPUMode.ARM, "Box12/21~"),
        new(0x060C, 0x021F0046, 0x02030046, CPUMode.ARM, "Box12/21~"),
        new(0x15BC, 0x020F1404, 0x02031404, CPUMode.ARM, "Box14/24~"),
        new(0x1626, 0x020F0000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0x3D88, 0x02C7030E, 0x0203030E, CPUMode.ARM, "Box12/30~"),
        new(0x4D1B, 0x02030405, 0x02030405, CPUMode.Thumb, "Box13/ 3~"),
        new(0xBCB2, 0x020B0221, 0x02030221, CPUMode.Thumb, "Box12/27~"),
        new(0xC290, 0x020310C7, 0x020310C7, CPUMode.Thumb, "Box14/14~"),
        new(0xC6AA, 0x02E2EDE2, 0x0202EDE2, CPUMode.ARM, "Box10/22~"),
        new(0xCFAD, 0x02870602, 0x02030602, CPUMode.ARM, "Box13/ 9~"),
        new(0xD45D, 0x02031036, 0x02031036, CPUMode.ARM, "Box14/12~"),
        new(0xD628, 0x02031003, 0x02031003, CPUMode.Thumb, "Box14/11~"),
        new(0xEA20, 0x02EEE440, 0x0202E440, CPUMode.ARM, "Box 9/21~"),
        new(0xEB51, 0x027312D3, 0x020312D3, CPUMode.Thumb, "Box14/20~"),
        new(0xFBED, 0x023301F0, 0x020301F0, CPUMode.ARM, "Box12/26~"),
        new(0xFF11, 0x026F026E, 0x0203026E, CPUMode.ARM, "Box12/28~"),
        new(0xFF37, 0x027F027E, 0x0203027E, CPUMode.ARM, "Box12/28~"),
        new(0xFF41, 0x024F024E, 0x0203024E, CPUMode.ARM, "Box12/27~"),
        new(0xFF57, 0x027F027E, 0x0203027E, CPUMode.ARM, "Box12/28~"),
        new(0xFF5C, 0x025F001A, 0x0203001A, CPUMode.ARM, "Box12/20~"),
        new(0xFF61, 0x026F026E, 0x0203026E, CPUMode.ARM, "Box12/28~"),
        new(0xFF6C, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF79, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF7C, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF7F, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF81, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF84, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF87, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF8C, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF8F, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF97, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF99, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF9C, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFF9F, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFA1, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFA4, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFAC, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFAF, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB1, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB4, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB7, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFB9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFBC, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC4, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC7, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFC9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFCE, 0x027F0000, 0x02030000, CPUMode.ARM, "Box12/20~"),
        new(0xFFD1, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~"),
        new(0xFFF9, 0x027F027F, 0x0203027F, CPUMode.Thumb, "Box12/28~")
    ];
}
