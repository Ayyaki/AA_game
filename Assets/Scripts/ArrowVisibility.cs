using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVisibility: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  makeArrowVisible()
    {
        Debug.Log("makeArrowVisible");
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
