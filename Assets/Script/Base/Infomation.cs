using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Infomation : MonoBehaviour
{
    public int price;
    public Text moneyUI;
    public Image priceUI;

    public void Start()
    {
        moneyUI.text = price.ToString();
    }
}
