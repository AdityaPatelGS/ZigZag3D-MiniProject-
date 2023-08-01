using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    public GameManager gm;

    void Awake()
    {
        target = gm.Player.transform;
        offset = transform.position - target.position;

    }
    void Update()
    {
       target = gm.Player.transform;
    }
    private void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
