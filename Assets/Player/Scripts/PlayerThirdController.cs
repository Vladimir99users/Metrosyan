using UnityEngine;
using UnityEngine.InputSystem;

sealed class PlayerThirdController : MonoBehaviour
{
    private Player _player => GetComponent<Player>() as Player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _point;

    [Tooltip("Время для нового выстрела")]
    [SerializeField] private float _reloadedFire; // 5;
    [SerializeField] private KeyBoardInput _inputKeyBoard;

    
    private float _timeToFire;
    private InputAction _moveAction;
    private InputAction _attackAction;
    private InputAction _menuAction;
    private InputAction _menuRadial;
    private Vector3 moveVector;


    private void Awake()
    {
        _inputKeyBoard = new KeyBoardInput();
    }


    private void OnEnable()
    {
        _moveAction = _inputKeyBoard.KeyBoardContoller.WASD;
        _attackAction = _inputKeyBoard.KeyBoardContoller.Fire;
        _menuAction = _inputKeyBoard.KeyBoardContoller.CraftMenu;
        _menuRadial = _inputKeyBoard.KeyBoardContoller.RadialMenu;

        EnableActionsInputManadger();

        _attackAction.performed += _player.Fire;
        _menuAction.performed += _player.VisibilityMenu;
        _menuRadial.performed += _player.VisibilityRadialMenu;
    }

    private void EnableActionsInputManadger()
    {
        _attackAction.Enable();
        _moveAction.Enable();
        _menuAction.Enable();
        _menuRadial.Enable();
    }
    private void OnDisable()
    {
        DisableActionsInputManadger();
    }
    private void DisableActionsInputManadger()
    {
        _moveAction.Disable();
        _attackAction.Disable();
        _menuAction.Disable();
        _menuRadial.Disable();
    }
    private void Start()
    {
        _timeToFire = _reloadedFire;
    }
    private void Update()
    {
        _player.MovePlayer(_moveAction.ReadValue<Vector2>());
    }

}
