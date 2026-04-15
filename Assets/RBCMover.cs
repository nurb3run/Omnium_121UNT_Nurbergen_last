using UnityEngine;

public class RBCMover : MonoBehaviour
{
    public float moveSpeed = 18f;   // МЕДЛЕННЕЕ крутка
    public float rotateSpeed = 300f; // БЫСТРЕЕ  
    public float lifeTime = 5f;
    public float radius = 2f; 

    private float zPos;
    private float angle;

    private float timer;
    private Vector3 randomAxis;

    void Start()
    {
        Vector3 pos = transform.position;

        // фигарит по кругу рабочий код
        angle = Mathf.Atan2(pos.y, pos.x);
        zPos = pos.z;

        randomAxis = Random.onUnitSphere;
    }

    void Update()
    {
        
        zPos += moveSpeed * Time.deltaTime;

        Vector3 offset = new Vector3(
            Mathf.Cos(angle),
            Mathf.Sin(angle),
            0f
        ) * radius;

        transform.position = offset + new Vector3(0f, 0f, zPos);

        
        transform.Rotate(randomAxis * rotateSpeed * Time.deltaTime);

        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            Destroy(gameObject);
        }
        float wobble = Mathf.Sin(Time.time * 3f + angle) * 0.1f;
        offset *= (1f + wobble);
    }
}