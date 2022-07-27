using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New GameDataSO" , menuName = "Scriptable/GameDataSO")]
public class GameDataSO : ScriptableObject
{
	[NonReorderable][SerializeField] private List<ItemData> inventories;

	public List<ItemData> Items => inventories;
}

