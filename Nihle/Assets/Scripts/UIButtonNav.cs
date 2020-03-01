using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIButtonNav : MonoBehaviour
{
    [Header("Title Buttons")]
    public Button playBtn;
    public Button howToBtn;
    public Button exitBtn;

    [Header("Play Buttons")]
    public Button challengeBtn;
    public Button freePlayBtn;
    public Button backBtn;

    [Header("Panels and More")]
    public GameObject titleScreen;
    public GameObject playScreen;
    public GameObject challengeScreen;
    public GameObject freePlayScreen;
    public GameObject howToPlayScreen;
    public GameObject firstSelectFree;
    public GameObject firstSelectChal;

    UnityEngine.EventSystems.EventSystem eventSystem;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("MaxLevel") <= 0) PlayerPrefs.SetInt("MaxLevel", 1);

        setNavigations();

        titleScreen.SetActive(true);
        eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
        eventSystem.SetSelectedGameObject(playBtn.gameObject);

        playScreen.SetActive(false);
        challengeScreen.SetActive(false);
        freePlayScreen.SetActive(false);
    }

    void setNavigations()
    {
        Navigation playNav = new Navigation();
        playNav.mode = Navigation.Mode.Explicit;
        playNav.selectOnDown = howToBtn;
        playNav.selectOnUp = exitBtn;
        playBtn.navigation = playNav;

        Navigation howNav = new Navigation();
        howNav.mode = Navigation.Mode.Explicit;
        howNav.selectOnDown = exitBtn;
        howNav.selectOnUp = playBtn;
        howToBtn.navigation = howNav;

        Navigation exitNav = new Navigation();
        exitNav.mode = Navigation.Mode.Explicit;
        exitNav.selectOnDown = playBtn;
        exitNav.selectOnUp = howToBtn;
        exitBtn.navigation = exitNav;


        Navigation chalNav = new Navigation();
        chalNav.mode = Navigation.Mode.Explicit;
        chalNav.selectOnDown = freePlayBtn;
        chalNav.selectOnUp = backBtn;
        challengeBtn.navigation = chalNav;

        Navigation freeNav = new Navigation();
        freeNav.mode = Navigation.Mode.Explicit;
        freeNav.selectOnDown = backBtn;
        freeNav.selectOnUp = challengeBtn;
        freePlayBtn.navigation = freeNav;

        Navigation backNav = new Navigation();
        backNav.mode = Navigation.Mode.Explicit;
        backNav.selectOnDown = challengeBtn;
        backNav.selectOnUp = freePlayBtn;
        backBtn.navigation = backNav;
    }

    //button methods

    public void playButton()
    {
        titleScreen.SetActive(false);
        playScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(challengeBtn.gameObject);
    }

    public void howToButton()
    {
        titleScreen.SetActive(false);
        playScreen.SetActive(true);
        howToPlayScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(howToPlayScreen.transform.GetChild(0).gameObject);
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void challengeButton()
    {
        playScreen.SetActive(false);
        challengeScreen.SetActive(true);

        // do more things
        eventSystem.SetSelectedGameObject(firstSelectChal);
        challengeScreen.GetComponent<UILevelButtons>().updateCollectables();
    }

    public void freePlayButton()
    {
        playScreen.SetActive(false);
        freePlayScreen.SetActive(true);

        // do more things
        eventSystem.SetSelectedGameObject(firstSelectFree);
    }

    public void backButton()
    {
        titleScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(playBtn.gameObject);
        if (howToPlayScreen.activeInHierarchy) howToPlayScreen.SetActive(false);
    }

    public void backButton2()
    {
        if (challengeScreen.activeInHierarchy) challengeScreen.SetActive(false);
        if (freePlayScreen.activeInHierarchy) freePlayScreen.SetActive(false);

        playScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(challengeBtn.gameObject);
    }

    public void hasCollectables(bool hasCollectables)
    {
        // play the level, with/without collectables
        if (hasCollectables) PlayerPrefs.SetString("Collectables", "false");
        else PlayerPrefs.SetString("Collectables", "true");
    }

    public void playLevel(int level)
    {
        //load level
        SceneManager.LoadScene(level);
    }
}
