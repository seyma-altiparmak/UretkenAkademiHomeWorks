using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIMathManager : MonoBehaviour
{
    private TMP_InputField INPUT_Number1;
    protected TMP_InputField INPUT_Number2;
    public TextMeshProUGUI OUTPUT_Txt;

    private int OperationNumber;

    private void Start()
    {
        INPUT_Number1 =
        GameObject.Find("FirstNumber_INPUT").
        GetComponent<TMP_InputField>();
        INPUT_Number2 =
        GameObject.Find("SecondNumber_INPUT").
        GetComponent<TMP_InputField>();
    }
    public void OUTPUT_BUTTON_ALL()
    {
        OperationNumber = 0;
        ALLOperation(OperationNumber);
    }
    public void OUTPUT_BUTTON_ODD()
    {
        OperationNumber = 1;
        ALLOperation(OperationNumber);
    }
    public void OUTPUT_BUTTON_EVEN()
    {
        OperationNumber = 2;
        ALLOperation(OperationNumber);
    }
    public void OUTPUT_BUTTON_MOD3()
    {
        OperationNumber = 3;
        ALLOperation(OperationNumber);
    }
    public void OUTPUT_BUTTON_MOD5()
    {
        OperationNumber = 4;
        ALLOperation(OperationNumber);
    }
    public bool ERROR_Controller(TMP_InputField input)
    {
        bool isPositive = false;
        try
        {
            string iint = Convert.ToString(input.text);
            int number = Convert.ToInt32(iint);
            if (number > 0)
            {
                isPositive = true;
            }
        }
        catch (FormatException)
        {
            OUTPUT_Txt.text = "Please Enter Valid NUMBER. - Format Exception";
            print(input.text);
        }
        catch (OverflowException)
        {
            OUTPUT_Txt.text = "Please Enter Valid NUMBER - Overflow Exception";
        }
        return isPositive;
    }
    private void ALLOperation(int op)
    {
        if (ERROR_Controller(INPUT_Number1) && ERROR_Controller(INPUT_Number2))
        {
            if (int.TryParse(INPUT_Number1.text, out int num1) && int.TryParse(INPUT_Number2.text, out int num2))
            {
                string result = ""; // Sonucu biriktirmek için bir deðiþken
                switch (op)
                {
                    case 0:
                        result = "All Numbers : \n";
                        for (int i = num1; i <= num2; i++)
                        {
                            result += $"{i} - ";
                        }
                        break;
                    case 1:
                        result = "Even Numbers : \n";
                        for (int i = num1; i <= num2; i++)
                        {
                            if (i % 2 == 0) result += $"{i} - ";
                        }
                        break;
                    case 2:
                        result = "Odd Numbers : \n";
                        for (int i = num1; i <= num2; i++)
                        {
                            if (i % 2 != 0) result += $"{i} - ";
                        }
                        break;
                    case 3:
                        result = "/3 Numbers : \n";
                        for (int i = num1; i <= num2; i++)
                        {
                            if (i % 3 == 0) result += $"{i} - ";
                        }
                        break;
                    case 4:
                        result = "/5 Numbers : \n";
                        for (int i = num1; i <= num2; i++)
                        {
                            if (i % 5 == 0) result += $"{i} - ";
                        }
                        break;
                    default:
                        result += "";
                        break;
                }

                OUTPUT_Txt.text = result; 
            }
        }
    }
}
