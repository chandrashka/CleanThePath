using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public void Kill()
    {
        animator.SetBool(IsDead, true);
        Destroy(gameObject.transform.parent.gameObject, 0.3f);       
    }
}
