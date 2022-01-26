using UnityEngine;

[CreateAssetMenu(fileName = "MergeResultSO", menuName = "ScriptableObjects/MergeResult")]
public class MergeResultSO : ScriptableObject
{
    [SerializeField] ItemSO _item1;
    [SerializeField] bool _destroyItem1;
    [SerializeField] ItemSO _item2;
    [SerializeField] bool _destroyItem2;
    [SerializeField] ItemSO _result;
    public ItemSO CheckMerge(ItemSO droppedItem, ItemSO onItem)
    {
        if (_item1 == null || _item2 == null || _result == null)
        {
            throw new System.Exception("MergeResultSO is missing a reference");
        }
        if (droppedItem == _item1 || droppedItem == _item2)
        {
            if (onItem == _item1 || onItem == _item2)
            {
                DestroyItemsFromPlayer();
                Debug.Log($"Creating {_result.name}");
                return _result;
            }
        }
        return null;
    }
    private void DestroyItemsFromPlayer()
    {
        var gm = GameManager.instance;
        if (_destroyItem1)
        {
            gm.player.Inventory.Remove(_item1);
            gm.uiHandler.RemoveItemSprite(_item1);
        }
        if (_destroyItem2)
        {
            gm.player.Inventory.Remove(_item2);
            gm.uiHandler.RemoveItemSprite(_item2);
        }
    }
}
