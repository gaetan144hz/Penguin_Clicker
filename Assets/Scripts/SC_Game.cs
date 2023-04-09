using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SC_Game : MonoBehaviour
{
    //CLICKER
    [Header("CLICKER")]
    public TextMeshProUGUI scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasePerSecond;
    public float x;
    
    //SHOP
    [Header("SHOP")]
    public int shop1prize;
    public int shop2prize;
    public TextMeshProUGUI shop1Text;
    public TextMeshProUGUI shop2Text;
    
    //AMOUNT
    [Header("AMOUNT")]
    public TextMeshProUGUI amount1Text;
    public int amount1;
    public float amount1Profit;
    public TextMeshProUGUI amount2Text;
    public int amount2;
    public float amount2Profit;
    
    //UPGRADE
    [Header("UPGRADE")] 
    public int upgradePrize;
    public TextMeshProUGUI upgradeText;
    
    //NEW
    [Header("NEW")] 
    public int allUpgradePrize;
    public TextMeshProUGUI allUpradePrizeText;
    
    //ACHIEVEMENT
    [Header("ACHIEVEMENT")]
    public bool achievementScore;
    public bool achievementShop;
    [FormerlySerializedAs("image1")] public Image imageAchievement1;
    [FormerlySerializedAs("image2")] public Image imageAchievement2;
    
    //LEVEL SYSTEM
    [Header("LEVEL SYSTEM")]
    public int level;
    public int exp;
    public int expToNextLevel;
    public TextMeshProUGUI levelText;
    
    //HIGHEST SCORE
    [Header("HIGHEST SCORE")]
    public int bestScore;
    public TextMeshProUGUI bestScoreText;
    
    //BUTTONS
    [Header("BUTTON CLICKER")]
    public Sprite sp1, sp2, sp3, sp4;
    public GameObject windowsChanger;
    public Image clickerButton;
    public TextMeshProUGUI tx1, tx2, tx3, tx4;
    public int changeCost = 50;
    public int currentButton;
    
    //HIT
    [Header("HIT FLY")]
    public GameObject plusObject;
    public TextMeshProUGUI plusText;

    void Start()
    {
        //RESET LINE//
        //PlayerPrefs.DeleteAll();
        
        //CLICKER
        currentScore = 0;
        hitPower = 1;
        scoreIncreasePerSecond = 1;
        x = 0f;
        
        //SET ALL DEFAULT VARIABLES BEFORE LOAD
        shop1prize = 25;
        shop2prize = 125;
        amount1 = 0;
        amount1Profit = 1;
        amount2 = 0;
        amount2Profit = 5;

        //LOAD
        currentScore = PlayerPrefs.GetInt("currentScore", 0);
        hitPower = PlayerPrefs.GetInt("hitPower", 1);
        x = PlayerPrefs.GetInt("x", 0);
        shop1prize = PlayerPrefs.GetInt("shop1prize", 25);
        shop2prize = PlayerPrefs.GetInt("shop2prize", 125);
        amount1 = PlayerPrefs.GetInt("amount1", 0);
        amount1Profit = PlayerPrefs.GetInt("amount1Profit", 0);
        amount2 = PlayerPrefs.GetInt("amount2", 0);
        amount2Profit = PlayerPrefs.GetInt("amount2Profit", 0);
        upgradePrize = PlayerPrefs.GetInt("upgradePrize", 50);
        
        //NEW
        allUpgradePrize = 500;
        
        //NEW
        bestScore = PlayerPrefs.GetInt("bestScore", 0);

    }

    void Update()
    {
        //CLICKER
        scoreText.text = (int)currentScore + " $";
        scoreIncreasePerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasePerSecond;
        
        //SHOP
        shop1Text.text = "Tier 1: " + shop1prize + " $";
        shop2Text.text = "Tier 2: " + shop2prize + " $";
        
        //AMOUNT
        amount1Text.text = "Tier 1: " + amount1 + " arts $" + amount1Profit + "/s";
        amount2Text.text = "Tier 2: " + amount2 + " arts $" + amount2Profit + "/s";
        
        //UPGRADE
        upgradeText.text = "Cost: " + upgradePrize + " $";
        
        //SAVE
        PlayerPrefs.SetInt("currentScore", (int)currentScore);
        PlayerPrefs.SetInt("hitPower", (int)hitPower);
        PlayerPrefs.SetInt("x", (int)x);
        PlayerPrefs.SetInt("shop1prize", (int)shop1prize);
        PlayerPrefs.SetInt("shop2prize", (int)shop2prize);
        PlayerPrefs.SetInt("amount1", (int)amount1);
        PlayerPrefs.SetInt("amount1Profit", (int)amount1Profit);
        PlayerPrefs.SetInt("amount2", (int)amount2);
        PlayerPrefs.SetInt("amount2Profit", (int)amount2Profit);
        PlayerPrefs.SetInt("upgradePrize", (int)upgradePrize);
        
        //NEW
        allUpradePrizeText.text = "Cost: " + allUpgradePrize + " s";
        
        //NEW
        PlayerPrefs.SetInt("bestScore", bestScore);
        
        //ACHIEVEMENT
        if (currentScore >= 50)
        {
            achievementScore = true;
        }

        if (amount1 >= 2)
        {
            achievementShop = true;
        }

        if (achievementScore == true)
        {
            imageAchievement1.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            imageAchievement1.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }

        if (achievementShop == true)
        {
            imageAchievement2.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            imageAchievement2.color = new Color(0.2f, 0.2f, 0.2f, 0.2f);
        }
        
        //LEVEL
        if (exp >= expToNextLevel)
        {
            level++;
            exp = 0;
            expToNextLevel *= 2;
        }

        levelText.text = level + " Level";
        
        //HIGHEST SCORE
        if (currentScore > bestScore)
        {
            bestScore = (int)currentScore;
        }

        bestScoreText.text = bestScore + " Best Score";
        
        //BUTTON
        tx1.text = "Set for: " + changeCost;
        tx2.text = "Set for: " + changeCost;
        tx3.text = "Set for: " + changeCost;
        tx4.text = "Set for: " + changeCost;

        if (currentButton == 1)
        {
            clickerButton.sprite = sp1;
        }

        if (currentButton == 2)
        {
            clickerButton.sprite = sp2;
        }
        
        if (currentButton == 3)
        {
            clickerButton.sprite = sp3;
        }
        
        if (currentButton == 4)
        {
            clickerButton.sprite = sp4;
        }
        
        //RANDOM EVENT
        
        //HIT
        plusText.text = "+ " + hitPower;
    }

    //HIT
    public void Hit()
    {
        currentScore += hitPower;
        
        //EXP
        exp++;
        
        plusObject.SetActive(false);
        //MOUSE POSITON
        Vector3 mouse_position = Input.mousePosition;
        float mousePosX = mouse_position.x;
        float mousePosY = mouse_position.y;
        plusObject.transform.position = new Vector3(mousePosX + Random.Range(1,10) , mousePosY + Random.Range(1,10), 0);
        plusObject.SetActive(true);
        
        StopAllCoroutines();
        StartCoroutine(Fly());
    }

    #region SHOP

    //SHOP
    public void Shop1()
    {
        if (currentScore >= shop1prize)
        {
            currentScore -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize += 25;
        }
    }
    
    public void Shop2()
    {
        if (currentScore >= shop2prize)
        {
            currentScore -= shop2prize;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2prize += 125;
        }
    }

    #endregion

    #region UPGRADE

    //UPGRADE
    public void Upgrade()
    {
        if (currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }

    #endregion

    #region AllProfitsUpgrade

    public void AllProfitsUpgrade()
    {
        if (currentScore >= allUpgradePrize)
        {
            currentScore -= allUpgradePrize;
            x *= 2;
            allUpgradePrize *= 3;
            amount1Profit *= 2;
            amount2Profit *= 2;
        }
    }

    #endregion

    #region BUTTON

    public void Button1()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost;
            currentButton = 1;
        }
    }
    
    public void Button2()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost;
            currentButton = 2;
        }
    }
    
    public void Button3()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost;
            currentButton = 3;
        }
    }
    
    public void Button4()
    {
        if (currentScore >= changeCost)
        {
            currentScore -= changeCost;
            currentButton = 4;
        }
    }

    #endregion

    #region Window Clicker Changer

    public void WindowsChangerOn()
    {
        windowsChanger.SetActive(true);
    }
    
    public void WindowsChangerOff()
    {
        windowsChanger.SetActive(false);
    }

    #endregion

    #region HIT FLY

    IEnumerator Fly()
    {
        for (int i = 0; i <= 19; i++)
        {
            yield return new WaitForSeconds(0.01f);
            plusObject.transform.position =
                new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + Random.Range(1,3), 0);
        }
        
        plusObject.SetActive(false);
    }

    #endregion
}
