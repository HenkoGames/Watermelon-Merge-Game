using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public Sprite image;
    public int level;
    public GameObject nextLevel;
    private Collider2D col;
    public Rigidbody2D rg;
    public UnityEvent WhenDouble;
    [Space]
    public bool canDouble = true;
    public bool dropped = false;
    public bool hadContact = false;
    public bool canGetOut = true;
    [Space]
    public int scoreForUnite;
    public float addStartTorque;
    private void Awake()
    {
        try
        {
            col = GetComponent<Collider2D>();
        }
        catch {
            Debug.Log("No collider here",gameObject);
        }
        try
        {
            rg = GetComponent<Rigidbody2D>();
            
        }
        catch
        {
            Debug.Log("No Rigidbody here", gameObject);
        }
        rg.AddTorque(Random.Range(-addStartTorque, addStartTorque));

    }
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hadContact = true;
        if (collision.gameObject.TryGetComponent<Fruit>(out Fruit f)) 
        {
            
            if(f.level == level && canDouble)
            {
                canDouble = false;
                f.canDouble = false;
                WhenDouble.Invoke();


                canGetOut = false;
                f.canGetOut = false;


                Instantiate
                    (
                    nextLevel, 
                    Vector3.Lerp(transform.position, 
                    collision.transform.position, 0.5f), 
                    Quaternion.identity, 
                    transform.parent
                    );
                Core.score += scoreForUnite;
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
