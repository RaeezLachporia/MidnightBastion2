using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class TowerPlacement : MonoBehaviour
{
    public GameObject[] objects;
    private Vector3 pos;
    private RaycastHit hit;
    [SerializedField] private LayerMask layermask;

    void Start()
    {

    }


    void Update()
    {

    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
