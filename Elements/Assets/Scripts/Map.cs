using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//this sets the map in play scene.
public class Map : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    public Sprite Fire;
    public Sprite Water;
    public Sprite Earth;
    public Sprite Lightning;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        string map = PlayerPrefs.GetString("SelectedMap", "Map_Fire");

        if (map == "Map_Fire")
        {
            spriteRenderer.sprite = Fire;
        }
        if (map == "Map_Water")
        {
            spriteRenderer.sprite = Water;
        }
        if (map == "Map_Earth")
        {
            spriteRenderer.sprite = Earth;
        }
        if (map == "Map_Lightning")
        {
            spriteRenderer.sprite = Lightning;
        }
    }

    
}
