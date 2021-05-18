using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] GameObject placeholderPrefab = default;

    [SerializeField] LayerMask tileMask = default;

    [SerializeField] TowerStats towerStats = default;
    [SerializeField] TowerStats bombStats = default;

    [SerializeField] int towerCost = 50;
    [SerializeField] int bombCost = 50;

    [SerializeField] Inventory inventory = default;
    [SerializeField] Transform evolutionParent = default;
    [SerializeField] GameObject evolutionButtonPrefab = default;

    [Header("Shops UI")]
    [SerializeField] GameObject normalShop = default;
    [SerializeField] GameObject evolutionShop = default;

    private bool isBuyingBasicTower;
    private bool isBuyingBombTower;
    private bool isPlaceHolderInValidTile;

    private GameObject placeholder;
    private GameObject selectedTower;
    private Tile selectedTile;

    private void Start() => OpenNormalShop();

    private void Update()
    {
        if (isBuyingBasicTower)
        {
            SetPlaceHolder();

            if (Input.GetMouseButtonDown(0) && isPlaceHolderInValidTile)
            {
                BuildTower();
            }

            if (Input.GetMouseButtonDown(1))
            {
                StopPlaceHolder();
            }
        }
        else if (isBuyingBombTower)
        {
            SetPlaceHolder();

            if (Input.GetMouseButtonDown(0) && isPlaceHolderInValidTile)
            {
                BombTower();
            }

            if (Input.GetMouseButtonDown(1))
            {
                StopPlaceHolder();
            }
        }
    }

    private void SetPlaceHolder()
    {
        //Instanciar placeholder si no existe
        if (placeholder == null)
            placeholder = Instantiate(placeholderPrefab, new Vector3(0f, 100f, 0f), Quaternion.identity);

        //Colocar el placeholder arriba de un tile
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit, 100f, tileMask))
        {
            selectedTile = hit.collider.GetComponent<Tile>();
            if (selectedTile != null && selectedTile.CanBuildTower())
            {

                Vector3 roundedHitPoint = hit.point;
                roundedHitPoint.x = Mathf.Floor(roundedHitPoint.x) + 0.5f;
                roundedHitPoint.y = 0f;
                roundedHitPoint.z = Mathf.Floor(roundedHitPoint.z) + 0.5f;

                placeholder.transform.position = roundedHitPoint;
                isPlaceHolderInValidTile = true;
            }
            else
            {
                placeholder.transform.position = new Vector3(0f, 100f, 0f);
                isPlaceHolderInValidTile = false;
            }
        }
        else
        {
            placeholder.transform.position = new Vector3(0f, 100f, 0f);
            isPlaceHolderInValidTile = false;
        }
    }

    private void BuildTower()
    {
        if (inventory.SpendGold(towerCost))
        {
            GameObject towerObjetc = Instantiate(towerStats.towerPrefab, placeholder.transform.position, Quaternion.identity);
            selectedTile.SetTower(towerObjetc.GetComponent<Tower>());
            StopPlaceHolder();
        }
    }

    private void BombTower()
    {
        if (inventory.SpendGold(bombCost))
        {
            GameObject towerObject2 = Instantiate(bombStats.towerPrefab, placeholder.transform.position, Quaternion.identity);
            StopPlaceHolder();
        }
    }

    private void StopPlaceHolder()
    {
        isBuyingBasicTower = false;
        isBuyingBombTower = false;
        placeholder.transform.position = new Vector3(0f, 100f, 0f);
    }

    public void BuyBasicTower()
    {
        if (inventory.HaveEnoughGold(towerCost))
            isBuyingBasicTower = !isBuyingBasicTower;
    }

    public void BuyBombTower()
    {
        if (inventory.HaveEnoughGold(bombCost))
            isBuyingBombTower = !isBuyingBombTower;
    }

    public void OpenEvolutionShop(GameObject towerObject, TowerStats towerData)
    {
        //if (selectedTower != null)
        //    selectedTower.SelectedEffect(0f);

        selectedTower = towerObject;

        normalShop.SetActive(false);
        evolutionShop.SetActive(true);

        CleanEvolutionUI();

        for (int i = 0; i < towerData.evolutions.Length; i++)
        {
            GameObject towerbutton = Instantiate(evolutionButtonPrefab, evolutionParent);
            ShopTowerButton shopTowerButton = towerbutton.GetComponent<ShopTowerButton>();
            shopTowerButton.SetEvolutionData(towerData.evolutions[i]);
        }
    }

    public void OpenNormalShop()
    {
        //if (selectedTower != null)
        //    selectedTower.SelectedEffect(0f);

        normalShop.SetActive(true);
        evolutionShop.SetActive(false);
    }

    public void TryToBuyEvolution(Evolution evolution)
    {
        if (inventory.SpendGold(evolution.price))
        {
            Instantiate(evolution.stats.towerPrefab, selectedTower.transform.position, selectedTower.transform.rotation);
            Destroy(selectedTower);
            selectedTower = null;

            OpenNormalShop();


            isBuyingBasicTower = false;
        }
    }

    private void CleanEvolutionUI()
    {
        for (int i = 0; i < evolutionParent.childCount; i++)
        {
            Destroy(evolutionParent.GetChild(i).gameObject);
        }
    }
}
