using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace oppgaver
{
    internal class Oppgave315I: IOppgaver
    {
        //private int minimumCharacters = 14;
        //private int minimunCapitalCharacter = 1;
        //private int minimumSpecialCharacter = 1;
        //private int minimumSmallCharcater = 4;
        //private int minimumNumberCharcater = 1;
        string generatedPassword = string.Empty;
        private (int start, int end) _numberCharacterStartAndEnd = (start:48, end:58);
        private (int start, int end) _specialCharacterStartAndEnd = (start: 33, end: 48);
        private (int start, int end) _smallCharacterStartAndEnd = (start: 97, end: 123);
        private (int start, int end) _capitalCharacterStartAndEnd = (start: 65, end: 91);
        private (int start, int end) _randomCharacterStartAndEnd = (start: 33, end: 127);


        public void Run()
        {
            int passwordLength = UserInputConverter("Enter number of characters for random password: ");
            int minCapitalChar = UserInputConverter("Enter minimum number of required capital characters: ");
            int minSpecialChar = UserInputConverter("Enter minimum number of required special characters: ");
            int minSmallChar = UserInputConverter("Enter minimum number of required small characters: ");
            int minNumberChar = UserInputConverter("Enter minimum number of required numeric characters: ");
            int totalRequiredCharacters = minNumberChar + minCapitalChar + minSmallChar + minSpecialChar;
            if (passwordLength > totalRequiredCharacters)
            {
                RandomPasswordGenerator(passwordLength, minCapitalChar, minSpecialChar, minSmallChar, minNumberChar);
            }
            else
            {
                RandomPasswordGenerator(totalRequiredCharacters, minCapitalChar, minSpecialChar, minSmallChar, minNumberChar);
            }
        }

        public void RandomPasswordGenerator(int minPassLength, int minCapitalChar,
            int minSpecialChar, int minSmallChar, int minNumChar)
        {
            int nonRequiredCharacters = minPassLength - minCapitalChar - minSpecialChar - minSmallChar - minNumChar;

            CharacterGenerator(minCapitalChar, _capitalCharacterStartAndEnd.start, _capitalCharacterStartAndEnd.end);
            CharacterGenerator(minSpecialChar, _specialCharacterStartAndEnd.start, _specialCharacterStartAndEnd.end);
            CharacterGenerator(minSmallChar, _smallCharacterStartAndEnd.start, _smallCharacterStartAndEnd.end);
            CharacterGenerator(minNumChar, _numberCharacterStartAndEnd.start, _numberCharacterStartAndEnd.end);
            CharacterGenerator(nonRequiredCharacters, _randomCharacterStartAndEnd.start, _randomCharacterStartAndEnd.end);
            

            Console.WriteLine(generatedPassword);
            Console.WriteLine(ShuffleStr(generatedPassword));
        }

        public void CharacterGenerator(int numberOfCharacters, int start, int end)
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Random random = new Random();
                int randomNumber = random.Next(start,end);
                generatedPassword += (char)randomNumber;
            }
        }

        //public void SpecialCharacterGenerator(int numberOfCharacters)
        //{
        //    for (int i = 0; i < numberOfCharacters; i++)
        //    {
        //        Random random = new Random();
        //        int randomNumber = random.Next(33, 48);
        //        generatedPassword += (char)randomNumber;
        //    }
        //}

        //public void SmallCharacterGenerator(int numberOfCharacters)
        //{
        //    for (int i = 0; i < numberOfCharacters; i++)
        //    {
        //        Random random = new Random();
        //        int randomNumber = random.Next(97, 123);
        //        generatedPassword += (char)randomNumber;
        //    }
        //}

        //public void CapitalCharacterGenerator(int numberOfCharacters)
        //{
        //    for (int i = 0; i < numberOfCharacters; i++)
        //    {
        //        Random random = new Random();
        //        int randomNumber = random.Next(65, 91);
        //        generatedPassword += (char)randomNumber;
        //    }
        //}

        //public void RandomCharacterGenerator(int numberOfCharacters)
        //{
        //    for (int i = 0; i < numberOfCharacters; i++)
        //    {
        //        Random random = new Random();
        //        int randomNumber = random.Next(33, 127);
        //        generatedPassword += (char)randomNumber;
        //    }
        //}

        public string ShuffleStr(string str)
        {
            Random randomIndex = new Random();
            string shuffledStr = new string(new string(str.OrderBy(_ => randomIndex.Next()).ToArray()));
            return shuffledStr;
        }

        public int UserInputConverter(string str)
        {
            Console.Write(str);
            string stringInput = Console.ReadLine();
            int intInput = Convert.ToInt32(stringInput);
            return intInput;
        }

    }
}
