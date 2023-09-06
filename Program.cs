/*
Напишите программу для подсчета общего количества повторяющихся элементов в массиве.
Необходимо только посчитать количество разных чисел, которые повторяются в массиве.
Пример.
[1, 0, 1, 5, 3, 9, 3, 4, 5, 3] -> 3 (посторяются три числа: 1, 5 и 3)
*/

int InputNum(string message)
{
    Console.WriteLine(message);
    return int.Parse(Console.ReadLine()!);
}

int[] CreateArray(int size)
{
    return new int[size];
}

void FillArray(int[] ints, int minValue, int maxValue)
{
    Random rnd = new Random();
    for (int i = 0; i < ints.Length; i++)
        ints[i] = rnd.Next(minValue, maxValue + 1);
}

void PrintArray(int[] ints)
{
    for (int i = 0; i < ints.Length; i++)
        Console.Write(ints[i] + " ");
    Console.WriteLine();
}

int[] MinMaxValues(int[] ints)
{
    int[] minMax = new int[2];
    minMax[0] = ints[0];
    minMax[1] = ints[0];
    for (int i = 1; i < ints.Length; i++)
    {
        if (ints[i] < minMax[0]) minMax[0] = ints[i];
        else if (ints[i] > minMax[1]) minMax[1] = ints[i];
    }
    return minMax;
}

int[] IsRepeatNums(int[] ints, int[] minMax)
{
    int[] isRepeat = new int[minMax[1] - minMax[0] + 1];
    for (int i = 0; i < ints.Length; i++)
        if(isRepeat[ints[i] - minMax[0]] == 0 || isRepeat[ints[i] - minMax[0]] == 1)
            isRepeat[ints[i] - minMax[0]]++;
    return isRepeat;
}

int CountRepeatNums(int[] isRepeat)
{
    int count = 0;
    for (int i = 0; i < isRepeat.Length; i++)
        if (isRepeat[i] == 2) count++;
    return count;
}

int size = InputNum("Введите размер массива: ");
int[] rndArray = CreateArray(size);
int min = InputNum("Введите минимальное значение элемента: ");
int max = InputNum("Введите максимальное значение элемента: ");
FillArray(rndArray, min, max);
PrintArray(rndArray);
int[] minMax = MinMaxValues(rndArray);
PrintArray(minMax);
int[] isRepeat = IsRepeatNums(rndArray, minMax);
PrintArray(isRepeat);
int result = CountRepeatNums(isRepeat);
Console.WriteLine(result);