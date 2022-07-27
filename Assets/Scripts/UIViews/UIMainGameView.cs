using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainGameView : View
{
    [SerializeField] private GameDataSO gameData;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefabTemplate;

    public override void Show()
    {
        base.Show();

        foreach (var item in gameData.Items)
        {
            GameObject gObj = Instantiate(prefabTemplate, parent);
            UICard card = new UICard(gObj.transform, item);
            GameManager.Instance.AddCard(card);
        }
    }
}
