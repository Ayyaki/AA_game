using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevelObjects : MonoBehaviour
    
{
    public static SpawnLevelObjects instance;
    public GameObject CenterCirclePrefab;
    public GameObject ArrowPrefab;
    public int level;
    private int arrowCount;
    private int pinnedCount;
    internal float rotationSpeed;
    private bool isClockwise;
    GameObject[] arrows;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;


    }
    private void Start()
    {
        level = 1;
        arrowCount = Mathf.Min(5 + level / 2, 25);
        pinnedCount = Mathf.Min(level / 2, arrowCount - 2);
        rotationSpeed = 0.5f;
        isClockwise = level % 2 == 0;


    }
    public void instantiateCenterCircle()
    {
        Instantiate(CenterCirclePrefab, transform);
    }
    //arrowların arasında 0.6 boşluk olacak şekilde instantiate et.
    public void instantiateArrows()
    {
        arrows = new GameObject[arrowCount];
        for(int i = 0; i<arrowCount; i++)
        {
            Debug.Log(i * 0.6f);
            arrows[i] = Instantiate(ArrowPrefab, new Vector3(0, -3-i*0.6f, 0), Quaternion.identity);
        }

    }
    /*
    public void changeScore(int score)
    {
        if (digitContainer)
        {
            foreach (Transform child in digitContainer)
            {
                Destroy(child.gameObject);
            }
            if (digitContainer.transform.position.x > 0)
            {
                digitContainer.transform.position = new Vector3(0, -801, 0);
            }
        }
        string scoreString = score.ToString();
        foreach(char c in scoreString)
        {
            int digit = int.Parse(c.ToString());
          
            GameObject digitObj = Instantiate(digitPrefab, digitContainer);
            digitObj.GetComponent<Image>().sprite = digitSprites[digit];
        }
    }
    */


}
