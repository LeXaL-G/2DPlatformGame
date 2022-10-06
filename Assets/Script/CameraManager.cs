using System;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;
    private PlayerManager _playerManager;

    private void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
    }

    void Update()
    {
        transform.position=Vector3.Slerp(transform.position,new Vector3(target.position.x,target.position.y,-5),cameraSpeed);
    }
}
