using System;

[Serializable]
public class GameData
{
    public int Id;
    public string Title;
    public int Level;
    public int MaxLevel;
    public long Cost;
}

[Serializable]
public struct DataUpgrades
{
    public int Level;
    public long Cost;
    public long EarnigPerSeconds;
    public long SellValue;
}
