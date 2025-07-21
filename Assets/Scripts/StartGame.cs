using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    private Button throwButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        Time.timeScale = 1f;
        SpawnLevelObjects.instance.instantiateArrows();
        SpawnLevelObjects.instance.instantiateCenterCircle();
    }
    public void arrangeThrowButton()
    {
        throwButton = GetComponentInChildren<Button>();
        throwButton.interactable = true;
        throwButton.onClick.AddListener(throwArrow);

    }
    private void throwArrow()
    {
        GameObject thrownArrow = SpawnLevelObjects.instance.arrows.Dequeue();
        thrownArrow.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
    }

}
