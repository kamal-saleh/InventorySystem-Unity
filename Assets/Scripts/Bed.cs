using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public void Sleep()
    {
        GameManager.Instance.bankAccountBalance += (int)(GameManager.Instance.bankAccountBalance * 0.1f);
        GameManager.Instance.UpdateGameUI();
    }
}
