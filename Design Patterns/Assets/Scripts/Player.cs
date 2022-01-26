using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    List<ItemSO> _inventory;
    [SerializeField]
    List<MergeResultSO> _mergeResults;
    [SerializeField]
    GameObject _bodyWand;
    [SerializeField]
    GameObject _bodyHat;
    
    public List<ItemSO> Inventory => _inventory;
    public List<MergeResultSO> mergeResults => _mergeResults;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.instance.interactableHandler.SendRay();
        }
    }
    public void AddItemToPlayerInventory(ItemSO item)
    {
        Inventory.Add(item);
    }
    public void TryMerge(ItemSO droppedItem, ItemSO onItem)
    {
        ItemSO result = null;
        foreach (var merge in mergeResults)
        {
            result = merge.CheckMerge(droppedItem, onItem);
            if (result != null)
            {
                AddItemToPlayerInventory(result);
                GameManager.instance.uiHandler.AddItemSprite(result);
                Debug.Log("AddingToInventory");
                
                return;
            }
        }
        Debug.Log("Merge Failed");
    }
}