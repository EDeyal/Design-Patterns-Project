using System.Collections.Generic;
using UnityEngine;

public class RoomHandler: MonoBehaviour
{
    int _currentRoomIndex = 0;
    [SerializeField]
    Room[] _roomsInBuilding;
    Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
    public void Start()
    {
        Debug.Log("setting roomHandler");
        foreach (var room in _roomsInBuilding)
        {
            _rooms.Add(room.RoomIndex, room);
        }
        _currentRoomIndex = _roomsInBuilding[0].RoomIndex;
        Room currentRoom;
        _rooms.TryGetValue(_currentRoomIndex, out currentRoom);
        CamPosition currentCamPos;
        currentRoom.CamPositions.TryGetValue(0, out currentCamPos);
        currentRoom.OnRoomEntry(currentCamPos);
    }
    public void MoveToNextRoom(Door exit)
    {
        Debug.Log("trying to change room");
        //check what room you are in and than enter the other room
        if (exit.room1.RoomIndex == _currentRoomIndex)
        {
            TrySetRoom(exit.room2, exit.camPos2);
        }
        else if (exit.room2.RoomIndex == _currentRoomIndex)
        { 
            TrySetRoom(exit.room1, exit.camPos1);
        }
        else
        {
            Debug.LogError("RoomHandler cant change room, there is a bug");
        }
    }
    private void TrySetRoom(Room toRoom, CamPosition toRoomCamPos)
    {
        toRoom.OnRoomEntry(toRoomCamPos);
        _currentRoomIndex = toRoom.RoomIndex;
    }
    public void ChangeCamPos(bool right)
    {
        Room currentRoom;
        _rooms.TryGetValue(_currentRoomIndex, out currentRoom);
        currentRoom.ChangeCamPos(right);

    }
}
