using System.Collections;
using System.Collections.Generic;
using Core.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public long EarningPerSecond;

    private List<UICard> cards = new List<UICard>();
    private PlayerSaveData playerData;

    private void Awake()
    {
        Instance = this;
        cards.Clear();
    }

    private void Start()
    {
        ViewHandler.Show<UIMainGameView>();
    }

    public void AddCard(UICard cardObj)
    {
        cards.Add(cardObj);
    }
}
