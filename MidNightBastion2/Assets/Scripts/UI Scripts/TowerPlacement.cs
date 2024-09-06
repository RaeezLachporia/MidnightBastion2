using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class TowerPlacement : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject placeholderObject; 

    private Vector3 pos;

    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    //public float gridSize;
    //bool gridOn = true;
    //[SerializeField] private Toggle gridToggle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(placeholderObject != null)
        {

            /*if(gridOn)
            {
                placeholderObject.transform.position = new Vector3(
                    ClosestGrid(pos.x),
                    ClosestGrid(pos.y),
                    ClosestGrid(pos.z)
                    );
            }*/
            //else {placeholderObject.transform.position = pos;}

            placeholderObject.transform.position = pos;
            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
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

        if(Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void TowerChoice(int index)
    {
        //placeholderObject = Instantiate(objects[index], pos, transform.rotation); this is the old code that cuased the towers to be placed in the wrong orientation.


        float terrainHeight = Terrain.activeTerrain.SampleHeight(pos);

        Vector3 adjustedPos = new Vector3(pos.x, terrainHeight, pos.z);

        placeholderObject = Instantiate(objects[index], adjustedPos, Quaternion.Euler(-90, 0, 0));  //causes tower when placed to be placed at -90 degrees so it is upright

        
        
    }

    /*public void Grid()
    {
        if(gridToggle.isOn)
        {
            gridOn = true;
        }
        else { gridOn = false; }
    }

    float ClosestGrid(float pos)
    {
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff > (gridSize / 2))
        {
            pos += gridSize;
        }
        return pos;
    }*/

    


    
}
