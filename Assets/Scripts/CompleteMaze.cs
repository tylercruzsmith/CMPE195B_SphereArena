using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine.SceneManagement;

public class CompleteMaze : Agent
{
    Vector3 playerStart;
	Rigidbody rb;
	Transform goalTransform;
	float maxDistance;

    public void Back()
    {
        SceneManager.LoadScene("LoadingScreen");
        //or "Name of Scene"
    }

    public override void Initialize()
    {
    	print("Start");
    	playerStart = transform.position;
        rb = GetComponent<Rigidbody>();
        //goalTransform = gameObject.transform.parent.gameObject.Find("Goal").transform; //GameObject.Find("Goal").transform;
        goalTransform = GameObject.Find("Goal").transform;

        maxDistance = (goalTransform.position - transform.position).magnitude;
    }

    public override void OnEpisodeBegin()
    {
        transform.position = playerStart;
    }
    
    /*
    public override void CollectObservations(VectorSensor sensor)
    {
    	//Vector3 goalError = (goalTransform.position - transform.position);
    	//sensor.AddObservation((maxDistance - goalError.magnitude)/maxDistance);
    	//sensor.AddObservation(goalTransform.position);
    	//sensor.AddObservation(transform.position);
    	//sensor.AddObservation(goalError.normalized);
    }
    */

    private float DiscreteToInput(int discrete)
    {
    	if (discrete == 1) {
    		return -1.0f;
		} else if (discrete == 2) {
			return 0.0f;
		} else {
			return 1.0f;
		}
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float x_input = DiscreteToInput(actions.DiscreteActions[0]);
        float y_input = DiscreteToInput(actions.DiscreteActions[1]);

        float playerSpeed = 10f;
        rb.velocity = playerSpeed * new Vector3(x_input, 0, y_input);
        transform.rotation = Quaternion.identity;
        AddReward(-0.001f);
    }

    private void ReachedGoal()
    {
    	print("Goal Reached");
        SetReward(1.0f);
        EndEpisode();
    }

    private void HitWall()
    {
    	print("Hit Wall");
        SetReward(-0.1f);
        EndEpisode();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
           ReachedGoal();
        } else if (col.gameObject.CompareTag("Wall"))
        {
           HitWall();
        }
    }
}
