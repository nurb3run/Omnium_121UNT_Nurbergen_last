using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount = 40;

    void OnTriggerEnter(Collider other)
    {
        PipePlayerController player = other.GetComponent<PipePlayerController>();

        if (player != null)
        {
            player.currentHP += healAmount;

            
            if (player.currentHP > player.maxHP)
                player.currentHP = player.maxHP;

            Debug.Log("HEAL +40 | HP: " + player.currentHP);

            Destroy(gameObject);
        }
    }
}