using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie5_LiczbyRzymskie
{
    class Program
    {
        static void Main(string[] args)
        {
            //szyld graficzny
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#");
            Console.WriteLine("#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#");
            Console.WriteLine("#1234567890#IVXLCDM#                                     #1234567890#IVXLCDM#");
            Console.WriteLine("#1234567890#IVXLCDM# ROMAN / ARABIC NUMERALS CONVERTER   #1234567890#IVXLCDM#");
            Console.WriteLine("#1234567890#IVXLCDM#                                     #1234567890#IVXLCDM#");
            Console.WriteLine("#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#1234567890#IVXLCDM#");
            Console.ResetColor();
            // wyjasnic pojecie liczb rzymskich

            Console.WriteLine("\n\n  Roman numerals are a numeral system that originated in ancient Rome" +
                "\n  and remained the usual way of writing numbers throughout Europe\n\t\twell into the Late Middle Ages." +
                "\n  Numbers in this system are represented by combinations of letters\n\t\t from the Latin alphabet." +
                "\n  Modern usage employs seven symbols, each with a fixed integer value:");
            Console.WriteLine("\n\tSymbol : I    V    X    L    C    D    M  ");
            Console.WriteLine("       ---------------------------------------------");
            Console.WriteLine("\tValue  : 1    5    10   50  100  500  1000\n");

            OnceAgainRestart:
            // zapytac czy rzymskie na arabskie czy odwrotnie
            Console.WriteLine("\nConverting Roman Numerals to Arabic  -  press 'R'");
            Console.WriteLine("Converting Arabic Numerals to Roman  -  press 'A'");
            Console.Write("\t\t\t\t\t??? ...");
            OnceAgain1:
            string answer1 = Console.ReadLine().ToLower();
            switch (answer1)
            {
                case "r":
                    break;
                case "a":
                    break;
                default:
                    Console.Write("Converting to (R)oman numerals or to (A)rabic numerals ?" +
                        "\n press 'R' or 'A' ...");
                    goto OnceAgain1;
            }
            if (answer1 == "a")   // konwersja z arabskich na rzymskie
            {
                OnceAgain2:
                Console.Write("\n\tYou can convert arabic number between 1 and 3999" +
                    "\n What number you want to convert to Roman number ? ...");
                bool isParsable = Double.TryParse(Console.ReadLine(), out double givenArabicNumber);
                //sprawdzic czy podane liczby spelniaja kryteria (arabskie 1 do 3999) rzymskie to samo
                if (isParsable && givenArabicNumber >=1 && givenArabicNumber <=3999)
                {
                    Console.Write($"\n  Number {givenArabicNumber} converted to Roman number is :");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\n\t {ArabicToRoman(givenArabicNumber)}\t\t");   // wyswietlic wynik
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    goto OnceAgain2;
                }
            }
            if (answer1 == "r")     // konwersja z rzymskich na arabskie
            {
                OnceAgain3:
                Console.Write("\n\tYou can convert roman number up to MMMCMXCIX (3999)" +
                    "\n What number you want to convert to Arabic number ? ...");
                string givenRomanNumber = Console.ReadLine().ToUpper();
                //sprawdzic czy podane liczby spelniaja kryteria (arabskie 1 do 3999) rzymskie to samo
                if (RomanToArabic(givenRomanNumber) >=1 && RomanToArabic(givenRomanNumber) <= 3999)
                {
                    Console.Write($"\n  Number {givenRomanNumber} converted to Arabic number is :");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"\n\t {RomanToArabic(givenRomanNumber)}\t\t");  // wyswietlic wynik
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    goto OnceAgain3;
                }

            }
            //restart konwertowania
            Console.Write("\n\tWould you like to convert any other numbers ? (Y)es or (N)o ? ...");
            OnceAgain4:
            string answer2 = Console.ReadLine().ToLower();
            if (answer2 == "y")
            {
                goto OnceAgainRestart;
            }
            else if (answer2 == "n")
            {

            }
            else
            {
                Console.Write("Another conversion ? (Y)es or (N)o ? ...");
                goto OnceAgain4;
            }
            //pozegananie
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n--------------------------------------------------------------");
            Console.WriteLine("Thank you for choosing ROMAN / ARABIC NUMERALS CONVERTER !!!  ");
            Console.WriteLine("--------------------------------------------------------------\n\n");
            Console.ResetColor();
   

            Console.ReadLine();
        }


        public static string ArabicToRoman (double givenArabicNumber) // konwersja z arabskich na rzymskie
        {
            string romanNumber = null;
            string numRoman1000_M = null;
            string numRoman500_D = null;
            string numRoman100_C = null;
            string numRoman50_L = null;
            string numRoman10_X = null;
            string numRoman5_V = null;
            string numRoman1_I = null;

            double howManyM = Math.Floor(givenArabicNumber / 1000.0);  // zliczam tysiące

            switch (howManyM)
            {
                case 1:
                    {
                        numRoman1000_M = "M";
                        break;
                    }
                case 2:
                    {
                        numRoman1000_M = "MM";
                        break;
                    }
                case 3:
                    {
                        numRoman1000_M = "MMM";
                        break;
                    }


            }
            givenArabicNumber -= howManyM * 1000;

            if (givenArabicNumber / 1000 >= 0.9 )
            {
                numRoman1000_M += "CM";
                givenArabicNumber -= 900;
            }

            double howManyD = Math.Floor(givenArabicNumber / 500.0); // zliczam pięćsetki
            if (howManyD == 1)
            {
                numRoman500_D = "D";
                givenArabicNumber -= 500;
            }
            else if (givenArabicNumber / 500 >= 0.8)
            {
                numRoman500_D = "CD";
                givenArabicNumber -= 400;
            }


            double howManyC = Math.Floor(givenArabicNumber / 100.0);  // zliczam setki

            switch (howManyC)
            {
                case 1:
                    {
                        numRoman100_C = "C";
                        break;
                    }
                case 2:
                    {
                        numRoman100_C = "CC";
                        break;
                    }
                case 3:
                    {
                        numRoman100_C = "CCC";
                        break;
                    }


            }
            givenArabicNumber -= howManyC * 100;

            if (givenArabicNumber / 100 >= 0.9)
            {
                numRoman100_C += "XC";
                givenArabicNumber -= 90;
            }


            double howManyL = Math.Floor(givenArabicNumber / 50.0); // zliczam pięćdziesiątki
            if (howManyL == 1)
            {
                numRoman50_L = "L";
                givenArabicNumber -= 50;
            }
            else if (givenArabicNumber / 50 >= 0.8)
            {
                numRoman50_L = "XL";
                givenArabicNumber -= 40;
            }


            double howManyX = Math.Floor(givenArabicNumber / 10.0);  // zliczam dziesiątki

            switch (howManyX)
            {
                case 1:
                    {
                        numRoman10_X = "X";
                        break;
                    }
                case 2:
                    {
                        numRoman10_X = "XX";
                        break;
                    }
                case 3:
                    {
                        numRoman10_X = "XXX";
                        break;
                    }


            }
            givenArabicNumber -= howManyX * 10;
            
            if (givenArabicNumber / 10 >= 0.9 )
            {
                numRoman10_X += "IX";
                givenArabicNumber -= 9;
            }

            double howManyV = Math.Floor(givenArabicNumber / 5.0); // zliczam piątki
            if (howManyV == 1)
            {
                numRoman5_V = "V";
                givenArabicNumber -= 5;
            }
            else if (givenArabicNumber / 5 >= 0.8 )
            {
                numRoman5_V = "IV";
                givenArabicNumber -= 4;
            }


            double howManyI = Math.Floor(givenArabicNumber / 1.0);  // zliczam jedności

            switch (howManyI)
            {
                case 1:
                    {
                        numRoman1_I = "I";
                        break;
                    }
                case 2:
                    {
                        numRoman1_I = "II";
                        break;
                    }
                case 3:
                    {
                        numRoman1_I = "III";
                        break;
                    }


            }

            romanNumber = numRoman1000_M + numRoman500_D + numRoman100_C + 
                numRoman50_L + numRoman10_X  + numRoman5_V + numRoman1_I;
            return romanNumber;
        }




        public static int RomanToArabic(string givenRomanNumber) // konwersja z rzymskich na arabskie
        {
            int arabicNumber = 0;
            if (givenRomanNumber[0] == ('M'))          // sprawdzam tysiace
            {
                arabicNumber += 1000;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }

            if (givenRomanNumber.Contains('M') && givenRomanNumber[0] == ('M'))
            {
                arabicNumber += 1000;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('M') && givenRomanNumber[0] == ('M'))
            {
                arabicNumber += 1000;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
             
            if (givenRomanNumber.Contains("CM"))    // sprawdzam 900
            {
                arabicNumber += 900;
                givenRomanNumber = givenRomanNumber.Remove(0, 2);
            }
            

            if (givenRomanNumber.Contains("CD"))                  // sprawdzam 400 i od razu 500
                {
                    arabicNumber += 400;
                    givenRomanNumber = givenRomanNumber.Remove(0, 2);
                }
            else if (givenRomanNumber.Contains("D"))
            {
                arabicNumber += 500;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            

            if (givenRomanNumber.Contains('C') && givenRomanNumber[0] == ('C'))          // sprawdzam setki
            {
                arabicNumber += 100;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('C') && givenRomanNumber[0] == ('C'))
            {
                arabicNumber += 100;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('C') && givenRomanNumber[0] == ('C'))
            {
                arabicNumber += 100;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            
            if (givenRomanNumber.Contains("XC"))     // sprawdzam 90
            {
                arabicNumber += 90;
                givenRomanNumber = givenRomanNumber.Remove(0, 2);
            }
            

            if (givenRomanNumber.Contains("XL"))                  // sprawdzam 40 i od razu 50
            {
                arabicNumber += 40;
                givenRomanNumber = givenRomanNumber.Remove(0, 2);
            }
            else if (givenRomanNumber.Contains("L"))
            {
                arabicNumber += 50;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }


            if (givenRomanNumber.Contains('X') && givenRomanNumber[0] == ('X'))    // sprawdzam dziesiątki
            {
                arabicNumber += 10;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('X') && givenRomanNumber[0] == ('X'))
            {
                arabicNumber += 10;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('X') && givenRomanNumber[0] == ('X'))
            {
                arabicNumber += 10;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            

            if (givenRomanNumber.Contains("IX"))     // sprawdzam 90
            {
                arabicNumber += 9;
                givenRomanNumber = givenRomanNumber.Remove(0, 2);
            }
            

            if (givenRomanNumber.Contains("IV"))                  // sprawdzam 4 i od razu 5
            {
                arabicNumber += 4;
                givenRomanNumber = givenRomanNumber.Remove(0, 2);
            }
            else if (givenRomanNumber.Contains("V"))
            {
                arabicNumber += 5;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }

            if (givenRomanNumber.Contains('I') && givenRomanNumber[0] == ('I'))    // sprawdzam jedności
            {
                arabicNumber += 1;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('I') && givenRomanNumber[0] == ('I'))
            {
                arabicNumber += 1;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
            
            if (givenRomanNumber.Contains('I') && givenRomanNumber[0] == ('I'))
            {
                arabicNumber += 1;
                givenRomanNumber = givenRomanNumber.Remove(0, 1);
            }
          
            return arabicNumber;
        }


    }
}
