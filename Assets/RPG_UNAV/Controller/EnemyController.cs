using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 5f;


    Transform target;
    Vector3 originPosition;

    protected Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start ()
    {
        originPosition = gameObject.transform.position;
        target = GameManager.instance.PartySystem.Leader.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        float distanceOrigin = Vector3.Distance(transform.position, originPosition);

        if (distance <= lookRadius)
        {
            if (Vector3.Distance(transform.position, target.position) >= 0.6)
            {
                anim.SetFloat("Move", 1);
                transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                transform.LookAt(target);
            }else if(Vector3.Distance(transform.position, target.position) <= 1){ anim.SetFloat("Move", 0); anim.SetTrigger("Attack"); }
        }
        else
        {
            this.transform.position = originPosition;
            anim.SetFloat("Move", 0);
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
