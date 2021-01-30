using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameManager manager;
    bool hasHit;
    private void OnTriggerEnter(Collider other)
    {
        if (!hasHit)
        {
            if (other.CompareTag("Player"))
            {
                hasHit = true;
                manager.GameOver(true);
            }
        }
    }
}
