using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rigidbody;

    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerCtrl player = other.GetComponent<PlayerCtrl>();

            if (player != null)
                player.Die();
        }
        else if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
