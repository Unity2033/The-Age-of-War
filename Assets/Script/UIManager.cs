using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject window;

    public void GameStart()
    {
        window.SetActive(false);
        GameManager.instace.state = true;
    }
}
