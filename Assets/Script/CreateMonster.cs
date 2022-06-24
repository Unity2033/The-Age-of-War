using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMonster : MonoBehaviour
{
    private void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }

    public void Create()
    {
        Instantiate
        (
            Resources.Load<GameObject>("Warrior Goblin"),
            new Vector3(-20,0,30),
            Quaternion.Euler(0,90,0)
        );     
    }

    public void EnemyInstance()
    {
        int rand = Random.Range(0, 3);

        if (rand == 1)
        {
            Instantiate
            (
               Resources.Load<GameObject>("Enemy Warrior Goblin"),
               new Vector3(20, 0, 30),
               Quaternion.Euler(0, -90, 0)
            );
        }
    }
   
}
