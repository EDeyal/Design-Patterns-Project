using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public void EndGame()
    {
        GameManager.instance.EndGame();
    }
}
