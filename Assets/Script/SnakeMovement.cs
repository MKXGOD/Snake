using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> tails;
    [SerializeField] private float bonesDistance;
    [SerializeField] private GameObject bonePrefab;
    [Range(1, 10), SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed = 100;

    private void Update()
    {
        MoveHead(moveSpeed);
        MoveTail();
        Rotate(rotateSpeed);
    }

    private void MoveHead(float speed)
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
    }
    private void MoveTail()
    {
        float sqrDistance = Mathf.Sqrt(bonesDistance);
        Vector3 previousPosition = transform.position;

        foreach (var bone in tails)
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 currentBonePosition = bone.position;
                bone.position = previousPosition;
                previousPosition = currentBonePosition;
            }
            else
                break;
    }
    private void Rotate(float speed)
    {
        float angle = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, angle, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Food")
        {
            Destroy(other.gameObject);
            GameObject bone = Instantiate(bonePrefab, transform.position, transform.rotation);
            tails.Add(bone.transform);
       }
    }
}
