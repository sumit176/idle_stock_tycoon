using System;
using System.Collections;
using System.Collections.Generic;
using Core.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private ItemsUpgradeMapSO upgradeMapSO;
    [SerializeField] private GameDataSO gameData;

    public long EarningPerSecond;
    public long TotalGeneration 
    {get {return totalGen;} 
    set{
            totalGen = value;
            cashText.text = Helper.ScoreShow(totalGen);
            playerData.TotalEarnings = value;
        }
    }
    [SerializeField] private TextMeshProUGUI cashText;

    private List<UICard> cards = new List<UICard>();
    private PlayerSaveData playerData;
    [SerializeField] private long totalGen;

    private void Awake()
    {
        Instance = this;
        cards.Clear();
    }

    private void Start()
    {
        if(Helper.HasPlayerData())
        {
            playerData = Helper.Load<PlayerSaveData>();
            TotalGeneration = playerData.TotalEarnings;
        }
        else {
            playerData = new PlayerSaveData();
            playerData.TotalEarnings = TotalGeneration;
            playerData.Items = gameData.Items;
            Helper.Save<PlayerSaveData>(playerData);
        }
        Hashtable hash = new Hashtable();
        hash.Add("data", playerData.Items);
        ViewHandler.Show<UIMainGameView>(hash);
        cashText.text = Helper.ScoreShow(totalGen);
    }

    private void Update() {
        for (int i = 0; i < cards.Count; i++)
        {
            cards[i].Update();
        }
    }

    public void AddCard(UICard cardObj)
    {
        cards.Add(cardObj);
        cardObj.OnGenerate += OnGenerateOnCard;
        cardObj.OnUpgradeClick += OnCardUpgradeClick;
    }

    private void OnCardUpgradeClick(UICard obj)
    {
        if(obj.Cost <= TotalGeneration)
        {
            //Update the data and give new data
            TotalGeneration -= obj.Cost;
            int level = obj.Level;
            var upgrade = upgradeMapSO.GetUpgradeData(obj.Id, level += 1);
            if(upgrade.Level > 0)
            {
                obj.UpdateData(upgrade);
                //Update player data
                playerData.Update(obj.Id - 1, upgrade);
            }
        }
    }

    private void OnGenerateOnCard(long obj)
    {
        TotalGeneration += obj;
    }

    private void OnApplicationPause(bool pauseStatus) {
        if(pauseStatus)
        {
            Helper.Save<PlayerSaveData>(playerData);
        }
    }

    private void OnApplicationQuit() {
        Helper.Save<PlayerSaveData>(playerData);
    }
}
