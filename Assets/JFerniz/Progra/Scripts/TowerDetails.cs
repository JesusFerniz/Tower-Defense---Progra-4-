using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerDetails : MonoBehaviour
{
    [SerializeField] TMP_Text nameLabel = default;
    [SerializeField] TMP_Text descriptionLabel = default;

    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetData(TowerStats stats)
    {
        nameLabel.text = stats.towerName;
        descriptionLabel.text = stats.description;
    }

    public void Show()
    {
        canvasGroup.alpha = 1f;
        //transform.position = Input.mousePosition;
    }

    public void Hide()
    {
        canvasGroup.alpha = 0f;
    }
}