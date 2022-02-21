using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private LayerMask _whatStopMovement;
    [SerializeField] private GameObject _bomb;

    private Animator _anim;
    private float _inputHorizontal;
    private float _inputVertical;
    private bool _buttonBomb;
    private int _bombsAllowed;

    // Animation and states
    private Animator _animator;
    private string _currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    void Start()
    {
        _movePoint.parent = null;
        _animator = gameObject.GetComponent<Animator>();
        _bombsAllowed = 1;
    }

    void Update()
    {
        _buttonBomb = Input.GetKeyDown(KeyCode.Z);
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        _inputVertical = Input.GetAxisRaw("Vertical");  

        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _movePoint.position) <= .5f)
        {
             
            if(Mathf.Abs(_inputHorizontal) == 1f)
            {
                if(!Physics2D.OverlapCircle(_movePoint.position + new Vector3(_inputHorizontal, 0f, 0f), .4f, _whatStopMovement))
                {
                    _movePoint.position += new Vector3(_inputHorizontal, 0f, 0f);
                }
            } 
            if(Mathf.Abs(_inputVertical) == 1f)
            {
                if(!Physics2D.OverlapCircle(_movePoint.position + new Vector3(0f, _inputVertical, 0f), .4f, _whatStopMovement))
                {
                    _movePoint.position += new Vector3(0f, _inputVertical, 0f);
                }
            }
        } 
        else
        {
            if (_inputHorizontal > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            else if (_inputHorizontal < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }        
             else if (_inputVertical > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }   
             else if (_inputVertical < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }   
        }
        if(_buttonBomb && GameObject.FindGameObjectsWithTag("Bomb").Length < _bombsAllowed)
        {
            Instantiate(_bomb, new Vector2(_movePoint.position.x, _movePoint.position.y), _movePoint.rotation);
        }   
    }

    void ChangeAnimationState(string newState)
    {
        if(_currentState == newState) return;

        _animator.Play(newState);
        _currentState = newState;
    }


    // Вариант передвижения 2 
    /*   
    [SerializeField] private Tilemap _level;

    private Vector3Int _direction = Vector3Int.right;

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.W))
            _direction = Vector3Int.up;
        else if (Input.GetKeyDown(KeyCode.S))
           _direction = Vector3Int.down;
        else if (Input.GetKeyDown(KeyCode.D))
           _direction = Vector3Int.right;
        else if (Input.GetKeyDown(KeyCode.A))
           _direction = Vector3Int.left;
    }

    public void CustomUpdate()
    {
        var celledPosition = _level.WorldToCell(transform.position);
        var nextPosition = celledPosition + _direction;

        if (_level.GetTile(nextPosition) == null)
            transform.position = nextPosition;
    }
    */

}
