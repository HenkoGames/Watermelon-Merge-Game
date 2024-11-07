using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWindow : MonoBehaviour
{
    public SpawnController spawner;
    public Core core;
    public Image image;
    private List<Sprite> spritesCache = new List<Sprite>();
    // Start is called before the first frame update
    void Awake()
    {
        foreach(GameObject f in core.Fruits)
        {
            spritesCache.Add(f.GetComponent<SpriteRenderer>().sprite);
        }
    }

    
    void Update()
    {
        image.sprite = spritesCache[spawner.nextFruitID];
    }
}
