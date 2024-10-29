using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;



public class TowerPlacement : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject placeholderObject; 

    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private Currency money;
    private EnemyController updateCurrency;

    private Quaternion[] towerRotations = {
        Quaternion.Euler(-90, 0, 0), // Tower 1 rotation
        Quaternion.Euler(-90, 0, 0),   // Tower 2 rotation
        Quaternion.Euler(0, 0, 0)  // Tower 3 rotation
    };




    void Start()
    {
        
        money = FindObjectOfType<Currency>();
    }

    // Update is called once per frame
    void Update()
    {
        if(placeholderObject != null)
        {
            placeholderObject.transform.position = pos;



            if (Input.GetMouseButtonDown(0))
            {

                if (money.presentCurrency >= money.towerCost)
                {
                    PlaceTower();  // Place the tower if there is enough currency
                    money.PlaceTower();  // Deduct the currency
                }
                else
                {
                    Debug.Log("Invalid Placement");

                    placeholderObject = null;
                }
            }


        }


        

    }

    public void PlaceTower()
    {
        placeholderObject = null;
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layerMask))//raycats system to allow for towers to be placed on terrain and not in it
        {
            pos = hit.point;
        }
    }

    public void TowerChoice(int index)
    {
        //placeholderObject = Instantiate(objects[index], pos, transform.rotation); this is the old code that cuased the towers to be placed in the wrong orientation.

        if (money.presentCurrency >= money.towerCost)
        {
            float terrainHeight = Terrain.activeTerrain.SampleHeight(pos);

            Vector3 adjustedPos = new Vector3(pos.x, terrainHeight, pos.z);


            //placeholderObject = Instantiate(objects[index], adjustedPos, Quaternion.Euler(-90, 0, 0));  //causes tower when placed to be placed at -90 degrees so it is upright
            placeholderObject = Instantiate(objects[index], adjustedPos, towerRotations[index]);

        }
        else
        {
            Debug.Log("ur broke");
        }
        
        
    }

   

    


    
}
