using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField]
    ItemSO _itemSO;
    [SerializeField]
    Image _image;
    
    public ItemSO itemSO { get => _itemSO; set => _itemSO = value; }
    public Image image { get => _image; set => _image = value; }
    public void SetItemUI(ItemSO itemSO)
    {
        _itemSO = itemSO;
        _image.sprite = itemSO.Sprite;
    }
}
