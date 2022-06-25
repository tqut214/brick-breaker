using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetupButton : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<ButtonData>().buttonID = i + 1;
        }
    }
}
