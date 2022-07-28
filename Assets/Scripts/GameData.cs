using System;

[Serializable]
public struct ItemData
{
    public int Id;
    public string Title;
    public int Level;
    public int MaxLevel;
    public long Cost;
    public long GenRate;
    public float GenTime;
}

[Serializable]
public struct DataUpgrades
{
    public int Level;
    public long Cost;
    public long GenerationIncreased;
    public long SellValue;
    public float GenerationTime;
}
