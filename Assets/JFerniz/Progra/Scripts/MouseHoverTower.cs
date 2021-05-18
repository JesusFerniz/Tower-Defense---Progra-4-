using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverTower : MonoBehaviour
{
    private TowerDetails towerDetails;
    private Tower tower;

    private void Awake()
    {
        tower = GetComponent<Tower>();
    }
    private void Start()
    {
        towerDetails = FindObjectOfType<TowerDetails>();
    }

    private void OnMouseEnter()
    {
        towerDetails.SetData(tower.Stats);
        towerDetails.Show();
    }

    private void OnMouseExit()
    {
        //towerDetails.gameObject.SetActive(false);
        towerDetails.Hide();
    }
}
