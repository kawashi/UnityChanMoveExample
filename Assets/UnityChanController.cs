using UnityEngine;

public class UnityChanController : MonoBehaviour {
    public float Speed = 2f;
    public float Thrust = 100;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _onGround;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    void Update() {
        if (!_onGround) return;
        CalcMove();
        CalcJump();
    }
    
    void OnCollisionStay(Collision other) {
        _onGround = true;
    }

    private void CalcMove() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            _rigidbody.velocity = new Vector3(Speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            _rigidbody.velocity = new Vector3(-Speed, 0, 0);
            transform.rotation = Quaternion.Euler(0, 270, 0);
        } else if (Input.GetKey(KeyCode.UpArrow)) {
            _rigidbody.velocity = new Vector3(0, 0, Speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            _rigidbody.velocity = new Vector3(0, 0, -Speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        } else {
            _animator.SetBool("Running", false);
            return;
        }
        
        _animator.SetBool("Running", true);
    }

    private void CalcJump() {
        if (Input.GetKey(KeyCode.Space)) {
            _rigidbody.AddForce(new Vector3(0, Thrust, 0));
            _animator.SetBool("Jumping", true);
            _onGround = false;
        } else {
            _animator.SetBool("Jumping", false);
        }
    }
}