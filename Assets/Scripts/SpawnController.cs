using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public int nextFruitID;
    public GameObject fruit;
    private Fruit fruitSetup;
    public SpriteRenderer pointer;
    [Range(0f, 1f)]
    public float fruitTargetSpeed;
    [Space]
    public Core core; 
    public LevelSettings level;

    
    public void Awake()
    {
        HidePointer();
    }
    void Start()
    {
        SpawnFruitNoDelay();
        pointer.transform.position = Vector3.up * (transform.position.y - (pointer.transform.localScale.y / 2));

    }


    void Update()
    {
        if(Input.touchCount > 0 && core.canMerge && fruit != null)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended )
            {
                DropChangeFruit();
            }
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary )
            {
                MoveFruit(touch);
            }
          
        }
    }
    public void MoveFruit(Touch target)
    {
        MoveFruitToPosition(TouchConvert(target).x);
        ShowPointer();
        ChangePointerPosition();

    }
    public void MoveFruitToPosition(float x)
    {
        Vector3 target = Vector3.zero;
        target.y = transform.position.y;
        target.x = x;


        if (target.x <= MaxPosition(fruitSetup) && target.x >= -MaxPosition(fruitSetup))
        {
            level.borderLeft.HideSmooth(0.5f);
            level.borderRight.HideSmooth(0.5f);
            fruit.transform.position = Vector3.Lerp(fruit.transform.position,target,fruitTargetSpeed);
        }
        else
        {
            if (target.x > MaxPosition(fruitSetup))
            {
                fruit.transform.position = new Vector3(Mathf.Lerp(fruit.transform.position.x,MaxPosition(fruitSetup), fruitTargetSpeed), fruit.transform.position.y);
                level.borderRight.ShowSmooth(0.5f);
            }
            if (target.x < -(level.spawnWidth - fruit.transform.localScale.x / 2))
            {
                fruit.transform.position = new Vector3(Mathf.Lerp(fruit.transform.position.x, -MaxPosition(fruitSetup), fruitTargetSpeed), fruit.transform.position.y); ;
                level.borderLeft.ShowSmooth(0.5f);
            }
        }

    }
    public void ChangePointerPosition()
    {
        Vector3 vec = Vector3.zero;
        vec.y = pointer.transform.position.y;
        vec.x = fruit.transform.position.x;
        vec.z = pointer.transform.position.z;
        pointer.transform.position = vec;
    }
    public void DropChangeFruit()
    {
        level.borderLeft.HideSmooth(0.5f);
        level.borderRight.HideSmooth(0.5f);
        HidePointer();
        DropFruit();

        SpawnFruit();
    }
    public void DropFruit()
    {
        fruitSetup.dropped = true;
        fruitSetup.rg.bodyType = RigidbodyType2D.Dynamic;
        fruit = null;
        fruitSetup = null;
    }
    public void SpawnFruit()
    {
        StartCoroutine(SpawnFruitDelay());
    }
    public void SpawnFruitNoDelay()
    {
        Core.fruits++;
        fruit = Instantiate(core.Fruits[nextFruitID], transform.position, Quaternion.identity, transform.parent);//Set to random
        fruitSetup = fruit.GetComponent<Fruit>();
        fruitSetup.rg.bodyType = RigidbodyType2D.Static;
        nextFruitID = Random.Range(0, 3);
    }
    private IEnumerator SpawnFruitDelay()
    {
        Core.fruits++;
        yield return new WaitForSeconds(2f);
        fruit = Instantiate(core.Fruits[nextFruitID], transform.position, Quaternion.identity, transform.parent);//Set to random
        fruitSetup = fruit.GetComponent<Fruit>();
        fruitSetup.rg.bodyType = RigidbodyType2D.Static;
        nextFruitID = Random.Range(0, 3);
    }
    public void ShowPointer()
    {
        pointer.enabled = true;
    }
    public void HidePointer()
    {
        pointer.enabled = false;
    }

    public Vector3 TouchConvert(Touch touch)
    {
        return Camera.main.ScreenToWorldPoint(touch.position);
    }

    public float MaxPosition(Fruit fruit)
    {
        return level.spawnWidth - fruit.transform.localScale.x / 2;
    }
}
