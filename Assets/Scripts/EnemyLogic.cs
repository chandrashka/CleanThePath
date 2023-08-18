using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public void Kill()
    {
        Destroy(gameObject, 0.5f);       
    }
}
