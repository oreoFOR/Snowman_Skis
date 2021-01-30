using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeverManager : MonoBehaviour
{
    public float dist;
    float lastPos;

    public int exploded;

    public bool fever;

    public GameObject feverWeapon;
    public ParticleSystem feverSytem;
    public UiManager uiManager;
    public SnowManMover mover;

    public ParticleSystem feverLines;
    private void Start()
    {
        lastPos = transform.position.z;
    }
    public void ActivateFever()
    {
        fever = true;
        dist = 0;
        exploded = 0;
        feverWeapon.SetActive(true);
        feverSytem.Play();
        feverLines.Play();
        Invoke("DeactivateFever", 3);
        mover.speed = 30;
        uiManager.StartFeverCountdown();
    }
    public void DeactivateFever()
    {
        mover.speed = 18.5f;
        fever = false;
        feverWeapon.SetActive(false);
        dist = 0;
        exploded = 0;
        feverSytem.Stop();
        feverLines.Stop();
    }
}
