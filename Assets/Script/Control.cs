using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    int damage = 10;
    float speed = 1.0f;

    Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // �ִϸ����� ��Ʈ�ѷ����� ���� �ִϸ������� ������ �̸��̡�attack1���� �� 
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack1"))
        {
            // ���� �ִϸ��̼��� ���൵�� 1���� ũ�ų� ���ٸ� damage ������ ����մϴ�.
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                animator.Rebind();
            }
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            speed = 0.0f;
            animator.SetBool("Attack", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            speed = 1.0f;
            animator.SetBool("Attack", false);
        }
    }

}
