using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    private float followSpeed;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private Vector3 offset = Vector3.up;

    void FixedUpdate()
    {
        float speed = followSpeed * Time.fixedDeltaTime;
        transform.position = Vector3.Lerp(transform.position, player.position + offset, speed);
    }
}
