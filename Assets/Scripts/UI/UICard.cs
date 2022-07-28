using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICard
{
    public Action<long> OnGenerate;
    public Action<UICard> OnUpgradeClick;

    TextMeshProUGUI titleText;
    TextMeshProUGUI buyText;
    TextMeshProUGUI holdingText;
    TextMeshProUGUI earningText;
    Button buyButton;

    private ItemData item;

    public long Cost => item.Cost;
    public int Level => item.Level;
    public int Id => item.Id;

    private float runningTime = 0;

    public UICard(Transform gObj, ItemData gameData)
    {
        item = gameData;
        item.GenTime = item.GenTime == 0 ? 1 : item.GenTime;
        AssignReference(gObj);
        UpdateData(gameData);
    }

    private void UpdateData(ItemData gameData)
    {
        titleText.text = gameData.Title;
        buyText.text = Helper.ScoreShow(item.Cost);
        holdingText.text = "Holding : "+gameData.Level.ToString();
        long earning = item.GenRate/(long)item.GenTime;
        earningText.text = "Earning : "+Helper.ScoreShow(earning) +"/ s";
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void UpdateData()
    {
        buyText.text = Helper.ScoreShow(item.Cost);
        holdingText.text = "Holding : "+item.Level.ToString();
        long earning = item.GenRate/(long)item.GenTime;
        earningText.text = "Earning : "+Helper.ScoreShow(earning) +"/ s";
    }


    public void UpdateData(int level, long costIncrease, long generationIncreased, int generationTime)
    {
        var newData = item;
        newData.Cost+= costIncrease;
        newData.Level = level;
        newData.GenTime = generationTime;
        newData.GenRate += generationIncreased;
        item = newData;
        UpdateData();
    }

    public void UpdateData(DataUpgrades upgrades)
    {
        var newData = item;
        newData.Cost+= upgrades.Cost;
        newData.Level = upgrades.Level;
        newData.GenTime = upgrades.GenerationTime;
        newData.GenRate += upgrades.GenerationIncreased;
        item = newData;
        UpdateData();
    }

    private void OnBuyButtonClick()
    {
        Debug.Log("Buy button clicked");
        OnUpgradeClick?.Invoke(this);
    }

    private void AssignReference(Transform gObj)
    {
        titleText = gObj.FindAndGet<TextMeshProUGUI>("Root/Icon/TitleText");
        buyText = gObj.FindAndGet<TextMeshProUGUI>("Root/BUY/Text");
        holdingText = gObj.FindAndGet<TextMeshProUGUI>("Root/TotalHolding");
        buyButton = gObj.FindAndGet<Button>("Root/BUY");
        earningText = gObj.FindAndGet<TextMeshProUGUI>("Root/Icon/EarningText");
    }

    public void Update()
    {
        buyButton.interactable = GameManager.Instance.TotalGeneration >= item.Cost;
        if (item.Level == 0)
        {
            return;
        }
        
        if(runningTime < item.GenTime)
            runningTime += Time.deltaTime;
        else {
            //generate resource and reset running time
            runningTime = 0;
            OnGenerate?.Invoke(item.GenRate);
        }
    }
}
