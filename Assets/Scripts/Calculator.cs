using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Calculator : MonoBehaviour
{
    [SerializeField] InputField _leftValue;
    [SerializeField] InputField _rightValue;
    [SerializeField] InputField _result;

    public void CalculateResult(Button button)
    {
        int left = getIntValue(_leftValue);
        int right = getIntValue(_rightValue);
        switch (button.name)
        {
            case "Plus_Button":
                Addition(left, right);
                break;
            case "Minus_Button":
                Subtraction(left, right);
                break;
            case "Multiply_Button":
                Multiplication(left, right);
                break;
            case "Divide_Button":
                Division(left, right);
                break;
            case "Compare_Button":
                Compare(left, right);
                break;
            default:
                print("Where did you found this?");
                break;
        }
    }

    private void Addition(int left, int right)
    {
        _result.text = (left + right).ToString();
    }

    private void Subtraction(int left, int right)
    {
        _result.text = (left - right).ToString();
    }

    private void Multiplication(int left, int right)
    {
        _result.text = (left * right).ToString();
    }

    private void Division(int left, int right)
    {
        if (right == 0) 
        {
            print("Illegal division by 0");
            return;
        }
        _result.text = (left / right).ToString();
    }

    private void Compare(int left, int right)
    {
        string result;
        if (left == right)
        {
            result = "Equal";
        } else
        {
            result = left > right ? left.ToString() : right.ToString();
        }
        _result.text = result;
    }

    private int getIntValue(InputField inputField)
    {
        if(inputField.text != "")
        {
            try 
            {
                return Convert.ToInt32(inputField.text);
            } 
            catch (FormatException e)
            {
                print("Value is not a number");
                inputField.text = "0";

                return 0;
            }
            
        }
        else
        {
            return 0;
        }
    }
}
