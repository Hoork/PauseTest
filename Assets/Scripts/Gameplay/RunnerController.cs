using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class RunnerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody2d;

    private void Start()
    {
        Assert.IsNotNull(rigidBody2d);
    }

    private void Update()
    {
        if (transform.position.x >= 20)
        {
            var newPosition = new Vector2(-20, transform.position.y);
            rigidBody2d.MovePosition(newPosition);
        }
    }

    private void FixedUpdate()
    {
        rigidBody2d.velocity = speed * Time.deltaTime * Vector2.right;
    }
}
