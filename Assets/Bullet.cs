using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 30f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, 3f);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("BULLET HIT: " + other.name);

        
        if (other.name.Contains("Enemy"))
        {
            Debug.Log("DESTROY ENEMY");
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}