using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerPrefabGroup
{
    public GameObject[] prefabs; // Array for upgrade tiers
}

public class UpgradeTower1 : MonoBehaviour
{
    [Header("Tower Prefab Groups")]
    public List<TowerPrefabGroup> towerPrefabGroups; // Inspector-friendly List

    private int[] currentTiers;

    private void Start()
    {
        currentTiers = new int[towerPrefabGroups.Count];

        for (int i = 0; i < towerPrefabGroups.Count; i++)
        {
            if (towerPrefabGroups[i].prefabs == null || towerPrefabGroups[i].prefabs.Length == 0)
            {
                Debug.LogError($"Tower type {i} has no prefabs assigned!");
            }
        }
    }

    public GameObject GetUpgradedTowerPrefab(int towerType)
    {
        if (towerType < 0 || towerType >= towerPrefabGroups.Count)
        {
            Debug.LogError($"Invalid towerType index: {towerType}");
            return null;
        }

        int tier = currentTiers[towerType];
        if (tier < 0 || tier >= towerPrefabGroups[towerType].prefabs.Length)
        {
            Debug.LogError($"Invalid tier for towerType {towerType}: {tier}");
            return null;
        }

        return towerPrefabGroups[towerType].prefabs[tier];
    }

    public void UpgradeTowerTier(int towerType)
    {
        if (towerType < 0 || towerType >= towerPrefabGroups.Count)
        {
            Debug.LogError($"Cannot upgrade. Invalid towerType index: {towerType}");
            return;
        }

        if (currentTiers[towerType] < towerPrefabGroups[towerType].prefabs.Length - 1)
        {
            currentTiers[towerType]++;
            Debug.Log($"Upgraded towerType {towerType} to tier {currentTiers[towerType]}");
        }
        else
        {
            Debug.Log($"TowerType {towerType} is already at the maximum tier.");
        }
    }
}
