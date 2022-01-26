using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField]
    Sprite _sprite;
    [SerializeField]
    GameObject _itemPrefab;


    #region Properties
    public Sprite sprite => _sprite;
    public GameObject itemPrefab => _itemPrefab;
    #endregion
}
