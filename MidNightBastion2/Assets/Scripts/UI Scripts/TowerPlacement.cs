using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    public LayerMask layerMask;

    private GameObject placeholderObject;
    private Vector3 placementPosition;
    private RaycastHit hit;

    private Currency currencyManager;
    private UpgradeTower1 upgradeManager;

    private Quaternion[] towerRotations = {
        Quaternion.Euler(-90, 0, 0), // Tower 1 rotation
        Quaternion.Euler(-90, 0, 0), // Tower 2 rotation
        Quaternion.Euler(0, 0, 0)    // Tower 3 rotation
    };

    private void Start()
    {
        currencyManager = FindObjectOfType<Currency>();
        upgradeManager = FindObjectOfType<UpgradeTower1>();
    }

    private void Update()
    {
        if (placeholderObject != null)
        {
            placeholderObject.transform.position = placementPosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (currencyManager.presentCurrency >= currencyManager.currentTowerCost)
                {
                    PlaceTower();
                    currencyManager.PlaceTower();
                }
                else
                {
                    Destroy(placeholderObject);
                    placeholderObject = null;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            placementPosition = hit.point;
        }
    }

    public void TowerChoice(int towerIndex)
    {
        currencyManager.SetTowerCost(towerIndex);

        if (currencyManager.presentCurrency >= currencyManager.currentTowerCost)
        {
            GameObject towerPrefab = upgradeManager.GetUpgradedTowerPrefab(towerIndex);
            if (towerPrefab != null)
            {
                float terrainHeight = Terrain.activeTerrain.SampleHeight(placementPosition);
                Vector3 adjustedPosition = new Vector3(placementPosition.x, terrainHeight, placementPosition.z);

                placeholderObject = Instantiate(towerPrefab, adjustedPosition, towerRotations[towerIndex]);
            }
        }
    }

    private void PlaceTower()
    {
        placeholderObject = null;
    }
}
