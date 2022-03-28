using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerweMovement : MonoBehaviour
{
    private playerscript playerscript;
    private SwerweInputSystem _swerweInputSystem;
    [SerializeField]
    private float swerweSpeed = 0.5f;
    [SerializeField]
    private float maxSwerveAmount = 1f;
    [SerializeField]
    private int swervedirection=1;
    [SerializeField]
    private float positionConX;
    [SerializeField]
    private float positionConZ;

    // Start is called before the first frame update
    void Awake()
    {
        _swerweInputSystem = GetComponent<SwerweInputSystem>();
        playerscript = GetComponent<playerscript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //two directions


        if (!playerscript.PlayerHitBoolGetter())
        {
            if (swervedirection == 1)
            {
                float swerveAmount = Time.deltaTime * swerweSpeed * _swerweInputSystem.MoveFactorX;
                swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
                //transform.Translate(swerveAmount, 0, 0);
                Vector3 positioner = transform.position + new Vector3(swerveAmount, 0, 0);
                transform.position = new Vector3(Mathf.Clamp(positioner.x, -positionConX, positionConX), transform.position.y, transform.position.z);
            }
            if (swervedirection == 2)
            {
                float swerveAmount = Time.deltaTime * swerweSpeed * _swerweInputSystem.MoveFactorX;
                swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
                //transform.Translate(swerveAmount, 0, 0);
                Vector3 positioner = transform.position + new Vector3(0, 0, -swerveAmount);
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(positioner.z, -positionConZ + 95, positionConZ + 95));
            }
        }

        



    }

    public void SwerweDirectionSetter(int i)
    {
        swervedirection = i;
    }
}
