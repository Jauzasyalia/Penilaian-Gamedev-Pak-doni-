using UnityEngine;

// INHERITANCE + POLYMORPHISM
// BucketHeadZombie mewarisi Enemy, lalu meng-override Serang().
public class BucketHeadZombie : Enemy
{
    public bool bucket = true;

    public override void Serang()
    {
        Debug.Log("Buckethead Gigit");

        if (player != null)
        {
            IDamageable target = player.GetComponent<IDamageable>();
            if (target != null) target.KenaDamage(10f);
        }
    }
}
