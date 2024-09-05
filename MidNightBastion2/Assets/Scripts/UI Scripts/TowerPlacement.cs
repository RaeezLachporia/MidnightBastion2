using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class TowerPlacement : MonoBehaviour
{
    public GameObject TowerPrefab; // Tower prefab from assets
    private bool isPlacingTower = false;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the main camera
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // If we are in tower placement mode and the user clicks the left mouse button
        if (isPlacingTower && Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            PlaceTower();
        }
    }

    // Called when the button is pressed to start placing a tower
    public void towerPlacement()
    {
        isPlacingTower = true;
    }

    // Method to place the tower
    public void PlaceTower()
    {
        // Ensure the TowerPrefab is assigned in the Inspector
        if (TowerPrefab == null)
        {
            Debug.LogError("Tower prefab is not assigned in the Inspector.");
            return;
        }

        // Cast a ray from the camera to the mouse position
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Log what we hit
            Debug.Log("Raycast hit: " + hit.collider.gameObject.name + " at position " + hit.point);

            // Get the position where the ray hit the terrain
            Vector3 placementPosition = hit.point;

            // Instantiate the tower at the hit point
            Instantiate(TowerPrefab, placementPosition, Quaternion.identity);

            // Disable further tower placement
            isPlacingTower = false;
            Debug.Log("Tower placed at: " + placementPosition);
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }

    // Check if the pointer is over a UI element
    bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
