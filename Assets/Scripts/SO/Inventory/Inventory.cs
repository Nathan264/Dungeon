using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Item item;
    public int qtd;
}

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Object/Inventory")]
public class Inventory : ScriptableObject
{
    public List<InventoryItem> inventory;
}
