using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BK_PlayerLevel : MonoBehaviour 
{
    public Text levelDisplay;
    public Image xpDisplay;

    public int MIN_SCALE { get; } = 341 ;
    public int MAX_SCALE { get; } = 0;
    public int XP_TO_ADD { get; } = 250;

    public static BK_PlayerLevel instance;

    void Awake() 
    {  
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        levelDisplay.text = "Lvl : " + BK_DBManager.level.ToString();

        //xpDisplay.rectTransform.offsetMax = new Vector2(MIN_SCALE * (BK_DBManager.xp / BK_DBManager.maxXp), xpDisplay.rectTransform.offsetMax.y);
        //xpDisplay2.rectTransform.offsetMax = xpDisplay.rectTransform.offsetMax;
    }

    public void AddXP(int xp) 
    {
        BK_DBManager.xp += xp;

        if(BK_DBManager.xp >= BK_DBManager.maxXp) 
        {
            BK_DBManager.level++;
            levelDisplay.text = "Lvl : " + BK_DBManager.level.ToString();

            BK_DBManager.xp =  BK_DBManager.xp - BK_DBManager.maxXp;
            BK_DBManager.maxXp += XP_TO_ADD;
        }

        float percentageOfLevel = 1 - (BK_DBManager.xp / BK_DBManager.maxXp);
        xpDisplay.rectTransform.offsetMax = new Vector2(-(MIN_SCALE * percentageOfLevel), xpDisplay.rectTransform.offsetMax.y);
    }
}