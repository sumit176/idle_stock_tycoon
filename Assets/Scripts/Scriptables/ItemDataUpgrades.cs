using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New ItemDataUpgrades" , menuName = "Scriptable/ItemDataUpgrades")]
public class ItemDataUpgrades : ScriptableObject
{
	[NonReorderable][SerializeField] private List<DataUpgrades> dataUpgrades;

    [SerializeField] private int BaseGeneration;
	[SerializeField] private float generationIncrease;
	[SerializeField] private float generationTimeIncrease;
	[SerializeField] private float costIncrease;
	[SerializeField] private int BaseCost;
	[SerializeField] private int MaxLevel;

	public DataUpgrades GetUpgrade(int level)
	{
		return dataUpgrades[level -1];
	}

    [ContextMenu("Auto fill data")]
	private void AutoFillUpgradeData()
	{
		dataUpgrades = new List<DataUpgrades>();
		long cost = BaseCost;
		long generation = BaseGeneration;

		for (int i = 0; i < MaxLevel; i++)
		{
            cost = cost + (cost * (long)costIncrease / 100);
			generation = generation + (generation * (long)generationIncrease / 100);

			DataUpgrades d = new DataUpgrades{ Level = i + 1, Cost = cost, GenerationIncreased = generation, GenerationTime = 1.5f };
			dataUpgrades.Add(d);
		}
	}
}

