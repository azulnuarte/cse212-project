public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan (steps):
        // 1. Create a double array of size 'length'.
        // 2. Loop through indices from 0 up to length-1.
        // 3. At position i, store number * (i + 1) 
        //    (because the first multiple is number * 1, not number * 0).
        // 4. Return the filled array.

        var result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan (steps):
        // 1. If the list is null or has 0/1 elements, do nothing.
        // 2. Normalize amount using amount = amount % data.Count 
        //    (this also handles the case amount == data.Count).
        // 3. If amount == 0 after normalization, do nothing.
        // 4. Take the last 'amount' elements using GetRange(start, amount).
        // 5. Remove those elements from the end using RemoveRange(start, amount).
        // 6. Insert the saved slice at the beginning using InsertRange(0, tail).

        if (data == null || data.Count <= 1) return;

        int n = data.Count;
        amount = amount % n;
        if (amount == 0) return;

        int start = n - amount;
        var tail = data.GetRange(start, amount);
        data.RemoveRange(start, amount);
        data.InsertRange(0, tail);
    }
}
