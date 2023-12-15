using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject pointer;
    public SpriteRenderer PointerLine;
    public int nextFruit;
    public GameObject fruitObj;
    public Fruit fruitSetup;
    private Vector3 v;
    public float spawnWidth;
    [Space]
    public Core core;
    public UI_VFX_Controller borderLeft;
    public UI_VFX_Controller borderRight;
    private bool fruitSpawned;
    public void Awake()
    {
        HidePointer();
    }
    void Start()
    {
        SpawnFruitNoDelay();
        v = new Vector3 (0, 0, 0);
        PointerLine.transform.position = Vector3.up * (pointer.transform.position.y - (PointerLine.transform.localScale.y / 2));

    }


    void Update()
    {
        if(Input.touchCount > 0 && core.canMerge)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved && fruitObj != null)
            {
                MoveFruitRule(touch);
                ShowPointer();
                
                ChangePointerPosition();

            }
            if (touch.phase == TouchPhase.Ended && fruitObj != null)
            {
                borderLeft.HideSmooth(0.5f);
                borderRight.HideSmooth(0.5f);
                HidePointer();
                DropFruit();
                SpawnFruit();
            }
        }
    }
    public void MoveFruitRule(Touch touch)
    {
        v.y = pointer.transform.position.y;
        v.x = Camera.main.ScreenToWorldPoint(touch.position).x;


        if (v.x <= spawnWidth - fruitObj.transform.localScale.x / 2 && v.x >= -(spawnWidth - fruitObj.transform.localScale.x / 2))
        {
            borderLeft.HideSmooth(0.5f);
            borderRight.HideSmooth(0.5f);
            fruitObj.transform.position = v;
        }
        else
        {
            if(v.x > spawnWidth - fruitObj.transform.localScale.x / 2) borderRight.ShowSmooth(0.5f);
            if (v.x < -(spawnWidth - fruitObj.transform.localScale.x / 2)) borderLeft.ShowSmooth(0.5f);
        }

    }
    public void ChangePointerPosition()
    {
        Vector3 vec = Vector3.zero;
        vec.y = PointerLine.transform.position.y;
        vec.x = fruitObj.transform.position.x;
        vec.z = PointerLine.transform.position.z;
        PointerLine.transform.position = vec;
    }
    public void DropFruit()
    {
        fruitSetup.dropped = true;
        fruitSetup.rg.bodyType = RigidbodyType2D.Dynamic;
        fruitObj = null;
        fruitSetup = null;
    }
    public void SpawnFruit()
    {
        StartCoroutine(SpawnFruitDelay());
    }
    public void SpawnFruitNoDelay()
    {
        Core.fruits++;
        fruitObj = Instantiate(core.Fruits[nextFruit], pointer.transform.position, Quaternion.identity, transform.parent);//Set to random
        fruitSetup = fruitObj.GetComponent<Fruit>();
        fruitSetup.rg.bodyType = RigidbodyType2D.Static;
    }
    public IEnumerator SpawnFruitDelay()
    {
        Core.fruits++;
        yield return new WaitForSeconds(2f);
        fruitObj = Instantiate(core.Fruits[nextFruit], pointer.transform.position, Quaternion.identity, transform.parent);//Set to random
        fruitSetup = fruitObj.GetComponent<Fruit>();
        fruitSetup.rg.bodyType = RigidbodyType2D.Static;
        nextFruit = Random.Range(0, 2);
    }
    public void ShowPointer()
    {
        PointerLine.enabled = true;
    }
    public void HidePointer()
    {
        PointerLine.enabled = false;
    }
}
