using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float parallaxSpeed; // layer's image's scrolling speed

    private float backgroundSize; // size of layer's image by x
    private Transform cameraTransform;
    private Transform[] images; // all layer's images
    private int leftIndex; // left image's index
    private int rightIndex; // right image's index
    private float lastCameraX; // last camera's position in x axis

    private readonly float viewZone = 10; // camera's view zone

    private void Start ()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;
        images = new Transform[transform.childCount];
        // adding all image's to array
        for (int i = 0; i < transform.childCount; i++) {
            images[i] = transform.GetChild(i);
        }
        // getting background image's size by x
        backgroundSize = images[0].GetComponent<SpriteRenderer>().bounds.size.x;
        leftIndex = 0;
        rightIndex = images.Length - 1;
	}
	
	// Update is called once per frame
	private void Update ()
    {
        float deltaX = cameraTransform.position.x - lastCameraX; // getting camera's movement's delta
        transform.position += Vector3.right * (deltaX * parallaxSpeed); // setting image's position
        lastCameraX = cameraTransform.position.x;
        // checking if image's scrolling to the left side is needed
        if (cameraTransform.position.x < (images[leftIndex].transform.position.x + viewZone)){
            ScrollLeft();
        }
        // checking if image's scrolling to the right side is needed
        else if (cameraTransform.position.x > (images[rightIndex].transform.position.x - viewZone)) {
            ScrollRight();
        }
	}

    private void ScrollLeft()
    {
        images[rightIndex].position = new Vector2((images[leftIndex].position.x - backgroundSize), images[rightIndex].position.y); // setting image's position to left
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex < 0) {
            rightIndex = images.Length - 1;
        }
    }

    private void ScrollRight()
    {
        images[leftIndex].position = new Vector2((images[rightIndex].position.x + backgroundSize), images[leftIndex].position.y); // setting image's position to right
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == images.Length) {
            leftIndex = 0;
        }
    }
}
