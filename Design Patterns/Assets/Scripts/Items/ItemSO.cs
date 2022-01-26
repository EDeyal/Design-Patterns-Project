using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    Sprite _sprite;
    [SerializeField]
    GameObject _itemPrefab;


    #region Properties
    public Sprite Sprite => _sprite;
    public GameObject ItemPrefab => _itemPrefab;

    #endregion
}
