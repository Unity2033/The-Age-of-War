using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateMonster : MonoBehaviour
{
    public Button goblinButton;

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

        StartCoroutine(Wait(3.0f));
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

    IEnumerator Wait(float timer)
    {
        // 버튼 비활성화
        goblinButton.interactable = false;

        while(timer > 1.0f)
        {
            timer -= Time.deltaTime;
            goblinButton.image.fillAmount = (1.0f / timer);
            yield return new WaitForFixedUpdate();
        }

        goblinButton.interactable =  true;
    }
   
}
