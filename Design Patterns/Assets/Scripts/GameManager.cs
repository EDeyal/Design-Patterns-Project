using UnityEngine;
using System.Collections;

public class GameManager : MonoSingleton<GameManager>
{
    public Camera mainCamera;
    public RoomHandler roomHandler;
    public Player player;
    public FactoryHandler factoryHandler;
    public UIHandler uiHandler;
    public InteractableHandler interactableHandler;
    public void Awake()
    {
        interactableHandler = new InteractableHandler(player);
    }
    public void EndGame()
    {
        uiHandler.VictoryScreen();
        Debug.Log("You Win!!!");
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
