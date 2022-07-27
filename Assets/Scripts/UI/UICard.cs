using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICard
{
    TextMeshProUGUI titleText;
    TextMeshProUGUI buyText;
    TextMeshProUGUI holdingText;
    Button buyButton;

    private ItemData item;

    public UICard(Transform gObj, ItemData gameData)
    {
        item = gameData;
        AssignReference(gObj);
        UpdateData(gameData);
    }

    private void UpdateData(ItemData gameData)
    {
        titleText.text = gameData.Title;
        buyText.text = gameData.Cost +"BUY";
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void OnBuyButtonClick()
    {
        Debug.Log("Buy button clicked");
    }

    private void AssignReference(Transform gObj)
    {
        titleText = gObj.FindAndGet<TextMeshProUGUI>("TitleText");
        buyText = gObj.FindAndGet<TextMeshProUGUI>("BUY/Text");
        holdingText = gObj.FindAndGet<TextMeshProUGUI>("TotalHolding");
        buyButton = gObj.FindAndGet<Button>("BUY");
    }

    public void Update(ItemData data)
    {
        item = data;
    }
}
