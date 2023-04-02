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
        float left = getIntValue(_leftValue);
        float right = getIntValue(_rightValue);
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

    private void Addition(float left, float right)
    {
        _result.text = (left + right).ToString().Replace("." , ",");
    }

    private void Subtraction(float left, float right)
    {
        _result.text = (left - right).ToString().Replace(".", ",");
    }

    private void Multiplication(float left, float right)
    {
        _result.text = (left * right).ToString().Replace(".", ",");
    }

    private void Division(float left, float right)
    {
        if (right == 0) 
        {
            print("Illegal division by 0");
            return;
        }
        _result.text = (left / right).ToString().Replace(".", ",");
    }

    private void Compare(float left, float right)
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

    private float getIntValue(InputField inputField)
    {
        if(inputField.text != "")
        {
            try 
            {
                return (float) Convert.ToSingle(inputField.text.Replace(",", "."));
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
