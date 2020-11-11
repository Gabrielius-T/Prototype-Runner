using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Transform[] images;
    [SerializeField] Transform objectToFollow;
    [SerializeField] float viewZone;

    float backgroundSize;

    int leftIndex;
    int rightIndex;

    void Start ()
    {
        backgroundSize = images[0].GetComponent<SpriteRenderer>().bounds.size.x;
        leftIndex = 0;
        rightIndex = images.Length - 1;
	}
    
	void LateUpdate ()
    {
        transform.position += Time.deltaTime * movementSpeed * Vector3.right;

        if (objectToFollow.position.x < images[leftIndex].transform.position.x + viewZone)
        {
            ScrollLeft();
        }
        else if (objectToFollow.position.x > images[rightIndex].transform.position.x - viewZone) 
        {
            ScrollRight();
        }
	}

    void ScrollLeft()
    {
        images[rightIndex].position = new Vector2((images[leftIndex].position.x - backgroundSize), images[rightIndex].position.y);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0) 
        {
            rightIndex = images.Length - 1;
        }
    }

    void ScrollRight()
    {
        images[leftIndex].position = new Vector2((images[rightIndex].position.x + backgroundSize), images[leftIndex].position.y);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == images.Length) 
        {
            leftIndex = 0;
        }
    }
}
