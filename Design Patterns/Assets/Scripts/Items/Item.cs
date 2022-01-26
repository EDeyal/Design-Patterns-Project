using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField]
    string _name;
    [SerializeField]
    ItemSO _itemSO;
    [SerializeField]
    bool _hasBeenUsed;

    #region Properties
    public ItemSO itemSO => _itemSO;
    #endregion
}
