using UnityEngine;

public class FactoryHandler : MonoBehaviour
{
    public GameObject InstantiateObject(GameObject prefab, GameObject parent)
    {
        Debug.Log($"Creating {prefab} on {parent}");
        return Instantiate(prefab, parent.transform);
    }
}
