using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public float speed;
    public int health = 100;

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
                health -= 10;
                animator.Rebind();
            }
        }

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        RaycastHit hit;

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 2.0f))
        {
            speed = 0.0f;
            animator.SetBool("Attack", true);
        }
        else
        {
            speed = 3.0f;
            animator.SetBool("Attack", false);
        }
    }
}
