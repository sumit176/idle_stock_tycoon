using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;
using UnityEngine.UIElements;

public class UIMainGameView : View
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefabTemplate;

    public override void Show()
    {
        base.Show();
        var items = data["data"];

        foreach (var item in (List<ItemData>)items)
        {
            GameObject gObj = Instantiate(prefabTemplate, parent);
            UICard card = new UICard(gObj.transform, item);
            GameManager.Instance.AddCard(card);
        }
    }
}
