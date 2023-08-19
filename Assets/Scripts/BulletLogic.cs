using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private float force = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<EnemyLogic>() || other.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Destroy(bulletObject);
        }
    }

    public void Shoot(Transform doorTransform)
    {
        rigidbody.isKinematic = false;
        
        Transform bulletTransform;
        
        (bulletTransform = transform).parent.transform.LookAt(doorTransform);
        rigidbody.AddForce(bulletTransform.forward * force, ForceMode.Impulse);
    }
}
