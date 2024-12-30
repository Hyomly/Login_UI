using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    GameObject m_resultPanel;
    [SerializeField]
    GameObject m_foundPanel;
    [SerializeField]
    GameObject m_findID_Panel;
    [SerializeField]
    GameObject m_findPW_Panel;
    [SerializeField]
    GameObject m_loginPanel;
    [SerializeField]
    GameObject m_createPanel;

   
    public void OnClickForgotID()
    {
        m_loginPanel.SetActive(false);
        m_findID_Panel.SetActive(true);
    }
    public void OnClickForgotPW()
    {
        m_loginPanel.SetActive(false);
        m_findPW_Panel.SetActive(true);
    }
    public void OnClickCreate()
    {
        m_loginPanel.SetActive(false);
        m_createPanel.SetActive(true);
    }
  
    public void GoLoginPanel()
    {
        m_resultPanel.gameObject.SetActive(false);
        m_foundPanel.gameObject.SetActive(false);
        m_createPanel.SetActive(false);
        m_findID_Panel.SetActive(false);
        m_findPW_Panel.SetActive(false);
        m_loginPanel.SetActive(true);
    }
    

    private void Start()
    {
        GoLoginPanel();
    }
}
