using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVisibility: MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeArrowTailInvisible()
    {
        spriteRenderer.enabled = false;
    }
    public void  makeArrowTailVisible()
    {
        spriteRenderer.enabled = true;
    }
}
