using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [Space]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private const float TimeToDestroy = 0.3f;
    private static readonly int IsDead = Animator.StringToHash("IsDead");

    public void Kill()
    {
        animator.SetBool(IsDead, true);
        Destroy(gameObject.transform.parent.gameObject, TimeToDestroy);
        audioSource.PlayOneShot(audioClip);
        FindObjectOfType<GameManager>().AddScore();
    }
}
