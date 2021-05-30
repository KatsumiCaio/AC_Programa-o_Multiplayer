using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ControllerCar : MonoBehaviour
{

    float frente;
    float re;
    float girar;
    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        frente = 10;
        girar = 60;
        re = 5;

        photonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!photonView.IsMine)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate((frente * Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-re* Time.deltaTime), 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, (- girar * Time.deltaTime), 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, (girar * Time.deltaTime), 0);
        }
    }
}
