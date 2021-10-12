using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class replicate : MonoBehaviour
{
    [SerializeField] private GameObject prefab = default;
    [SerializeField] private GameObject prefabSnake = default;
    [SerializeField] private GameObject parent = default;
    [SerializeField] private int numCols = 1;
    [SerializeField] private int numRows = 1;

    enum Direction {top, down, left, right};
    private Direction directionSnake = Direction.left;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;
        for (int i = 0; i < numRows; i++)
        {
            position.y = i;
            for (int j = 0; j < numCols; j++) 
            {
                GameObject newObject = Instantiate(prefab) as GameObject;
                newObject.transform.SetParent(parent.transform, false);
                position.x = j;
                newObject.transform.position = position;
            }           

        }
        InvokeRepeating("MoveSnake",0f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            directionSnake = Direction.top;
        }
        else if (Input.GetKeyDown("down"))
        {
            directionSnake = Direction.down;
        }
        else if (Input.GetKeyDown("left"))
        {
            directionSnake = Direction.left;
        }
        else if (Input.GetKeyDown("right"))
        {
            directionSnake = Direction.right;
        }
    }

    private void MoveSnake() 
    {        
        Vector3 position = prefabSnake.transform.position;
        
        if (directionSnake == Direction.left)
        {
            position.x--;
        }
        else if (directionSnake == Direction.right)
        {
            position.x++;
        }
        else if (directionSnake == Direction.top)
        {
            position.y++;
        }
        else if (directionSnake == Direction.down)
        {
            position.y--;
        }
        prefabSnake.transform.position = position;
    }
}
