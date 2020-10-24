using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{

    public Animator animator,animator2;
    public bool atas, bawah, tengah;
    public int stateboss;
    public void Atas()
    {
        animator2.SetBool("Move", true);
    }
    public void Bawah()
    {
        animator2.SetBool("Move", true);
    }
    public void Tengah()
    {
        animator2.SetBool("Move", true);
    }

    public void Putar()
    {
        //Random.InitState(System.DateTime.Now.Millisecond);
        stateboss = Random.Range(0, 3);
    }

    public void Kembali()
    {
        animator.SetBool("Atas", false);
        animator.SetBool("Tengah", false);
        animator.SetBool("Bawah", false);
        animator2.SetBool("Move", false);
        gameObject.tag = "Boss";
    }

    public void Update()
    {
        if (stateboss == 0 && animator.GetCurrentAnimatorStateInfo(0).IsName("Standy Phase") && animator.GetBool("Tengah")!=true && animator.GetBool("Bawah") != true)
        {
            animator.SetBool("Atas", true);
        }
        if (stateboss == 1 && animator.GetCurrentAnimatorStateInfo(0).IsName("Standy Phase") && animator.GetBool("Atas") != true && animator.GetBool("Bawah") != true)
        {
            animator.SetBool("Tengah", true);
        }
        if (stateboss == 2 && animator.GetCurrentAnimatorStateInfo(0).IsName("Standy Phase") && animator.GetBool("Tengah") != true && animator.GetBool("Atas") != true)
        {
            animator.SetBool("Bawah", true);
        }
    }

}
