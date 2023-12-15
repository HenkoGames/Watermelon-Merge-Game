using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_VFX_Controller : MonoBehaviour
{
    [SerializeField]
    private bool connectSpriteRenderer;
    

    [HideInInspector]
    public SpriteRenderer _renderer;
    public bool activeHiding = false;
    public bool activeShowing = false;


    private void Start()
    {
        if (connectSpriteRenderer) {
            try
            {
                _renderer = GetComponent<SpriteRenderer>();
            }
            catch 
            {
                Debug.Log("No Sprite renderer here",gameObject);
            }
        }
    }

    public void HideSmooth(float time)
    {

        StartCoroutine(HideSmoothCor(time));
    }
    public void ShowSmooth(float time)
    {
        StartCoroutine(ShowSmoothCor(time));
    }
    IEnumerator HideSmoothCor(float time) 
    {
        int iteratorBreak = 100;
        activeHiding = true;
        activeShowing = false;
        while (_renderer.color.a > 0 && iteratorBreak > 0 && activeHiding)
        {
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a - 0.01f);
            iteratorBreak--;
            yield return new WaitForSeconds(time/100);
        }
        activeHiding = false;

    }
    IEnumerator ShowSmoothCor(float time)
    {
        int iteratorBreak = 100;
        activeShowing = true;
        activeHiding = false;
        while (_renderer.color.a < 1 && iteratorBreak > 0 && activeShowing)
        {
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, _renderer.color.a + 0.01f);
            iteratorBreak--;
            yield return new WaitForSeconds(time / 100);
        }
        activeShowing = false;

    }
}
