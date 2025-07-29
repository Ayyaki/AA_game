using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InstantiatingMenus : MonoBehaviour
{
    public StartGame startGameScript;
    public GameObject startScreenPrefab;
    private GameObject _instances;
    [SerializeField] private GameObject levelPassedScreen;
    [SerializeField] private TextMeshProUGUI textOfLevelPassed;
    public GameObject instances { get { return _instances; }
        private set { } }
    private Button throwButton;
    [SerializeField] private GameObject levelFailedScreen;
    [SerializeField] private TextMeshProUGUI textOfLevelFailed;
    public bool nextLevelMenuDisplayed;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {

        Time.timeScale = 0f;
        levelFailedScreen.SetActive(false);
        levelPassedScreen.SetActive(false);
        throwButton = GetComponentInChildren<Button>();
        throwButton.interactable = false;
        startScreenPrefab.GetComponentInChildren<TextMeshProUGUI>().text = $"LEVEL {SpawnLevelObjects.instance.level}";
        _instances = Instantiate(startScreenPrefab, transform);
        _instances.GetComponentInChildren<Button>().onClick.AddListener(startGameScript.startGame);
        
        _instances.GetComponentInChildren<Button>().onClick.AddListener(removeStartScreen);
        _instances.GetComponentInChildren<Button>().onClick.AddListener(startGameScript.arrangeThrowButton);

    }

    // Update is called once per frame
    void Update()
    {

        if (SpawnLevelObjects.instance.isLevelPassed())
        {
            nextLevelMenu();
            nextLevelMenuDisplayed = true;
        }
    }
    void removeStartScreen()
    {
        Destroy(_instances);
    }
    public void restartMenu()
    {
        Time.timeScale = 0f;
        textOfLevelFailed.text = $"Failed LEVEL {SpawnLevelObjects.instance.level}";
        levelFailedScreen.SetActive(true);
    }
    public void nextLevelMenu()
    {

        textOfLevelPassed.text = $"Passed LEVEL {SpawnLevelObjects.instance.level}";
        levelPassedScreen.SetActive(true);
    }


}
