using System;

namespace SiaOS.Prog
{
    class Calculator
    {
        public static void Calc()
        {
            try
            {
                int firstNum;
                int secondNum;
                int thirdNum;
                //Variables for equation

                string operation;
                string operation2;
                int answer;
                int answer2;

                Console.WriteLine("\nHow many integers? 2 or 3?");
                var inter = Console.ReadLine().ToLower();
                ;

                if (inter == "2")
                {

                    Console.Write("Enter the first number in your equation: ");
                    firstNum = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter your operation ( x , / , +, -) ");
                    operation = Console.ReadLine();

                    //User input for equation
                    Console.Write("Enter your second number in the equation: ");
                    secondNum = Convert.ToInt32(Console.ReadLine());


                    if (operation == "x")
                    {
                        answer = firstNum * secondNum;
                        Console.WriteLine(firstNum + " x " + secondNum + " = " + answer);
                        Console.ReadLine();
                    }
                    else if (operation == "/")
                    {
                        answer = firstNum / secondNum;
                        Console.WriteLine(firstNum + " / " + secondNum + " = " + answer);
                        Console.ReadLine();
                    }
                    //Getting answers
                    else if (operation == "+")
                    {
                        answer = firstNum + secondNum;
                        Console.WriteLine(firstNum + " + " + secondNum + " = " + answer);
                        Console.ReadLine();
                    }
                    else if (operation == "-")
                    {
                        answer = firstNum - secondNum;
                        Console.WriteLine(firstNum + " - " + secondNum + " = " + answer);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Sorry that is not correct format! Please restart.");     //Catch
                        Console.ReadLine();
                    }
                }
                else if (inter == "3")
                {

                    Console.Write("Enter the first number in your equation: ");
                    firstNum = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter your operation ( x , / , +, -) ");
                    operation = Console.ReadLine();

                    //User input for equation
                    Console.Write("Enter your second number in the equation: ");
                    secondNum = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter your operation ( x , / , +, -) ");
                    operation2 = Console.ReadLine();

                    //User input for equation
                    Console.Write("Enter your third number in the equation: ");
                    thirdNum = Convert.ToInt32(Console.ReadLine());

                    if (operation == "x")
                    {
                        answer = firstNum * secondNum;
                        if (operation2 == "x")
                        {
                            answer2 = answer * thirdNum;
                            Console.WriteLine(firstNum + " x " + secondNum + " x " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "/")
                        {
                            answer2 = answer / thirdNum;
                            Console.WriteLine(firstNum + " x " + secondNum + " / " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "+")
                        {
                            answer2 = answer + thirdNum;
                            Console.WriteLine(firstNum + " x " + secondNum + " + " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "-")
                        {
                            answer2 = answer - thirdNum;
                            Console.WriteLine(firstNum + " x " + secondNum + " - " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }

                    }
                    else if (operation == "/")
                    {
                        answer = firstNum / secondNum;
                        if (operation2 == "x")
                        {
                            answer2 = answer * thirdNum;
                            Console.WriteLine(firstNum + " / " + secondNum + " x " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "/")
                        {
                            answer2 = answer / thirdNum;
                            Console.WriteLine(firstNum + " / " + secondNum + " / " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "+")
                        {
                            answer2 = answer + thirdNum;
                            Console.WriteLine(firstNum + " / " + secondNum + " + " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "-")
                        {
                            answer2 = answer - thirdNum;
                            Console.WriteLine(firstNum + " / " + secondNum + " - " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }

                    }
                    //Getting answers
                    else if (operation == "+")
                    {
                        answer = firstNum + secondNum;
                        if (operation2 == "x")
                        {
                            answer2 = answer * thirdNum;
                            Console.WriteLine(firstNum + " + " + secondNum + " x " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "/")
                        {
                            answer2 = answer / thirdNum;
                            Console.WriteLine(firstNum + " + " + secondNum + " / " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "+")
                        {
                            answer2 = answer + thirdNum;
                            Console.WriteLine(firstNum + " + " + secondNum + " + " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "-")
                        {
                            answer2 = answer - thirdNum;
                            Console.WriteLine(firstNum + " + " + secondNum + " - " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }

                    }
                    else if (operation == "-")
                    {
                        answer = firstNum - secondNum;
                        if (operation2 == "x")
                        {
                            answer2 = answer * thirdNum;
                            Console.WriteLine(firstNum + " - " + secondNum + " x " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "/")
                        {
                            answer2 = answer / thirdNum;
                            Console.WriteLine(firstNum + " - " + secondNum + " / " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "+")
                        {
                            answer2 = answer + thirdNum;
                            Console.WriteLine(firstNum + " - " + secondNum + " + " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }
                        else if (operation2 == "-")
                        {
                            answer2 = answer - thirdNum;
                            Console.WriteLine(firstNum + " - " + secondNum + " - " + thirdNum + " = " + answer2);
                            Console.ReadLine();
                        }

                    }

                    else
                    {
                        Console.WriteLine("Sorry that is not correct format! Please restart.");     //Catch

                    }
                }

                else
                {
                    Console.WriteLine("Not a Valid option");
                    Console.ReadLine();
                }

            }
            catch (Exception Ex)
            {

                Console.WriteLine("Woah Sia OS just ran into a issue, here's some details.");
                Console.WriteLine(Ex.ToString());

            }
        }
    }
}