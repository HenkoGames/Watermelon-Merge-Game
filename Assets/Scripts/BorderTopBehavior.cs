using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderTopBehavior : MonoBehaviour
{
    public Collider2D triggerZone;
    public UI_VFX_Controller controller;
    public List<Fruit> fruitList = new List<Fruit>();
    private void Update()
    {
        foreach(Fruit f in fruitList)
        {
            if (f.hadContact && !controller.activeShowing)
            {
                controller.ShowSmooth(1.5f);
                break;
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Fruit>(out Fruit f) )
        {
            fruitList.Add(f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bool moreFruits = false;
        if(collision.TryGetComponent<Fruit>(out Fruit f))
        {
            fruitList.Remove(f);
            foreach(Fruit fruit in fruitList)
            {
                    moreFruits = true;
            }
            if (!moreFruits) controller.HideSmooth(1f);
        }
    }


}
