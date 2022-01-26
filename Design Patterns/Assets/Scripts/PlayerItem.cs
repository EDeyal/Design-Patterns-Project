using UnityEngine;

public class PlayerItem : Item
{
    [SerializeField]
    GameObject _bodyPartToBeAssigned;
    public void InstantiateItemOnPlayer()
    {
        GameManager.instance.factoryHandler.InstantiateObject(itemSO.itemPrefab, _bodyPartToBeAssigned);
    }
}
