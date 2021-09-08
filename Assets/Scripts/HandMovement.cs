using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    [SerializeField]
    private float minRotation = -160f;
    [SerializeField]
    private float maxRotation = 160f;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Animation animation;

    private Transform thisTransform;
    
    private void Start()
    {
        thisTransform = transform;
        animation = GetComponent<Animation>();
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        
        if (Input.GetButton("Fire2"))
        {
            float dragDistance = Vector3.Distance(curScreenPoint, screenPoint);
            //dragDistance = Mathf.Clamp(dragDistance, minRotation, maxRotation);

            thisTransform.eulerAngles = new Vector3(thisTransform.eulerAngles.x, thisTransform.eulerAngles.y, dragDistance);
        } else if (Input.GetButton("Fire1"))
        {

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }

    }

    public void PlayAnimation()
    {
        animation.Play();
    }
}
