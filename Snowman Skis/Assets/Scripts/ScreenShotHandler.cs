using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShotHandler : MonoBehaviour
{
    Camera cam;
    bool takeScreenShot;
    private void Awake()
    {
        cam = GetComponent<Camera>();
    }
    private void OnPostRender()
    {
        if (takeScreenShot)
        {
            takeScreenShot = false;
        }
    }
    public void TakeScreenshot(int width, int height)
    {
        cam.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShot = true;
    }
}
