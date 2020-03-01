using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevelButtons : MonoBehaviour
{
    public bool isFree;
    UnityEngine.EventSystems.EventSystem eventSystem;

    public Button[] LevelButtons;
    public Button backBtn;

    // Start is called before the first frame update
    void Start()
    {
        setNavigations();

        eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
    }

    void setNavigations()
    {
        Navigation[] navs = new Navigation[15];

        if (isFree)
        {
            for (int i = 0; i < 15; i++)
            {
                navs[i] = new Navigation();
                navs[i].mode = Navigation.Mode.Explicit;

                if (i - 3 < 0) navs[i].selectOnUp = backBtn;
                else navs[i].selectOnUp = LevelButtons[i - 3];

                if (i + 3 > 14) navs[i].selectOnDown = backBtn;
                else navs[i].selectOnDown = LevelButtons[i + 3];

                if (i - 1 < 0) navs[i].selectOnLeft = LevelButtons[14];
                else navs[i].selectOnLeft = LevelButtons[i - 1];

                if (i + 1 > 14) navs[i].selectOnRight = LevelButtons[0];
                else navs[i].selectOnRight = LevelButtons[i + 1];

                LevelButtons[i].navigation = navs[i];
            }

            Navigation backNav = new Navigation();
            backNav.mode = Navigation.Mode.Explicit;
            backNav.selectOnUp = LevelButtons[13];
            backNav.selectOnDown = LevelButtons[0];
            backBtn.navigation = backNav;
        }
        else
        {
            for (int i = 0; i < 15; i++)
            {
                navs[i] = new Navigation();
                navs[i].mode = Navigation.Mode.Explicit;

                if (i - 3 < 0) navs[i].selectOnUp = backBtn;
                else
                {
                    if (LevelButtons[i - 3].interactable) navs[i].selectOnUp = LevelButtons[i - 3];
                    else navs[i].selectOnUp = backBtn;
                }

                if (i + 3 > 14) navs[i].selectOnDown = backBtn;
                else
                {
                    if (LevelButtons[i + 3].interactable) navs[i].selectOnDown = LevelButtons[i + 3];
                    else navs[i].selectOnDown = backBtn;
                }

                if (i - 1 < 0 && LevelButtons[14].interactable) navs[i].selectOnLeft = LevelButtons[14];
                else if (i - 1 < 0 && !LevelButtons[14].interactable) navs[i].selectOnLeft = LevelButtons[PlayerPrefs.GetInt("MaxLevel")];
                else
                {
                    navs[i].selectOnLeft = LevelButtons[i - 1];
                }

                if (i + 1 > 14 || PlayerPrefs.GetInt("MaxLevel") < i + 1) navs[i].selectOnRight = LevelButtons[0];
                else
                {
                    navs[i].selectOnRight = LevelButtons[i + 1];
                }

                LevelButtons[i].navigation = navs[i];
            }

            Navigation backNav = new Navigation();
            backNav.mode = Navigation.Mode.Explicit;
            backNav.selectOnUp = LevelButtons[PlayerPrefs.GetInt("MaxLevel") - 1];
            backNav.selectOnDown = LevelButtons[0];
            backBtn.navigation = backNav;
        }
    }

    public void updateCollectables()
    {
        LevelButtons[0].interactable = true;

        if(PlayerPrefs.GetInt("Level1Score") > 0)
        {
            for (int j = 0; j < PlayerPrefs.GetInt("Level1Score"); j++)
            {
                LevelButtons[0].transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                Debug.Log("Add Star for Level " + j);
            }
        }

        // shows collectables found in each level
        for (int i = 1; i <= PlayerPrefs.GetInt("MaxLevel"); i++)
        {
            LevelButtons[i].interactable = true;

            string playPref = "Level" + (i + 1) + "Score";
            Debug.Log("Finding Score of Level: " + playPref);

            if(PlayerPrefs.GetInt(playPref) > 0)
            {
                for(int j = 0; j < PlayerPrefs.GetInt(playPref); j++)
                {
                    LevelButtons[i].transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                    Debug.Log("Add Star for Level " + j);
                }
            }
        }
    }
}
