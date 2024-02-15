using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody2d;

    private void Start()
    {
        Assert.IsNotNull(rigidBody2d);
    }

    private void Update()
    {
        Managers.Ui.GameplayUi.Position = transform.position;
    }

    private void FixedUpdate()
    {
        var axisX = Input.GetAxis("Horizontal");
        var axisY = Input.GetAxis("Vertical");
        var direction = new Vector2(axisX, axisY);
        rigidBody2d.velocity = speed * Time.deltaTime * direction;
    }
}
