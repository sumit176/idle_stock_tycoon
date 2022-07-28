using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New ItemsUpgradeMapSO" , menuName = "Scriptable/ItemsUpgradeMapSO")]
public class ItemsUpgradeMapSO : ScriptableObject
{
	[NonReorderable][SerializeField] private List<ItemDataUpgrades> upgradeList;

    public DataUpgrades GetUpgradeData(int Id, int level)
    {
        return upgradeList[Id - 1].GetUpgrade(level);
    }
}

