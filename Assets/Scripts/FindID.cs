using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FindID : MonoBehaviour
{
    [SerializeField]
    TMP_InputField m_name;
    [SerializeField]
    TMP_InputField m_email;    
    [SerializeField]
    TMP_Text m_foundText;
    [SerializeField]
    TMP_Text m_text;
    [SerializeField]
    GameObject m_foundPanel;
    [SerializeField]
    UserData m_data;

    void IDCheck()
    {
        var data = m_data.Users;
        if (data.Count == 0)
        {
            m_text.text = "";
            m_foundText.text = "no information";
        }
            
        for (int i = 0; i < data.Count; i++)
        {
            if (m_name.text == data[i].m_name && m_email.text == data[i].m_email)
            {
                m_text.text = "Your ID";
                m_foundText.text = data[i].m_id;
                break;
            }
            else 
            {
                m_text.text = "";
                m_foundText.text = "no information";
                
            }
        }

    }
   
    public void ClearField()
    {
        m_name.text = null;
        m_email.text = null;
    }
    public void OnClick_ID_OK()
    {
        m_foundPanel.SetActive(true);
        IDCheck();
        ClearField();
    }
}
