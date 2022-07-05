using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Data
{
    public int price;
    public Sprite shape;
    public Sprite weapon;
}

public class Infomation : MonoBehaviour
{
    public static Infomation instance;

    public Data [] data;

    public Image [] monsterUI;
    public Image [] weaponUI;
    public Text[] priceText;

    private void Start()
    {
        instance = this;

        for (int i = 0; i < data.Length; i++)
        {
            monsterUI[i].sprite = data[i].shape;
            weaponUI[i].sprite = data[i].weapon;
            priceText[i].text = data[i].price.ToString();
        }
    }
}
