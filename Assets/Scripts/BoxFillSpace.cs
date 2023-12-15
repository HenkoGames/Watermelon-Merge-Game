using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFillSpace : MonoBehaviour
{
    public Core core;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Fruit>(out Fruit fruit)) 
        { 
            if(fruit.hadContact && fruit.canGetOut && core.canMerge) core.ShowRestartWindow();
        }
    }
}
