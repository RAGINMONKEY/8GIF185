using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICrosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    private Rect position;
    // Start is called before the first frame update
    void Start()
    {
        position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height);
    }

    private void OnGUI()
    {
        GUI.DrawTexture(position, crosshairTexture);
    }
}
