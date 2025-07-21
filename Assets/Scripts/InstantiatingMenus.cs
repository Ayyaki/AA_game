using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatingMenus : MonoBehaviour
{
    public StartGame startGameScript;
    public GameObject startScreenPrefab;
    private GameObject _instances;
    public GameObject instances { get { return _instances; } }
    private Button throwButton;
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0f;
        throwButton = GetComponentInChildren<Button>();
        throwButton.interactable = false;
        _instances = Instantiate(startScreenPrefab, transform);
        _instances.GetComponentInChildren<Button>().onClick.AddListener(startGameScript.startGame);
        _instances.GetComponentInChildren<Button>().onClick.AddListener(removeStartScreen);
        _instances.GetComponentInChildren<Button>().onClick.AddListener(startGameScript.arrangeThrowButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void removeStartScreen()
    {
        Destroy(_instances);
    }


}
