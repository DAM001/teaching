using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameUi : MonoBehaviour
{
    [SerializeField] private Text _numberOfCoinsText;

    private int _numberOfCoins = 0;
    private int _numberOfCollectedCoins = 0;

    private void Start()
    {
        _numberOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;

        UpdateText();
    }

    public void UpdateText()
    {
        _numberOfCoinsText.text = "Coins: " + (_numberOfCoins - _numberOfCollectedCoins) + " / " + _numberOfCoins;
        if (_numberOfCoins != 0 && _numberOfCoins == _numberOfCollectedCoins) MapManager.NextMap();
        
        _numberOfCollectedCoins++;
    }
}
