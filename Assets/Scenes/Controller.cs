using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private GameObject _snake = default;
    [SerializeField] private int _snakeStartLength = 3;

    private enum Direction { Change, Vertical, Horizontal };
    private int _snakeLength;
    private Vector2 _snakeDirection = new Vector2(1, 0);
    private Vector2 _snakePosition = new Vector2(20, 30);
    private Direction _snakeMove;
    private bool _keyLock = false;
    private GameObject[] _snakeBody = default;

    // Start is called before the first frame update
    void Start()
    {
        _snakeLength = _snakeStartLength;
        _snakeMove = Direction.Vertical;

        CreateSnake();
        InvokeRepeating("MoveSnake", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_snakeMove == Direction.Vertical && !_keyLock)
        {
            if (Input.GetKeyDown("up"))
            {
                _snakeDirection = new Vector2(0, 1);
                _snakeMove = Direction.Horizontal;
                _keyLock = true;
            }
            else if (Input.GetKeyDown("down"))
            {
                _snakeDirection = new Vector2(0, -1);
                _snakeMove = Direction.Horizontal;
                _keyLock = true;
            }
        }
        else if (_snakeMove == Direction.Horizontal && !_keyLock)
        {
            if (Input.GetKeyDown("left"))
            {
                _snakeDirection = new Vector2(-1, 0);
                _snakeMove = Direction.Vertical;
                _keyLock = true;
            }
            else if (Input.GetKeyDown("right"))
            {
                _snakeDirection = new Vector2(1, 0);
                _snakeMove = Direction.Vertical;
                _keyLock = true;
            }
        }
    }

    private void MoveSnake()
    {
        SwapBody();
        Vector2 __oldHead = _snakeBody[1].transform.localPosition;
        _snakeBody[0].transform.localPosition = new Vector2(__oldHead.x + _snakeDirection.x, __oldHead.y + _snakeDirection.y);

        _keyLock = false;


    }

    private void CreateSnake()
    {
        _snakeBody = new GameObject[_snakeLength];
        for (int __i = 0; __i < _snakeBody.Length; __i++)
        {
            GameObject __snake = Instantiate(_snake) as GameObject;
            __snake.transform.localPosition = new Vector2(_snakePosition.x - __i, _snakePosition.y);
            _snakeBody[__i] = __snake;
        }
    }

    private void SwapBody()
    {
        GameObject[] __snakeBodyAux = new GameObject[_snakeLength];
        __snakeBodyAux[0] = _snakeBody[_snakeBody.Length - 1];
        for (int __i = 1; __i < _snakeBody.Length; __i++)
        {
            __snakeBodyAux[__i] = _snakeBody[__i - 1];
        }
        _snakeBody = __snakeBodyAux;
    }

}
