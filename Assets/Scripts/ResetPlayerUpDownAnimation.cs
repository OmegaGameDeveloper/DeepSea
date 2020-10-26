using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerUpDownAnimation : MonoBehaviour
{

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Turun()
    {
        animator.SetBool("Turun", false);
    }

    public void Naik()
    {
        animator.SetBool("Naik", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
