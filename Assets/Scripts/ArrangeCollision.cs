using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrangeCollision : MonoBehaviour
{

    [SerializeField] private ArrowVisibility arrowVisibility;
    private Transform centerCircleTransform;
    [SerializeField] private Transform arrowTransform;
    private InstantiatingMenus instantiateMenus;
    private GameObject myCanvas;

    private void Start()
    {
        instantiateMenus = GameObject.Find("Canvas").GetComponent<InstantiatingMenus>();
        if (centerCircleTransform == null)
        {
            GameObject centerObj = GameObject.FindGameObjectWithTag("centerCircle");
            if (centerObj != null)
            {
                centerCircleTransform = centerObj.transform;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("arrowHead") && collision.gameObject.CompareTag("arrowHead"))
        {
            instantiateMenus.restartMenu();
        }
        else if (gameObject.CompareTag("arrowTail") && collision.gameObject.CompareTag("centerCircle"))
        {
            Debug.Log("collided.");
            Rigidbody2D rigidBody2D = GetComponentInParent<Rigidbody2D>();

            rigidBody2D.bodyType = RigidbodyType2D.Kinematic;

            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            arrowVisibility.makeArrowTailVisible();
            arrowTransform.SetParent(centerCircleTransform);
            SpawnLevelObjects.instance.collisionWCenterCircle = true;
            SpawnLevelObjects.instance.childCount++;
            changeRotation(SpawnLevelObjects.instance.childCount);
            
        }
    }
    void changeRotation(int count)
    {
        if (count % 5 == 0)
        {
            if (SpawnLevelObjects.instance.isClockwise)
            {
                SpawnLevelObjects.instance.isClockwise = false;
            }
            else
            {
                SpawnLevelObjects.instance.isClockwise = true;
            }
        }
    }

}
