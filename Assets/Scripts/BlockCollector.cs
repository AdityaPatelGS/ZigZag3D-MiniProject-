using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            Destroy(other.gameObject);
        }
    }
}
