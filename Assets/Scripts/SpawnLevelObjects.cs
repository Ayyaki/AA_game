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
    public bool isClockwise;
    public Queue<GameObject> arrows;
    public bool collisionWCenterCircle;
    public bool collisionHH;
    public bool passedTheLevel;
    public int childCount;
    [SerializeField] private InstantiatingMenus instantiateMenusInstance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        
        level = PlayerPrefs.GetInt("Level", 1);
    }
    private void Start()
    {
        Debug.Log("gameplay level = "+ level);
        arrowCount = Mathf.Min(5 + level / 2, 25);
        pinnedCount = Random.Range(1, 6);
        rotationSpeed = 30 + level * 3;
        isClockwise = level % 2 == 0;


    }
    public bool isLevelPassed()
    {
        
        if (instantiateMenusInstance.nextLevelMenuDisplayed)
        {
            return false;
        }
        if(childCount == arrowCount)
        {
            return true;
        }
        
        return false;
    }
    private void Update()
    {
        if (collisionWCenterCircle)
        {
            getArrowsFront();
            collisionWCenterCircle = false;
        }
        
        
    }
    public void instantiateCenterCircle()
    {
        GameObject circle = Instantiate(CenterCirclePrefab, transform);

        if (level%3 == 0) 
        {
            
            float angleStep = 360f / pinnedCount;

            // Circle collider radius'u ve scale hesaba katılıyor
            float radius = 2.054085378f;

            for (int i = 0; i < pinnedCount; i++)
            {
                float angle = i * angleStep;
                Vector3 pos = circle.transform.position + Quaternion.Euler(0, 0, angle) * Vector3.up * (radius + 0.6f); // 0.6f = arrow yüksekliği ayarı

                GameObject arrow = Instantiate(ArrowPrefab, pos, Quaternion.Euler(0, 0, angle + 180f));
                arrow.transform.SetParent(circle.transform);
                
                arrow.GetComponentInChildren<ArrowVisibility>().makeArrowTailVisible();
                arrow.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }
        }
    }
    //the space between arrows are 0.6.
    public void instantiateArrows()
    {
        arrows = new Queue<GameObject>();
        for(int i = 0; i<arrowCount; i++)
        {
            GameObject arrow = Instantiate(ArrowPrefab, new Vector3(0, -3 - i * 0.6f, 0), Quaternion.identity);
            arrow.GetComponentInChildren<ArrowVisibility>().makeArrowTailInvisible();
            arrows.Enqueue(arrow);
        }

    }
    public void throwArrow()
    {
        if (arrows.Count != 0)
        {
            GameObject thrownArrow = arrows.Dequeue();
            var rb = thrownArrow.GetComponentInChildren<Rigidbody2D>();
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

        }

        

    }
    private void getArrowsFront()
    {
        if (arrows.Count != 0)
        {
            foreach (var arrow in arrows)
            {
                arrow.transform.position = new Vector3(0, arrow.transform.position.y + 0.6f, 0);
            }
        }

    }
    




}
