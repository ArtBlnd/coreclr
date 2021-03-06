using System;
using System.Collections.Generic;
/// <summary>
///GetEnumerator 
/// </summary>
public class ListIEnumerableGetEnumerator
{
    public static int Main()
    {
        ListIEnumerableGetEnumerator ListIEnumerableGetEnumerator = new ListIEnumerableGetEnumerator();
        TestLibrary.TestFramework.BeginTestCase("ListIEnumerableGetEnumerator");
        if (ListIEnumerableGetEnumerator.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }
    public bool RunTests()
    {
        bool retVal = true;
        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        return retVal;
    }
    // Returns true if the expected result is right
    // Returns false if the expected result is wrong

    public bool PosTest1()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest1: Calling GetEnumerator method of IEnumerable,T is Value type.");
        try
        {
            List<int> myList = new List<int>();
            int count=10;
            int[] expectValue = new int[10];

            for(int i=1;i<=count;i++)
            {
                myList.Add(i*count);
                expectValue[i - 1] = i * count;
            }
            IEnumerator<int> returnValue = ((IEnumerable<int>)myList).GetEnumerator();
            int j=0;
            for (IEnumerator<int> itr = returnValue; itr.MoveNext(); )
            {
                int current = itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("001.1."+j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }
          
        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("001.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
    public bool PosTest2()
    {
        bool retVal = true;
        TestLibrary.TestFramework.BeginScenario("PosTest2: Calling GetEnumerator method of IEnumerable,T is reference type.");
        try
        {
            List<string> myList = new List<string>();
            int count = 10;
            string[] expectValue = new string[10];
            string element = string.Empty;
            for (int i = 1; i <= count; i++)
            {
                element = i.ToString();
                myList.Add(element);
                expectValue[i - 1] = element;
            }
            IEnumerator<string> returnValue = ((IEnumerable<string>)myList).GetEnumerator();
            int j = 0;
            for (IEnumerator<string> itr = returnValue; itr.MoveNext(); )
            {
                string current = itr.Current;
                if (expectValue[j] != current)
                {
                    TestLibrary.TestFramework.LogError("002.1." + j.ToString(), " current value should be " + expectValue[j]);
                    retVal = false;
                }
                j++;
            }

        }
        catch (Exception e)
        {
            TestLibrary.TestFramework.LogError("002.0", "Unexpected exception: " + e);
            retVal = false;
        }

        return retVal;
    }
  
}

