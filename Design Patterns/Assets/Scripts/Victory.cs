using UnityEngine;

public class Victory : MonoBehaviour
{
    public void EndGame()
    {
        GameManager.instance.EndGame();
    }
}
