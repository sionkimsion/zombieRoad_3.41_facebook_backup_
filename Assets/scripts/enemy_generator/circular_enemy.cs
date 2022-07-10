using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circular_enemy : MonoBehaviour
{
    public int numPoints = 20;                           // ÇÁ¸®ÆÕ °¹¼ö
    public Vector3 centerPos = new Vector3(0, 0, 32);    // center of circle/elipsoid

    public GameObject pointPrefab;                    // generic prefab to place on each point
    public float radiusX, radiusY;                    // radi for each x,y axes, respectively

    public bool isCircular = false;                   // is the drawn shape a complete circle?
    public bool vertical = true;                     // is the drawn shape on the xy-plane?

    Vector3 pointPos;                                //position to place each prefab along the given circle/eliptoid
                                                     //*is set during each iteration of the loop

    Vector3 parentPos;
    
    void Start()
    {
        for (int i = 0; i < numPoints; i++) {
            //multiply 'i' by '1.0f' to ensure the result is a fraction
            float pointNum = (i * 1.0f) / numPoints;

            //angle along the unit circle for placing points
            float angle = pointNum * Mathf.PI * 2;

            float x = Mathf.Sin(angle) * radiusX;
            float y = Mathf.Cos(angle) * radiusY;

            //position for the point prefab
            if (vertical)
                pointPos = new Vector3(x, y) + centerPos;
            else if (!vertical) {
                pointPos = new Vector3(x, 0, y) + centerPos;
            }

            parentPos = new Vector3(transform.position.x, transform.position.y, -35);

            //place the prefab at given position
            Instantiate(pointPrefab, parentPos + pointPos, Quaternion.identity);
        }

        //keeps radius on both axes the same if circular
        if (isCircular) {
            radiusY = radiusX;
        }
    }

}
