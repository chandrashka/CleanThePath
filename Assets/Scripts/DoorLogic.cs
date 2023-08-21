using System.Collections;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    private const float AnimationTime = 2f;
    private static readonly int IsPlayerNear = Animator.StringToHash("IsPlayerNear");

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponentInParent<PlayerManager>()) return;
        
        doorAnimator.SetTrigger(IsPlayerNear);
        other.GetComponentInParent<Animator>().speed = 0;

        StartCoroutine(nameof(WaitForAnimation));
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(AnimationTime);
        FindObjectOfType<GameManager>().GameWin();
    }
}
