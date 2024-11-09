using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;

public class gravity : MonoBehaviour
{
    [SerializeField] private float forceIntesity;
    [SerializeField] private float maxGravityRadius;
    [SerializeField] private float minGravityRadius;
    [SerializeField] private LayerMask ballLayer;
    //[SerializeField] private Rigidbody2D playerRB;
    /// <summary>
    /// redo this different approach
    /// </summary>
    private void Start()
    {
       //var ball = Physics2D.OverlapCircleAll(transform.position, minGravityRadius, ballLayer);
    }

    private void Update()
    {
        var ballRB = Physics2D.OverlapCircleAll(transform.position, minGravityRadius, ballLayer);

        foreach (var balls in ballRB)
        {
            //balls.gameObject.GetComponent<Rigidbody2D>();

            var getrb = balls.gameObject.GetComponent<Rigidbody2D>();

            var eachBallDistance = Vector2.Distance(balls.transform.position, transform.position);

            var direction = (transform.position - getrb.transform.position);
            var revDirection = (getrb.transform.position - transform.position);

            if (eachBallDistance > maxGravityRadius)
            {
                getrb.AddForce(direction * (forceIntesity * ((Vector2.Distance(transform.position + (revDirection * maxGravityRadius), getrb.transform.position)) / minGravityRadius)));
            }
            else
            {
                getrb.AddForce(direction * (forceIntesity));
            }
        }


        //var dis = Vector2.Distance(ball[0].transform.position , transform.position);

        //if(dis > maxGravityRadius)
        //{
        //    playerRB.AddForce(direction * (forceIntesity * ((Vector2.Distance(transform.position + (revDirection * maxGravityRadius),playerRB.transform.position))/minGravityRadius)));
        //}
        //else
        //{
        //    playerRB.AddForce(direction * (forceIntesity));
        //}
    }

    //void randomForceIntensity(float sdsd)
    //{
    //    var sdsd = Random.Range(5, forceIntesity);

    //    return sdsd;
    //}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, maxGravityRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minGravityRadius);
    }
}
