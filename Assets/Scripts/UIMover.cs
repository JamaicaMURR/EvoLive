using UnityEngine;
using System.Collections;

public class UIMover : MonoBehaviour, IActable
{
    public Transform firstPlace;
    public Transform secPlace;

    public float speed = 0.1f;

    private Vector3 pos1;
    private Vector3 pos2;

    private Vector3 target;

    public bool isToSecP = true;

    [HideInInspector]
    public bool isInProcess = false;

    void Start()
    {
        if(firstPlace == null)
            firstPlace = GetComponent<Transform>();

        pos1 = new Vector3(firstPlace.position.x, firstPlace.position.y, firstPlace.position.z);
        pos2 = new Vector3(secPlace.position.x, secPlace.position.y, secPlace.position.z);
    }

    public void Act()
    {
        //if(!isInProcess)
        //{
        if(isToSecP)
            target = pos2;
        else
            target = pos1;

        isInProcess = true;
        //}
    }

    void Update()
    {
        if(isInProcess)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if(transform.position == target)
            {
                isInProcess = false;
                isToSecP = !isToSecP;
            }
        }
    }
}
