using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class HitBallInGoalAgent : Agent
{

    [SerializeField] private Transform ballTransform;
    [SerializeField] private Transform goalTransform;

    Vector3 playerStart = new Vector3(-6, 1.5f, 0);
    Vector3 ballStart = new Vector3(-2, 1, 0);
    public GameObject ball;
    public CheckGoal checkGoal;
    public Bounds bounds;
    GameObject ground;
   

    public override void Initialize()
    {
        checkGoal = ball.GetComponent<CheckGoal>();
        
    }

    public override void OnEpisodeBegin()
    {
        print("starting...");
        //transform.position = Vector3.zero;
        transform.position = playerStart;
        ballTransform.position = ballStart;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }



    public override void CollectObservations(VectorSensor sensor)
    {
       
        sensor.AddObservation(transform.position);
        sensor.AddObservation(ballTransform.position);
        sensor.AddObservation(goalTransform.position);
        sensor.AddObservation(goalTransform.position - ballTransform.position);
        
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log(actions.ContinuousActions[0]);

        float posX = actions.ContinuousActions[0];
        float posY = actions.ContinuousActions[1];

        float playerSpeed = 10f;
        transform.position += playerSpeed * Time.deltaTime * new Vector3(posX, 0, posY);

        
        //AddReward(-1f / MaxStep);

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }
    public void ScoredGoal()
    {
        Debug.Log("Goal Scored!");
        AddReward(1000f);
        Debug.Log(GetCumulativeReward());
        EndEpisode();
    }

    public void ballOut()
    {
        AddReward(-20f);
        EndEpisode();
    }

    private void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("Ball"))
        {
           AddReward(10f);
           Debug.Log(GetCumulativeReward());
            print("hit ball");
        
        }
        if (col.gameObject.CompareTag("Wall"))
        {
            AddReward(-1000f);
            EndEpisode();
        }
    }

}
