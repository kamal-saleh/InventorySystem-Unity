using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ATMManager : MonoBehaviour
{
    [Header("Required UI")]
    [SerializeField] private TextMeshProUGUI playerBalanceValue;
    [SerializeField] private TextMeshProUGUI bankBalanceValue;
    [SerializeField] private TMP_InputField depositInputField;
    [SerializeField] private TMP_InputField withdrawInputField;

    void OnEnable()
    {
        UpdateATMUI();
    }

    void UpdateATMUI()
    {
        playerBalanceValue.text = GameManager.Instance.playerBalance.ToString();
        bankBalanceValue.text = GameManager.Instance.bankAccountBalance.ToString();
    }

    public void Deposit()
    {
        if (!string.IsNullOrEmpty(depositInputField.text))
        {
            if (int.TryParse(depositInputField.text, out int intValue))
            {
                if (intValue <=  GameManager.Instance.playerBalance)
                {
                    GameManager.Instance.playerBalance -= intValue;
                    GameManager.Instance.bankAccountBalance += intValue;
                }
            }
        }
        GameManager.Instance.UpdateGameUI();
        UpdateATMUI();
    }

    public void Withdraw()
    {
        if (!string.IsNullOrEmpty(withdrawInputField.text))
        {
            if (int.TryParse(withdrawInputField.text, out int intValue))
            {
                if (intValue <=  GameManager.Instance.bankAccountBalance)
                {
                    GameManager.Instance.bankAccountBalance -= intValue;
                    GameManager.Instance.playerBalance += intValue;
                }
            }
        }
        GameManager.Instance.UpdateGameUI();
        UpdateATMUI();
    }
}