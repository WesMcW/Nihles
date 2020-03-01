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
        if (!isFree) updateCollectables();

        eventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setNavigations()
    {
        Navigation[] navs = new Navigation[15];

        for(int i = 0; i < 15; i++)
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

    public void updateCollectables()
    {
        // shows collectables found in each level
    }
}
