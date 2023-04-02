using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Sort : MonoBehaviour
{

    /// <summary>
    /// OnClick event handling method of the 'Sum of even numbers of the specified range' button
    /// </summary>
    public void OnSumEvenNumbersInRange()
    {
        int min = 7;
        int max = 21;
        var want = 98;
        int got = SumEvenNumbersInRange(min, max);
        string message = want == got ? "Результат верный" : $"Результат неверный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в диапазоне от {min} до {max} включительно: {got} - {message}");
    }

    /// <summary>
    /// The method calculates the sum of even numbers in the given range
    /// </summary>
    /// <param name='min'>Minimum value of the range</param>
    /// <param name='max'>The maximum value of the range</param>
    /// <returns>Sum of numbers of even numbers</returns>
    private int SumEvenNumbersInRange(int min, int max)
    {
        int sum = 0;
        int current = min;
        while(current <= max)
        {
            if (current % 2 == 0)
            {
                sum += current;
            }
            current++;
        }
        return sum;
    }

    /// <summary>
    /// Method for handling the OnClick event of the 'Sum of even numbers in the given array' button
    /// </summary>
    public void OnSumEvenNumbersInArray()
    {
        int[] array = { 81, 22, 13, 54, 10, 34, 15, 26, 71, 68 };
        int want = 214;
        int got = SumEvenNumbersInArray(array);
        string message = want == got ? "Результат верный" : $"Результат {got} неверный, ожидается {want}";
        Debug.Log($"Сумма четных чисел в заданном массиве :  { message}");
    }

    /// <summary>
    /// The method calculates the sum of even numbers in the array
    /// </summary>
    /// <param name='array'>Initial array of numbers</param>
    /// <returns>Sum of numbers of even numbers</returns>
    private int SumEvenNumbersInArray(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] % 2 == 0)
            {
                sum += array[i];
            }
        }
        return sum;
    }


    /// <summary>
    /// Method for handling the OnClick event of the button 'Finding the first occurrence of a number in the array'
    /// </summary>
    public void OnFirstOccurrence()
    {
        // First test, the number is present in the array
        int[] array = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        int value = 34;
        int want = 3;
        int got = FirstOccurrence(array, value);
        string message = want == got ? "Результат верный" : $"Результат {got} неверный, ожидается {want}";
        Debug.Log(want == got ? "Результат верный" : $"Результат неверный, ожидается {want}");
        Debug.Log($"Индекс первого вхождения числа {value} в массив: {got} - {message}");
    }

    /// <summary>
    /// The method searches for the first occurrence of a number in the array
    /// </summary>
    /// <param name='array'>Source array</param>
    /// <param name='value'>Number to look for</param>
    /// <returns>Index of the desired number in the array, or -1 if the number is missing</returns>
    private int FirstOccurrence(int[] array, int value)
    {
        for(int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }
        return -1;
    }

    /// <summary>
    /// Method for handling the OnClick event of the 'Sort by selection' button
    /// </summary>

    public void OnSelectionSort()
    {
        int[] originalArray = { 81, 22, 13, 34, 10, 34, 15, 26, 71, 68 };
        Debug.LogFormat("Исходный массив {0}", "[" + string.Join(",", originalArray) + "]");

        int[] sortedArray = SelectionSort((int[])originalArray.Clone());
        Debug.LogFormat("Результат сортировки {0}", "[" + string.Join(",", sortedArray) + "]");

        int[] expectedArray = { 10, 13, 15, 22, 26, 34, 34, 68, 71, 81 };
        Debug.Log(sortedArray.SequenceEqual(expectedArray) ? "Результат верный" : "Результат не верный");
    }

    /// <summary>
    /// Method sort the array by selection method
    /// </summary>
    /// <param name='array'>Source array</param>
    /// <returns>Sorted array</returns>
    private int[] SelectionSort(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
        return array;
    }
}
