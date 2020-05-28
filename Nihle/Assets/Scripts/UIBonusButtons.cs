using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBonusButtons : MonoBehaviour
{
    public bool starsUpdated = false;
    public Button[] LevelButtons;

    // Start is called before the first frame update
    void Start()
    {
        updateStars();
    }

    void updateStars()
    {
        if (!starsUpdated)
        {
            starsUpdated = true;

            for(int i = 0; i < LevelButtons.Length; i++)
            {
                string scoreString = "Bonus" + i + "Score";
                if(PlayerPrefs.GetInt(scoreString) > 0)
                {
                    for (int j = 0; j < PlayerPrefs.GetInt(scoreString); j++)
                    {
                        LevelButtons[i].transform.GetChild(1).GetChild(j).gameObject.SetActive(true);
                        Debug.Log("Add Star for Bonus Level " + i);
                    }
                }
            }
        }
    }
}
