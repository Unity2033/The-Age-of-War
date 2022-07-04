using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour
{
    public Button [] createButton;

    private void Start()
    {
        InvokeRepeating("EnemyInstance", 0, 5);
    }

    public void Create(string name)
    {     
        switch(name)
        {
            case "Goblin":
                Instantiate
                    (
                       Resources.Load<GameObject>("Warrior Goblin"),
                       new Vector3(-20, 0, 30),
                       Quaternion.Euler(0, 90, 0)
                    );

                StartCoroutine(Wait(3.0f, createButton[0]));
                break;
            case "Troll":
                Instantiate
                    (
                       Resources.Load<GameObject>("Troll"),
                       new Vector3(-20, 0, 30),
                       Quaternion.Euler(0, 90, 0)
                    );

                StartCoroutine(Wait(5.0f, createButton[1]));
                break;
            case "Wizard":
                Instantiate
                    (
                       Resources.Load<GameObject>("Wizard"),
                       new Vector3(-20, 0, 30),
                       Quaternion.Euler(0, 90, 0)
                    );

                StartCoroutine(Wait(10.0f, createButton[2]));
                break;
        }
    }

    public void EnemyInstance()
    {
        if (!GameManager.instace.state) return;

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

    IEnumerator Wait(float timer, Button button)
    {
        // 버튼 비활성화
        button.interactable = false;

        while(timer > 1.0f)
        {
            timer -= Time.deltaTime;
            button.image.fillAmount = (1.0f / timer);
            yield return new WaitForFixedUpdate();
        }

        button.interactable = true;
    }
   
}
