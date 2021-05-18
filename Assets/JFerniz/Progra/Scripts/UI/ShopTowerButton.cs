using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopTowerButton : MonoBehaviour
{
    [SerializeField] Image towerImage = default;
    [SerializeField] TMP_Text priceLabel = default;

    private Button button;

    private Evolution evolution;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(BuyTower);

    }

    public void SetEvolutionData(Evolution evolution)
    {
        this.evolution = evolution;
        towerImage.sprite = evolution.stats.sprite;
        priceLabel.text = evolution.price.ToString();
    }

    private void BuyTower()
    {
        FindObjectOfType<Shop>().TryToBuyEvolution(evolution);
    }
}
