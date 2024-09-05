using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CheckTowerPlacement : MonoBehaviour
{
    TowerPlacement towerPlacement;
    
    void Start()
    {
        towerPlacement = GameObject.Find("TowerPlacer").GetComponent<TowerPlacement>();
    }

    public void OnTriggerEnter(Collider other)
    {

    }

    public void OnTriggerExit(Collider other)
    {

    }
}
