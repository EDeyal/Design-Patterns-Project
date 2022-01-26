using UnityEngine;

public class CamPosition : MonoBehaviour
{
    [SerializeField]
    int _index;
    [SerializeField]
    Vector3 _rotation;
    public Vector3 rotation => _rotation;
    public int index { get => _index; set => _index = value; }
}
