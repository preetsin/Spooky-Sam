using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour
{
    public Texture2D crosshairTexture;
    Rect position;

    void Start()
    {
        //position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) / 2, crosshairTexture.width, crosshairTexture.height);
    }

    void OnGUI()
    {
        //GUI.DrawTexture(position, crosshairTexture);

        Vector2 mousePosition = Event.current.mousePosition;
        GUI.DrawTexture(new Rect(mousePosition.x - (crosshairTexture.width / 2),
                                 mousePosition.y - (crosshairTexture.height / 2),
                                 crosshairTexture.width,
                                 crosshairTexture.height), crosshairTexture);

    }
}
