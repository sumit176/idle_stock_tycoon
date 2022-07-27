using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New ItemDataUpgrades" , menuName = "Scriptable/ItemDataUpgrades")]
public class ItemDataUpgrades : ScriptableObject
{
	[NonReorderable][SerializeField] private List<DataUpgrades> dataUpgrades;
}

