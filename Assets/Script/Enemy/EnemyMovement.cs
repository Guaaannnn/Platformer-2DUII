
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [Header("General")]
    [SerializeField] Transform EnemyObject;
    [SerializeField] float fSpeed = 5f;
    [SerializeField] float fDistanceUpdate = 5f;
    [SerializeField] SpriteRenderer tEnemyRenderer;
    [SerializeField] Transform[] Points;

    private int iPointIndex;

    private void Start()
    {
        iPointIndex = 0;
        tEnemyRenderer.flipX = iPointIndex == 0;
    }

    void Update()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        float step = fSpeed * Time.deltaTime;
        Vector2 targetPosition = Points[iPointIndex].position;
        EnemyObject.position = Vector2.MoveTowards(EnemyObject.position, targetPosition, step);
        float distance = Vector2.Distance(EnemyObject.position, targetPosition);

        if (distance < fDistanceUpdate)
        {
            Debug.Log("Sudah Sampai");
            iPointIndex = iPointIndex == 0 ? 1 : 0;
            tEnemyRenderer.flipX = iPointIndex == 0;
        }
    }
}