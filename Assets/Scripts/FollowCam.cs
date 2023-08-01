using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    private bool PlayerAssigned=false;

    //void Awake()
    //{
    //    offset = transform.position - target.position;
    //}

    //private void Start()
    //{
    //    offset = transform.position - target.position;
    //}
    public void StartGame(Transform Player)
    {

        target = Player;
        offset = transform.position - target.position;
        PlayerAssigned = true;  
    }

    private void LateUpdate()
    {
        if (PlayerAssigned)
        {
            transform.position = target.position + offset;
        }
    }
}
