using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fruit : MonoBehaviour
{
    public int level;
    public GameObject nextLevel;
    private Collider2D col;
    [HideInInspector]
    public Rigidbody2D rg;
    public UnityEvent WhenDouble;
    [Space]
    public bool canDouble = false;
    public bool dropped = false;
    public bool hadContact = false;
    public bool canGetOut = true;
    [Space]
    public int scoreForUnite;
    public float addStartTorque;
    public float secondsToUnite = 0.3f;
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
            
            if(f.level == level && canDouble && f.canDouble)
            {
                canDouble = false;
                f.canDouble = false;
               
                canGetOut = false;
                f.canGetOut = false;

                
                if (nextLevel != null)
                {
                    GameObject nextF = Instantiate
                    (
                    nextLevel,
                    Vector3.Lerp(transform.position,
                    collision.transform.position, 0.5f),
                    Quaternion.identity,
                    transform.parent
                    );
                    Core.activeFruits.Add(nextF.GetComponent<Fruit>());

                }
                WhenDouble.Invoke();

                Core.score += scoreForUnite;
                SoundManager.instance.PlaySound(SoundManager.Sound.pop);
                Core.activeFruits.Remove(f);
                Core.activeFruits.Remove(this);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
    public void DestroyWithVFX()
    {
        SoundManager.instance.PlaySound(SoundManager.Sound.pop);
        Core.score += scoreForUnite;
        Destroy(gameObject);
    }
    public void FinalFruitActions()
    {
        Core.instance.ClearFruits();
    }
}
