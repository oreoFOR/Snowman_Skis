using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    bool hasHit = false;
    public ScoreManager manager;
    private void Start()
    {
        hasHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasHit)
        {
            if (other.CompareTag("Player"))
            {
                hasHit = true;
                manager.IncrementScore(0);
            }
        }
    }
}
