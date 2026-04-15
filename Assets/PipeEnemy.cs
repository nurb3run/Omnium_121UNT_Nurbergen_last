using UnityEngine;

public class PipeEnemy : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 100f;
    public float radius = 2f;

    public int hp = 10;

    private float angle;
    private float zPos;

    void Start()
    {
        Vector3 pos = transform.position;

        angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        zPos = pos.z;
    }

    void Update()
    {
        zPos -= moveSpeed * Time.deltaTime;
        angle += rotateSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0f
        ) * radius;

        transform.position = offset + new Vector3(0f, 0f, zPos);
        transform.rotation = Quaternion.LookRotation(Vector3.back, offset.normalized);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;

        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    void OnTriggerEnter(Collider other)
    {
        PipePlayerController player = other.GetComponent<PipePlayerController>();

        if (player != null)
        {
            player.TakeDamage(20);
            Destroy(gameObject); 
        }
    }

}
