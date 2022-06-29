using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instace;
    public bool state;

    void Start()
    {
        instace = this; 
    }

}
