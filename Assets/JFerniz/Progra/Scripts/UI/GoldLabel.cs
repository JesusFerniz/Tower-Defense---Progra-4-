using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldLabel : MonoBehaviour
{
    [SerializeField] TMP_Text goldLabel = default;
    [SerializeField] Inventory inventory = default;

    private void OnEnable() => inventory.onGoldChanged += UpdateLabel;

    private void OnDisable() => inventory.onGoldChanged -= UpdateLabel;

    public void UpdateLabel(int goldAmount) => goldLabel.text = "Gold: " + goldAmount;

    //void OnGoldChanged()
    //{
    //    Debug.Log("Cambio la cantidad de oro. ");
    //}

    //public void Update()
    //{
    //    UpdateLabel(inventory.Gold);
    //}
}
