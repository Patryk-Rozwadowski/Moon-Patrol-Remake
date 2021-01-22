using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ConstantMoveFoward : MonoBehaviour {
    [SerializeField] private PlayerParamsSO playerParamsSo;
    
    private Rigidbody2D _rigidbody2D;
    private float _speed;
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _speed = playerParamsSo.playerSpeed;
    }

    void Update() {
        // TODO remove hardcoded x
        _rigidbody2D.velocity = new Vector2(_speed, 0);
    }
}