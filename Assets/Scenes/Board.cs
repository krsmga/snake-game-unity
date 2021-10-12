using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField] private int _rowLength = default;
    [SerializeField] private int _columnLength = default;
    [SerializeField] private GameObject _squareBoard = default;
    [SerializeField] private Color32 _firstColor = Color.white;
    [SerializeField] private Color32 _secondColor = Color.white;
    [SerializeField] private Camera _camera = default;

    // Start is called before the first frame update
    void Start()
    {
        GameObject __board = gameObject;
        Vector3 __boundSize = _squareBoard.GetComponent<SpriteRenderer>().bounds.size;

        for (int i = 0; i < _rowLength; i++)
        {
            for (int j = 0; j < _columnLength; j++)
            {
                GameObject __square = Instantiate(_squareBoard, __board.transform) as GameObject;
                __square.name = i.ToString().PadLeft(2, '0') + j.ToString().PadLeft(2, '0');
                __square.transform.position = new Vector2(j, i);

                SpriteRenderer __sprite = __square.GetComponent<SpriteRenderer>();
                if ((i + j) % 2 != 0)
                {
                    __sprite.color = _firstColor;
                }
                else
                {
                    __sprite.color = _secondColor;
                }
            }
        }

        float __camPositionX = (((float)_columnLength - 1) / 2);
        float __camPositionY = (((float)_rowLength - 1) / 2);

        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = (__boundSize.x * _columnLength) / (__boundSize.y * _rowLength);

        Camera.main.transform.position = new Vector3(__camPositionX, __camPositionY, -1);

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = (__boundSize.y * _rowLength) / 2;
        }
        else
        {
            float difference = targetRatio / screenRatio;
            Camera.main.orthographicSize = ((__boundSize.y * _rowLength) / 2) * difference;
        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}
