using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        throwButton.onClick.AddListener(SpawnLevelObjects.instance.throwArrow);

    }
    public void restartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void continueGame()
    {
        int currentLevel = PlayerPrefs.GetInt("Level", 1); //hiç kaydedilememiş ise burada bunu çağırıyor aslında getInt buna bakar (yani default değerdir)
        ++currentLevel;
        PlayerPrefs.SetInt("Level", currentLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   
}
