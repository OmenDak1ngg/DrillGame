using System;
using UnityEditor;
using UnityEngine;

public static class GemsData
{
    private const string DiamondsName = "Diamonds";

    public static int DiamondsCount => PlayerPrefs.GetInt(DiamondsName,0);

    public static void TryIncreaseDiamondsCount(int count)
    {
        int diamondsCount = DiamondsCount + count;

        if (diamondsCount < 0)
            throw new ArgumentOutOfRangeException();

        PlayerPrefs.SetInt(DiamondsName, diamondsCount);
        PlayerPrefs.Save();
    }

    public static int GetCurrentDiamonds()
    {
        return PlayerPrefs.GetInt(DiamondsName,0);  
    }

    public static void SaveDiamondsCount(int count)
    {
        if(count < 0)
            throw new ArgumentOutOfRangeException();

        PlayerPrefs.SetInt(DiamondsName,count);
    }
}
