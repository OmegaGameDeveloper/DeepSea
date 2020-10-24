using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public LayerMask IgnoreMe;
    public float speed,Reach;
    public bool nabrakkiri,nabrakkanan,nabrakatas,nabrakbawah;
    public AutoPilot autoPilot;
    public GameObject goAutopilot;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        //autoPilot = goAutopilot.GetComponent<AutoPilot>();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime * Time.timeScale;

        if (nabrakbawah)
        {
            gameObject.transform.Translate(new Vector3(0, 1 * speed * Time.deltaTime * Time.timeScale, 0));
        }
        if (nabrakatas)
        {
            gameObject.transform.Translate(new Vector3(0, -1 * speed * Time.deltaTime * Time.timeScale, 0));
        }
        
        if (nabrakkanan)
        {
            gameObject.transform.Translate(new Vector3(1 * speed * Time.deltaTime * Time.timeScale, 0, 0));
        }
        
        if (nabrakkiri)
        {
            gameObject.transform.Translate(new Vector3(-1 * speed * Time.deltaTime * Time.timeScale, 0, 0));
        }

        gameObject.transform.Translate(new Vector3(0, 0, 1 * speed * Time.deltaTime * Time.timeScale));
        //transform.position = Vector3.MoveTowards(transform.position,wp.transform.position,step);
    }

    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 left = transform.TransformDirection(Vector3.left);
        Vector3 up = transform.TransformDirection(Vector3.up);
        Vector3 down = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, fwd, 0.5f, IgnoreMe))
        {
            autoPilot.musuhlewat = true;
        }
        else {
            autoPilot.musuhlewat = true;
        }

        if (Physics.Raycast(transform.position, fwd, out hit, 10, ~IgnoreMe) && Physics.Raycast(transform.position, right, out hit, 2, ~IgnoreMe))
        {
            if (hit.collider.tag == "Ground")
            {
                nabrakkanan = true;
            }
           
        }
        else
        {
            nabrakkanan = false;
        }
        if (Physics.Raycast(transform.position, fwd, out hit, 10, ~IgnoreMe) && Physics.Raycast(transform.position, left, out hit, 2, ~IgnoreMe))
        {
            if (hit.collider.tag == "Ground")
            {
                nabrakkiri = true;
            }
        }
        else
        {
            nabrakkiri = false;
        }
        if (Physics.Raycast(transform.position, fwd, out hit, 10, ~IgnoreMe) && Physics.Raycast(transform.position, up, out hit, 2, ~IgnoreMe))
        {
            if (hit.collider.tag == "Ground")
            {
                nabrakatas = true;
            }
        }
        else
        {
            nabrakatas = false;
        }
        if (Physics.Raycast(transform.position, fwd, out hit, 10, ~IgnoreMe) && Physics.Raycast(transform.position, down, out hit, 2, ~IgnoreMe))
        {
            if (hit.collider.tag == "Ground")
            {
                nabrakbawah = true;
            }
        }
        else
        {
            nabrakbawah = false;
        }

    }

}
