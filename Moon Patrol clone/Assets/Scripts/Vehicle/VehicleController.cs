using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D backTire = null;
    [SerializeField] private Rigidbody2D midTire = null;
    [SerializeField] private Rigidbody2D frontTire = null;
    [SerializeField] private float speed = 0;
    [SerializeField] private Rigidbody2D vehicleRigidBody = null;
    public static bool isInAir { get; set; }

    public WheelJoint2D wheelB;
    public WheelJoint2D wheelM;
    public WheelJoint2D wheelF;
    JointMotor2D jointMotor;

    public float waitTime;
    public float startWaitTime;

    void Start()
    {
        waitTime = startWaitTime;
    }


    private void Update()
    {
        

        if (isInAir)
        {
            vehicleRigidBody.freezeRotation = true;
        }
        else
        {
            vehicleRigidBody.freezeRotation = false;
            backTire.AddTorque(-speed * Time.fixedDeltaTime);
            midTire.AddTorque(-speed * Time.fixedDeltaTime);
            frontTire.AddTorque(-speed * Time.fixedDeltaTime);
            if (Input.GetKeyDown(KeyCode.D))
            {
                vehicleRigidBody.AddForce(Vector2.up * 19f, ForceMode2D.Impulse);
                Debug.Log("Jump");
            }
        }

        if (Input.GetKey(KeyCode.L))
        {
            if (waitTime <= 0)
            {
                speed = speed + 5;
                jointMotor.motorSpeed = speed;
                wheelB.motor = jointMotor;
                wheelM.motor = jointMotor;
                wheelF.motor = jointMotor;
                waitTime = 1;
                Debug.Log(speed);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
        if (Input.GetKey(KeyCode.K))
        {
            if (waitTime <= 0)
            {
                speed = speed - 5;
                jointMotor.motorSpeed = speed;
                wheelB.motor = jointMotor;
                wheelM.motor = jointMotor;
                wheelF.motor = jointMotor;
                waitTime = 1;
                Debug.Log(speed);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }

        }
    }
}