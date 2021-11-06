using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform player;

    //brings camera to "Head" position (i swear to god if you think that THAT is a joke).
    void Update() {
        transform.position = player.transform.position;
    }
}