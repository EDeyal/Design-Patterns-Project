using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    #region Fields
    [SerializeField]
    int _leanTweenTime =1;
    [SerializeField]
    int _roomIndex;
    [SerializeField]
    CamPosition[] _roomCamPositions;
    int _currentCameraLocationIndex;
    Dictionary<int, Door> _exits = new Dictionary<int, Door>();
    Dictionary<int, CamPosition> _camPositions = new Dictionary<int, CamPosition>();
    #endregion

    #region Properties
    public Dictionary<int ,Door> exits => _exits;
    public Dictionary<int, CamPosition> camPositions
    {
        get
        {
            if (_camPositions == null || _camPositions.Count == 0)
                SetRoomCams();
            return _camPositions;
        }

    }
    public int RoomIndex => _roomIndex;
    #endregion

    #region Methods
    private void SetRoomCams()
    {
        Debug.Log($"Setting Room: {this}");
        for (int i = 0; i < _roomCamPositions.Length; i++)
        {
            _roomCamPositions[i].index = i;
        }
        foreach (var camPos in _roomCamPositions)
        {
            _camPositions.Add(camPos.index, camPos);
        }
    }
    public void ChangeCamPos(bool right)
    {
        if (camPositions.Count == 0)
        {

            throw new System.Exception("Room ChangeCamPos has a problem");
        }
        int addition = 0;
        if (right == true)
        {
            addition = 1;
        }
        else
        {
            addition = -1;
        }
        int toCamIndex = _currentCameraLocationIndex + addition;
        if (!camPositions.ContainsKey(toCamIndex))
        {
            if (toCamIndex >= camPositions.Count)
            {
                toCamIndex = 0;
            }
            else
            {
                toCamIndex = camPositions.Count -1;
            }
        }
        CamPosition camPos;
        camPositions.TryGetValue(toCamIndex, out camPos);
        SetCamera(camPos);
        _currentCameraLocationIndex = toCamIndex;
    }
    private void SetCamera(CamPosition toCam)
    {
        var cam = GameManager.instance.mainCamera.gameObject;
        LeanTween.move(cam, toCam.transform.position,_leanTweenTime);
        LeanTween.rotate(cam, toCam.rotation, _leanTweenTime);
    }
    public void OnRoomEntry(CamPosition toCam)
    {
        _currentCameraLocationIndex = toCam.index;
        SetCamera(toCam);
    }
    public void OnRoomExit()
    {

    }
    #endregion


}
