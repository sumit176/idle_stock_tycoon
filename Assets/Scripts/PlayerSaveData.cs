using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveData
{
    public PlayerSaveData()
    {
        Items = new List<ItemData>();
    }
    public long RunningEarning;
    public long TotalEarnings;

    public List<ItemData> Items;

    public void Update(int index, DataUpgrades upgrades)
    {
        var newData = Items[index];
        newData.Cost+= upgrades.Cost;
        newData.Level = upgrades.Level;
        newData.GenTime = upgrades.GenerationTime;
        newData.GenRate += upgrades.GenerationIncreased;
        Items[index] = newData;
    }
}
