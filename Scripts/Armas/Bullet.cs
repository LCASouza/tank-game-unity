using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private ParticleSystem estilhaco;
    public int speed = 100;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * (speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            Instantiate(estilhaco, transform.position, transform.rotation);
        }
    }
}
