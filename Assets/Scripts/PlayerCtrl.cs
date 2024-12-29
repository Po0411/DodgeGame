using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody rigidbody;

    public float speed = 8f;

    Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVec.x = Input.GetAxis("Horizontal");
        moveVec.z = Input.GetAxis("Vertical");
        moveVec.y = 0f;

        rigidbody.velocity = moveVec * speed;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}