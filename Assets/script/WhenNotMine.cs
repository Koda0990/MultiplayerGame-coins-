using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenNotMine : MonoBehaviour
{
    PhotonView m_PV;
    [SerializeField] List <GameObject> m_listGameObj;
    [SerializeField] List <MonoBehaviour> m_listScripts;
    // Start is called before the first frame update
    void Start()
    {
        m_PV = GetComponent<PhotonView>();
        if (!m_PV.IsMine)
        {
            disableScripts();   
            disableObjects();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void disableObjects()
    {
        foreach(GameObject obj in m_listGameObj)
        {
            Destroy(obj);
        }
    }
    void disableScripts()
    {
        foreach(MonoBehaviour obj in m_listScripts)
        {
            Destroy(obj);
        }
    }
}
