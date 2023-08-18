using UnityEngine;

public class InfectionLogic : MonoBehaviour
{
    [SerializeField] private Material infectionMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponentInChildren<EnemyLogic>()) return;
        
        var enemyLogicComponent = other.gameObject.GetComponentInChildren<EnemyLogic>();
        other.gameObject.GetComponentInChildren<MeshRenderer>().material = infectionMaterial;
        enemyLogicComponent.Kill();
    }
}
