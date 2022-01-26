using UnityEngine;

public class CamPosition : MonoBehaviour
{
    [SerializeField]
    int _index;
    [SerializeField]
    Vector3 _rotation;
    public Vector3 Rotation => _rotation;
    public int Index { get => _index; set => _index = value; }
}
