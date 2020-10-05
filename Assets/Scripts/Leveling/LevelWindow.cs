 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class LevelWindow : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

   [SerializeField]
    private Image experienceBarImage;

    [SerializeField]
    private Button button;
    private LevelSystem lvlSystem;
    private void Awake()
    {
       // experienceBarImage = GetComponent<Image>();
        button.onClick.AddListener(() => lvlSystem.AddExp(30));
    }

    private void SetExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
        Debug.Log(experienceNormalized);
    }

    private void SetLevelNumber(int levelNumber)
    {
        levelText.SetText ("Level\n" + (levelNumber + 1));
    }

    public void SetLevelSystem(LevelSystem lvlSystem)
    {
        // Set the LevelSystem object
        this.lvlSystem = lvlSystem;

        // Update the starting values
        SetLevelNumber(lvlSystem.GetLevelNumber());
        SetExperienceBarSize(lvlSystem.GetExperienceNormalized());

        //Subscribe to the changed events
        lvlSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        lvlSystem.OnExperienceChanged += LevelSystem_OnExperienceChanged;
        
    }

    private void LevelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        // Level changed, update text
        SetLevelNumber(lvlSystem.GetLevelNumber());
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //Experience changed, update bar size
        SetExperienceBarSize(lvlSystem.GetExperienceNormalized());
    }
}
