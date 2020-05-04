using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Code_staticDataHolder
{
    private static int HighestLV;
    private static int Skillcode;

    public static int highestLV
    {
        get
        {
            return HighestLV;
        }
        set
        {
            HighestLV = value;
        }
    }

    public static int skillcode
    {
        get
        {
            return Skillcode;
        }
        set
        {
            Skillcode = value;
        }
    }
}
