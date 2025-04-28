using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player singleton;
    public State state = State.Idle;
    public float force;
    public enum State
    {
        Idle, //0
        Walking, //1
        Jumping //2
    }

    public Rigidbody2D body;

    Vector2 direction;

    void Start(){
        if(singleton == null){
            singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        Debug.Log($"State: {state}");
        switch (state)
        {
            case State.Idle:
                OnIdle();
                break;
            case State.Walking:
                OnWalking();
                break;
            case State.Jumping:
                OnJumping();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.tag);
        if(collision.collider.gameObject.tag == "platform")
        {

            state = State.Walking;
        }
    }

    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    Debug.Log(collision.collider.gameObject.tag);
    //    if (collision.collider.gameObject.tag == "platform")
    //    {
    //        state = State.Walking;
    //    }
    //}


    void OnWalking()
    {
        if (!HorizontalMove())
        {
            state = State.Idle;
        }
        if (Jump())
        {
            state = State.Jumping;
        }
        transform.Translate(direction * Time.deltaTime);
    }

    void OnIdle()
    {
        if (HorizontalMove())
        {
            state = State.Walking;
        }
        if(Jump())
        {
            state = State.Jumping;
        }
    }

    void OnJumping()
    {
        if (HorizontalMove())
        {
            transform.Translate(direction * Time.deltaTime);
        }
    }

    //Checks horizontal Input
    bool HorizontalMove()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector2.left;
            return true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector2.right;
            return true;
        }
        return false;
    }

    //Checks jump Input
    bool Jump()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            body.AddForceY(force);
            return true;
        }
        return false;
    }
}
