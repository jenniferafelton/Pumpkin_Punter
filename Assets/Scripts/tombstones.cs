using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstones : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Destroy(gameObject);

    }


}
