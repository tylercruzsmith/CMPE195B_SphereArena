using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bounds : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform player;

    [SerializeField] private Transform resetPoint;

    void OnTriggerEnter (Collider v) {
        player.transform.position = resetPoint.transform.position;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.transform.rotation = Quaternion.identity;
    }
}
