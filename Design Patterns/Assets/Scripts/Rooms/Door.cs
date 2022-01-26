using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    public Room room1;
    [SerializeField]
    public CamPosition camPos1;
    [SerializeField]
    public Room room2;
    [SerializeField]
    public CamPosition camPos2;

    bool _canExitRoom = false;
    [SerializeField]
    ItemSO ItemToExit;
    public bool CanExitRoom => _canExitRoom;
    public void MoveToNextRoom()
    {
        if (!_canExitRoom)
        {
            TryToUnlockExit();
        }
        if (_canExitRoom)
        GameManager.instance.roomHandler.MoveToNextRoom(this);
        else
        {
            Debug.Log("Door is locked");
        }
    }
    public void TryToUnlockExit()
    {
        foreach (var item in GameManager.instance.player.Inventory)
        {
            if (item == ItemToExit)
            {
                _canExitRoom = true;
                var animator = gameObject.GetComponent<Animator>();
                if (animator == null)
                {
                    animator = gameObject.GetComponentInParent<Animator>();
                }
                animator.SetBool("UnlockDoor", true);

                Debug.Log("Can leave room Moving Room");
                return;
            }
        }
        Debug.Log("You do not have the Item that opens that door");
    }
}
