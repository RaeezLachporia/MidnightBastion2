using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerPrefabs
{
    public GameObject[] prefabs;
}

public class UpgradeTower1 : MonoBehaviour
{
    [Header("Tower Prefab Groups")]
    public List<TowerPrefabs> towers;

    private int[] currentTiers;

    private void Start()
    {
        currentTiers = new int[towers.Count];

        for (int i = 0; i < towers.Count; i++)
        {
            if (towers[i].prefabs == null || towers[i].prefabs.Length == 0)
            {
                // Handle missing prefabs gracefully.
                currentTiers[i] = -1; // Mark invalid tiers.
            }
        }
    }

    public GameObject GetUpgradedTowerPrefab(int towerType)
    {
        if (towerType < 0 || towerType >= towers.Count)
        {
            return null;
        }

        int tier = currentTiers[towerType];
        if (tier < 0 || tier >= towers[towerType].prefabs.Length)
        {
            return null;
        }

        return towers[towerType].prefabs[tier];
    }

    public void UpgradeTowerTier(int towerType)
    {
        if (towerType < 0 || towerType >= towers.Count)
        {
            return;
        }

        if (currentTiers[towerType] < towers[towerType].prefabs.Length - 1)
        {
            currentTiers[towerType]++;
        }
    }
}
