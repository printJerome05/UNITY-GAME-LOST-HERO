

using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if(transform.position != target.position)   
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(target.position.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(target.position.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }

    }
    public void BeginKick()
    {
        anim.SetBool("kick_active", true);
        StartCoroutine(KickCo());
    }
    public IEnumerator KickCo()
    {
        yield return null;
        anim.SetBool("kick_active", false);
    }
}


