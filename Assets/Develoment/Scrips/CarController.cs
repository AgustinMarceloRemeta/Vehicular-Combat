using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] TextMeshProUGUI VelocityVisual;
    Rigidbody Rb;
    [SerializeField] WheelCollider WheelBl, WheelBr, WheelFr, WheelFl;
    [SerializeField] Transform TrWheelBl, TrWheelBr, TrWheelFr, TrWheelFl;
    [SerializeField] float Force, Velocity,VelocityMax, ActualVelocity, AnguledDirection, Turn;
    [SerializeField] string AxisVertical, AxisHorizontal;
    [Header("Shooting")]
    [SerializeField] bool IsShooting;
    [SerializeField] GameObject Bullet;
    [SerializeField] Transform Spawn1, Spawn2;
    [SerializeField] float VelShoot;
    public float Life, LifeMax;
    [SerializeField] Image ImLife;
    public bool VelocityPower, TimePower, ShootPower;
    [SerializeField] TextMeshProUGUI PowerVelText, PowerTimeText, PowerShootText;
    
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Life = LifeMax;
    }
    private void FixedUpdate()
    {
        Wheels();
        
    }
    private void Update()
    {
        VisualWhels();
        if (IsShooting)
        {
            if (Input.GetKeyDown("space")) Shoot();
            ImLife.fillAmount = Life / LifeMax;
            TextPowerUp();
        }
    }

    private void Wheels()
    {
        ActualVelocity = 2 * Mathf.PI * WheelFl.radius * WheelFl.rpm * 60 / 1000;
      if(Velocity<VelocityMax)
        {
            if (VelocityPower)
            {
                WheelFl.motorTorque = Force * Input.GetAxis(AxisVertical)*2;
                WheelFr.motorTorque = Force * Input.GetAxis(AxisVertical)*2;
                WheelBl.motorTorque = Force * Input.GetAxis(AxisVertical)*2;
                WheelBl.motorTorque = Force * Input.GetAxis(AxisVertical)*2;
            }
            else
            {
                WheelFl.motorTorque = Force * Input.GetAxis(AxisVertical);
                WheelFr.motorTorque = Force * Input.GetAxis(AxisVertical);
                WheelBl.motorTorque = Force * Input.GetAxis(AxisVertical);
                WheelBl.motorTorque = Force * Input.GetAxis(AxisVertical);
            }
            VelocityVisual.text = Velocity.ToString("000");
        }
        else
        {
            WheelFl.motorTorque = 0;
            WheelFr.motorTorque = 0;
            WheelBl.motorTorque = 0;
            WheelBl.motorTorque = 0;
            VelocityVisual.text = VelocityMax.ToString("000");
        }

        Velocity = Rb.velocity.magnitude * 15;

        Turn = AnguledDirection * Input.GetAxis(AxisHorizontal);
        WheelFl.steerAngle = Turn;
        WheelFr.steerAngle = Turn;
    }

    private void VisualWhels()
    {
        Vector3 DirectionWheel = TrWheelFl.localEulerAngles;
        DirectionWheel.y = Turn;
        TrWheelFl.localEulerAngles = DirectionWheel;
        TrWheelFr.localEulerAngles = DirectionWheel;

        TrWheelBl.Rotate(ActualVelocity, 0, 0);
        TrWheelFl.Rotate(ActualVelocity, 0, 0);
        TrWheelBr.Rotate(ActualVelocity, 0, 0);
        TrWheelFr.Rotate(ActualVelocity, 0, 0);
    }

    private void Shoot()
    {
       GameObject Bl1 = Instantiate(Bullet, Spawn1);
       GameObject Bl2 = Instantiate(Bullet, Spawn2);
        if (ShootPower)
        {
            Bl1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot*2);
            Bl2.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot*2);
        }
        else
        {
            Bl1.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot);
            Bl2.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * Time.deltaTime * VelShoot);
        }
        Destroy(Bl1, 10);
        Destroy(Bl2, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletEnemy")) 
        {
            Life -= 5;
            Destroy(other.gameObject);        
        }
        if (other.gameObject.CompareTag("Velocity")) 
        {
           StartCoroutine(Timer(0, 10));
            Destroy(other.gameObject);
        }    
        if (other.gameObject.CompareTag("Time")) 
        {
            StartCoroutine(Timer(1, 3));
            FindObjectOfType<GameManager>().TimeToWin -= 5;
            Destroy(other.gameObject);
        }     
        if (other.gameObject.CompareTag("Shoot")) 
        {
            StartCoroutine(Timer(2, 10));
            Destroy(other.gameObject);
        }
    }

    IEnumerator Timer(float TypePowerUp,float time)
    {
        switch (TypePowerUp)
        {
            case 0: VelocityPower = true;
                break;
            case 1: TimePower = true;
                break;
            case 2: ShootPower = true;
                break;
            default:
                break;
        }
        yield return new WaitForSeconds (time);
           
                VelocityPower = false;    
                TimePower = false;         
                ShootPower = false;
    }
    void TextPowerUp()
    {
        if (ShootPower) PowerShootText.text = "Activado";
        else PowerShootText.text = "Desactivado";
        if (TimePower) PowerTimeText.text = "-5";
        else PowerTimeText.text = " ";
        if (VelocityPower) PowerVelText.text = "Activado";
        else PowerVelText.text = "Desactivado";

    }
}

