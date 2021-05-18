using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool canBuildTower = true;

    private Tower tower;

    public void SetTower(Tower tower) => this.tower = tower;

    public bool CanBuildTower() => canBuildTower && tower == null;
}
