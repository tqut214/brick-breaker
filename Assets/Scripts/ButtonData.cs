
using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ButtonData : MonoBehaviour
{
    private LevelData _levelData;
    public TextMeshProUGUI text;
    public GameObject block;
    public GameObject Stars;
    public int buttonID;
    public bool isBlock;
    public int stars;
    void Start()
    {
        _levelData = FindObjectOfType<LevelData>();
        stars = PlayerPrefs.GetInt("Lv" + buttonID);
        text.text = buttonID.ToString();
        Stars.transform.GetChild(0).gameObject.SetActive(false);
        Stars.transform.GetChild(1).gameObject.SetActive(false);
        Stars.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        SetupButton();
        UpdateLevelStatus();
    }

    void SetupButton()
    {
        if (stars > 0)
        {
            Stars.SetActive(true);
            SetStar();
        }
        else
        {
            Stars.SetActive(false);

        }
        block.SetActive(isBlock);
    }

    private void UpdateLevelStatus()
    {
        int previousLevel = buttonID -1;
        if (PlayerPrefs.GetInt("Lv" +previousLevel) > 0)
        {
            isBlock = false;
        }
    }
    void SetStar()
    {
        switch (stars)
        {
            case 3:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                Stars.transform.GetChild(1).gameObject.SetActive(true);
                Stars.transform.GetChild(2).gameObject.SetActive(true);
                break;
            case 2:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                Stars.transform.GetChild(1).gameObject.SetActive(true);
                break;
            case 1:
                Stars.transform.GetChild(0).gameObject.SetActive(true);
                break;
            default:
                break;
                
        }
    }

    public void PressSelection()
    {
        if (!isBlock)
        {
            _levelData.level = buttonID;
            SceneManager.LoadScene("GamePlayScene",LoadSceneMode.Single);
        }
    }

}
