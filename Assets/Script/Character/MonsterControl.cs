using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterControl : MonoBehaviour
{
    public float speed;
    public float health;
    public int attack;

    public LayerMask [] layermask;
    public Slider healthGauge;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (health <= 0)
        {
            DataManager.instance.MoneyIncrease(100);
            Destroy(gameObject);
        }

        healthGauge.value = health / 100;

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 2.0f, layermask[0]))
        {
            // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“attack1”일 때 
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                // 현재 애니메이션의 진행도가 1보다 크거나 같다면 damage 변수를 출력합니다.
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
                {
                    animator.Rebind();
                    hit.transform.GetComponent<Control>().currentHealth -= attack;
                }
            }

            speed = 0.0f;
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", true);
        }
        else if (Physics.Raycast(ray, out hit, 4.0f, layermask[1]))
        {
            speed = 0.0f;
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            speed = 3.0f;
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
        }
    }
}
