using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Pref
{
    public static int level
    {
        set => PlayerPrefs.SetInt(PrefConsts.LEVEL_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.LEVEL_KEY, 0);
    }

    public static int leveltxt
    {
        set => PlayerPrefs.SetInt(PrefConsts.LEVELTEXT_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.LEVELTEXT_KEY, 1);
    }
    public static int IQ
    {
        set => PlayerPrefs.SetInt(PrefConsts.COIN_KEY, value);
        get => PlayerPrefs.GetInt(PrefConsts.COIN_KEY, 0);
    }
}
