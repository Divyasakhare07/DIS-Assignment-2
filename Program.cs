﻿using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 0, 1, 2 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = [3, 2, 4];
            int target = 6;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int n = nums.Length;
            // Create a list with numbers from 1 to n
            HashSet<int> fullSet = new HashSet<int>(Enumerable.Range(1, n));
            
            // Remove duplicates from input list and create a HashSet
            HashSet<int> inputSet = new HashSet<int>(nums);

            // Remove the elements that are present in the input set from the full set
            fullSet.ExceptWith(inputSet);

            // Return the missing numbers as a list
            return fullSet.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
            List<int> result = new List<int>();
            // Iterate through the original array and append even numbers to the result
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    result.Add(num);
                }
            }
            // After adding all even numbers, append the odd numbers
            foreach (var num in nums)
            {
                if (num % 2 != 0)
                {
                    result.Add(num);
                }
            }
            // Convert the result list back to an array and return
            return result.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Create a dictionary to store numbers and their indices
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            // Iterate through the array
            for (int i = 0; i < nums.Length; i++)
            {
                // Calculate the complement (target - current number)
                int complement = target - nums[i];

                // Check if the complement exists in the dictionary
                if (numDict.ContainsKey(complement))
                {
                    // If the complement is found, return the indices
                    return new int[] { numDict[complement], i };
                }
                // If not found, add the current number and its index to the dictionary
                numDict[nums[i]] = i;
            }
                // Return an empty array if no solution is found
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                Array.Sort(nums);
                int n = nums.Length;

                // Maximum product could be either from the last three numbers 
                // or the first two (smallest negative numbers) and the largest number.
                int maxProduct = Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                        nums[0] * nums[1] * nums[n - 1]);
                return maxProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                    {
                        return "0"; // Special case for zero
                    }

                string binary = "";
                while (decimalNumber > 0)
                {
                    int remainder = decimalNumber % 2; // Get remainder (0 or 1)
                    binary = remainder + binary;       // Prepend the remainder to the binary string
                    decimalNumber /= 2;                // Divide the number by 2
                }

                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                // Binary search loop
                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                // If middle element is greater than right element, minimum is in the right half
                if (nums[mid] > nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    // Otherwise, it's in the left half (or could be the middle element itself)
                    right = mid;
                }
            }
                    // After the loop, left == right and points to the minimum element
                    return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes
                if (x < 0)
                    return false;

                int original = x;
                int reversed = 0;

                // Reverse the number
                while (x > 0)
                {
                    int lastDigit = x % 10; // Extract the last digit
                    reversed = reversed * 10 + lastDigit; // Build the reversed number
                    x /= 10; // Remove the last digit from x
                }

                // Compare the reversed number with the original
                return original == reversed;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                int a = 0, b = 1, fib = 0;

                // Calculate Fibonacci iteratively
                for (int i = 2; i <= n; i++)
                {
                    fib = a + b; // F(n) = F(n-1) + F(n-2)
                    a = b;       // Move to the next pair of numbers
                    b = fib;
                }

                return fib;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}