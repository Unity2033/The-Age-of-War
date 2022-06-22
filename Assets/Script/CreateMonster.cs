using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    public void Create()
    {
        Instantiate
        (
            Resources.Load<GameObject>("Warrior Goblin"),
            new Vector3(-20,0,30),
            Quaternion.Euler(0,90,0)
        );
        
    }
   
}
