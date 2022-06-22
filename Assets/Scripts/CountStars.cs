using UnityEngine;
using TMPro;
public class CountStars : MonoBehaviour
{
    public TextMeshProUGUI txtStars;
    private int _stars;
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            Debug.Log(PlayerPrefs.GetInt("Lv" + 2));
            _stars += PlayerPrefs.GetInt("Lv" + (i+1));
        }

        txtStars.text = _stars.ToString();
    }
    
}
