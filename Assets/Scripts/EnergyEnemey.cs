using UnityEngine;

public class EnergyEnemey : Enemy
{
    [SerializeField] private GameObject energyObject;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(enterDamage);
            }

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player != null)
            {
                player.TakeDamage(stayDamege);
            }
        }
    }

    protected override void Die()
    {
        if (energyObject != null)
        {
            GameObject energy = Instantiate(energyObject, transform.position, Quaternion.identity);
            Destroy(energy,5f);
        }
        base.Die();
    }

}
