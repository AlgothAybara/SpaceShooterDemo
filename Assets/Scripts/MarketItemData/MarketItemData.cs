using UnityEngine;

[CreateAssetMenu(fileName = "Inventory Item Data", menuName = "SpaceShooterDemo/Inventory Item Data", order = 0)]
public class InventoryItemData : ScriptableObject {
    public string id;
    public string displayName;
    public GameObject prefab;
}