using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
[ SerializeField]private float bulletLifeTIME = 1f;

 // Destroy bullet efter X time has passed

    private void Awake()
    {
        Destroy ( gameObject, bulletLifeTIME );

    }
  
}
