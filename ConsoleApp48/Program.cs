using System;

namespace ConsoleApp
{
    class Program
    {
        static void MaxNum(int num)
        {
            string numStr=Convert.ToString(num);
            int numLength=numStr.Length;
            
            string glass;
            string newNumStr = "";

            int ArrayLength = 1;
            for(int i = numLength - 1; i != 0; i--)
            {
                ArrayLength += i;
            }
            string[] numArray = new string[ArrayLength];
            numArray[0] = numStr;

            int j = 1;//индекс цифры заменяемой в конце
            int k = 0;//индекс цифры заменяемой 1-ой
            int z = 1;//индекс массива
            for(int i = 0; z < ArrayLength; i++)//i - индекс исходного числа
            {
                glass = Convert.ToString(numStr[k]);
                if (i == k) newNumStr += numStr[j];
                else if (i == j) newNumStr += glass;
                else newNumStr += numStr[i];

                if (i == numLength - 1)
                {
                    numArray[z] = newNumStr;
                    newNumStr = "";
                    i = -1;
                    z++;
                    j++;
                    if(j == numLength)
                    {
                        k++;
                        j = k + 1;
                    }
                }
            }

            int difference = -1;
            int minDiff = -1;
            int minDiffIndex = 0;
            for(int i = 1; i < ArrayLength; i++)
            {
                if (Convert.ToInt32(numArray[i]) - Convert.ToInt32(numArray[0]) > 0)
                {
                    minDiff = Convert.ToInt32(numArray[i]) - Convert.ToInt32(numArray[0]);
                    minDiffIndex = i;

                    for(int c = 1; c < ArrayLength; c++)
                    {
                        difference = Convert.ToInt32(numArray[c]) - Convert.ToInt32(numArray[0]);
                        if(difference > 0) 
                        {
                            if (minDiff > difference) 
                            {
                                minDiff = difference; 
                                minDiffIndex = c;
                            }
                        }
                        
                    }
                    break;
                }
            }
            if (Convert.ToInt32(numArray[minDiffIndex]) == num || minDiff == -1) Console.WriteLine(0);
            else Console.WriteLine(numArray[minDiffIndex]);
        }
        static void Main(string[] args)
        {
            int num = 2223;
            MaxNum(num);
        }
    }
}
