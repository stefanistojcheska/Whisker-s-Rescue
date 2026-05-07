using System;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    [SerializeField] private Transform nextRoom;
    [SerializeField] private CameraControler camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             camera.MoveToNewRoom(nextRoom);
            
        }
    }
}
