using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    int count = 0;
    public float speed;
    public float currentHealth;
    private float maxHealth;
    public int attack;

    public LayerMask [] layermask;
    public Slider healthGauge;
    Animator animator;

    private void Start()
    {                         
        animator = GetComponent<Animator>();
        maxHealth = currentHealth;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
                             
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        healthGauge.value = currentHealth / maxHealth;

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);
 
        if (Physics.Raycast(ray, out hit, 2.0f, layermask[0]))
        {
            // 애니메이터 컨트롤러에서 현재 애니메이터의 상태의 이름이“attack1”일 때 
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
            {
                if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime - count >= 1)
                {
                      count++;
                      hit.transform.GetComponent<MonsterControl>().health -= attack;                  
                }
            }

            speed = 0.0f;
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", true);
        }
        else if(Physics.Raycast(ray, out hit, 4.0f, layermask[1]))
        {
            count = 0;
            speed = 0.0f;
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            count = 0;
            speed = 3.0f;
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
        }
    }
}
