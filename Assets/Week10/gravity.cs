using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour
{
    [SerializeField] private float forceIntesity;
    [SerializeField] private float maxGravityRadius;
    [SerializeField] private float minGravityRadius;
    [SerializeField] private LayerMask ballLayer;
    [SerializeField] private Rigidbody2D playerRB;

    /// <summary>
    /// redo this different approach
    /// </summary>
    private void Update()
    {
        Collider2D ball = Physics2D.OverlapCircle(transform.position, minGravityRadius, ballLayer);
        playerRB = ball.GetComponent<Rigidbody2D>();

        var direction = (transform.position - playerRB.transform.position);
        var revDirection = (playerRB.transform.position - transform.position);

        var dis = Vector2.Distance(ball.transform.position , transform.position);

        if(dis > maxGravityRadius)
        {
            playerRB.AddForce(direction * (forceIntesity * ((Vector2.Distance(transform.position + (revDirection * maxGravityRadius),playerRB.transform.position))/minGravityRadius)));
        }
        else
        {
            playerRB.AddForce(direction * (forceIntesity));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxGravityRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minGravityRadius);
    }
}
