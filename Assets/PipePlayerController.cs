using UnityEngine;

public class PipePlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float strafeSpeed = 120f;
    public float radius = 2f;

    public Transform pipeCenter;

    private float angle = 0f;
    private float forwardOffset = 0f;

    
    public int maxHP = 100;
    public int currentHP;

    
    public GameObject bulletPrefab;
    public Transform shootPoint;

    void Start()
    {
        currentHP = maxHP;
    }

    void Update()
    {
        if (pipeCenter == null) return;

        // хуячит по трубе (работает только вперед)
        if (Input.GetKey(KeyCode.W))
        {
            forwardOffset += moveSpeed * Time.deltaTime;
        }

        
        float horizontal = Input.GetAxis("Horizontal");
        angle += horizontal * strafeSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(
            Mathf.Cos(angle * Mathf.Deg2Rad),
            Mathf.Sin(angle * Mathf.Deg2Rad),
            0
        ) * radius;

        transform.position = pipeCenter.position + offset + Vector3.forward * forwardOffset;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, offset.normalized);

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public float GetForwardOffset()
    {
        return forwardOffset + (pipeCenter != null ? pipeCenter.position.z : 0f);
    }

    
    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;
        Debug.Log("HP: " + currentHP);

        if (currentHP <= 0)
        {
            Debug.Log("YOU DIED");
        }
    }

    // стрельба правильная 
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // онли направление игрока В МИРЕ!
        Vector3 dir = shootPoint.forward;

        rb.velocity = dir.normalized * 30f;
    }
}