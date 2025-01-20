using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] float m_Speed = 50.0f;
    [SerializeField] GameObject m_PickupEffect;

    PlayerController m_PlayerController;
    GameManager m_GameManager;

    void Start()
    {
        m_PlayerController = GameObject.Find("Player").GetComponent<PlayerController>();
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (!m_GameManager.isGamePaused)
        {
            float relativeSpeed = m_Speed - m_PlayerController.currentSpeed;
            transform.Translate(Vector3.forward * relativeSpeed * Time.deltaTime);

            if (transform.position.z < -30.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    public void PickUp()
    {
        GameObject pickupEffect = Instantiate(m_PickupEffect, transform.position, m_PickupEffect.transform.rotation);
        Destroy(pickupEffect, 1.0f);
        Destroy(gameObject);
    }
}
