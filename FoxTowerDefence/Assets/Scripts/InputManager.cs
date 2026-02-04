using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

        private InputAction _moveAction;
        private InputAction _sprintAction;
        private InputAction _jumpAction;
        private InputAction _targetAction;
        private InputAction _attackAction;

        public static InputAction MoveAction => _instance?._moveAction;
        public static InputAction SprintAction => _instance?._sprintAction;
        public static InputAction JumpAction => _instance?._jumpAction;
        public static InputAction TargetAction => _instance?._targetAction;
        public static InputAction AttackAction => _instance?._attackAction;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this;
            DontDestroyOnLoad(gameObject);

            Initialize();
        }

        private void Initialize()
        {
            _moveAction = InputSystem.actions.FindAction("Move");
            _sprintAction = InputSystem.actions.FindAction("Sprint");
            _jumpAction = InputSystem.actions.FindAction("Jump");
            _targetAction = InputSystem.actions.FindAction("Target");
            _attackAction = InputSystem.actions.FindAction("Attack");

            _moveAction.Enable();
            _sprintAction.Enable();
            _jumpAction.Enable();
            _targetAction.Enable();
            _attackAction.Enable();
        }
}
