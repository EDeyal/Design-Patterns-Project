using UnityEngine;


public class Item : MonoBehaviour
{
    [SerializeField]
    string _name;
    [SerializeField]
    ItemSO _itemSO;

    #region Properties
    public ItemSO itemSO => _itemSO;
    #endregion
}
