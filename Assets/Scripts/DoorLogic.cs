using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    private static readonly int IsPlayerNear = Animator.StringToHash("IsPlayerNear");

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<PlayerManager>())
        {
            doorAnimator.SetTrigger(IsPlayerNear);
        }
    }
}
