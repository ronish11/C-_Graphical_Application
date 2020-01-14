using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Csharp_graphical_application
{
    class Validation1
    {
        private RichTextBox txtCommand;
        public Boolean isValidCommand = true;
        public Boolean isSomethingInvalid = false;
        public int Raduis = 0;
        public int Width = 0;
        public int Height = 0;
        public int counter = 0;
        public int LoopCounter = 0;
        public int lineNumber = 0;

        public Boolean hasLoop = false;
        public Boolean hasEndLoop = false;
        public Boolean hasIf = false;
        public Boolean hasEndif = false;

        public int loopLineNo = 0, endLoopLineNo = 0, ifLineNo = 0, endIfLineNo = 0;
        private RichTextBox multiline;

        public Validation1(RichTextBox txtCommand)
        {
            this.txtCommand = txtCommand;

            int numberOfLines = txtCommand.Lines.Length;
            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    checkLineValidation(oneLineCommand);
                    lineNumber = (i + 1);
                    if (!isValidCommand)
                    {
                        MessageBox.Show("Error in line " + lineNumber);
                        isValidCommand = true;
                    }
                }

            }
            checkLoopAndIfValidation();
            if (!isValidCommand)
            {
                isSomethingInvalid = true;
            }
        }

        //public Validation1(RichTextBox multiline)
        //{
        //    this.multiline = multiline;
        //}

        /// <summary>
        /// function to check loop and if validation
        /// </summary>
        public void checkLoopAndIfValidation()
        {
            int numberOfLines = txtCommand.Lines.Length;


            for (int i = 0; i < numberOfLines; i++)
            {
                String oneLineCommand = txtCommand.Lines[i];
                oneLineCommand = oneLineCommand.Trim();
                if (!oneLineCommand.Equals(""))
                {
                    hasLoop = Regex.IsMatch(oneLineCommand.ToLower(), @"\bloop\b");
                    if (hasLoop)
                    {
                        loopLineNo = (i + 1);
                    }
                    hasEndLoop = oneLineCommand.ToLower().Contains("endloop");
                    if (hasEndLoop)
                    {
                        endLoopLineNo = (i + 1);
                    }
                    hasIf = Regex.IsMatch(oneLineCommand.ToLower(), @"\bif\b");
                    if (hasIf)
                    {
                        ifLineNo = (i + 1);
                    }
                    hasEndif = oneLineCommand.ToLower().Contains("endif");
                    if (hasEndif)
                    {
                        endIfLineNo = (i + 1);
                    }
                }
            }
            if (loopLineNo > 0)
            {
                hasLoop = true;
            }
            if (endLoopLineNo > 0)
            {
                hasEndLoop = true;
            }
            if (ifLineNo > 0)
            {
                hasIf = true;
            }
            if (endIfLineNo > 0)
            {
                hasEndif = true;
            }
            if (hasLoop)
            {
                if (hasEndLoop)
                {
                    if (loopLineNo < endLoopLineNo)
                    {

                    }
                    else
                    {
                        isValidCommand = false;
                        MessageBox.Show("'ENDLOOP' must be after loop start");
                    }
                }
                else
                {
                    isValidCommand = false;
                    MessageBox.Show("Loop Not Ended with 'ENDLOOP'");
                }
            }
            if (hasIf)
            {
                if (hasEndif)
                {
                    if (ifLineNo < endIfLineNo)
                    {

                    }
                    else
                    {
                        isValidCommand = false;
                        MessageBox.Show("'ENDIF' must be after IF");
                    }
                }
                else
                {
                    isValidCommand = false;
                    MessageBox.Show("IF Not Ended with 'ENDIF'");
                }
            }
        }

        public void checkLineValidation(string lineOfCommand)
        {
            String[] keyword = { "circle", "rectangle", "triangle", "polygon", "drawto", "moveto", "repeat", "if", "endif", "loop", "endloop" };
            String[] shapes = { "circle", "rectangle", "triangle", "polygon" };
            String[] variable = { "radius", "width", "height", "counter", "size" };
            lineOfCommand = Regex.Replace(lineOfCommand, @"\s+", " ");
            string[] words = lineOfCommand.Split(' ');
            //removing white spaces in between words
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim();
            }
            String firstWord = words[0].ToLower();
            Boolean firstWordIsKeyword = keyword.Contains(firstWord);
            if (firstWordIsKeyword)
            {
                Boolean firstWordIsShape = shapes.Contains(words[0].ToLower());
                if (firstWordIsShape)
                {
                    if (words[0].ToLower().Equals("circle"))
                    {
                        if (words.Length == 2)
                        {
                            Boolean isInt = words[1].All(char.IsDigit);
                            if (!isInt)
                            {
                                //if it isnot variable then invalid
                                Boolean isVariable = variable.Contains(words[1].ToLower());
                                if (isVariable)
                                {
                                    checkIfVariableDefined(words[1]);
                                }
                                else
                                {
                                    isValidCommand = false;
                                }
                                //throw new NonDigitValueException("The value is not numerical \r\n It is not an error but just showing custom made exception.");

                            }
                        }
                        else
                        {
                            isValidCommand = false;
                        }
                    }
                    else if (words[0].ToLower().Equals("rectangle"))
                    {
                        String args = lineOfCommand.Substring(9, (lineOfCommand.Length - 9));
                        String[] parms = args.Split(',');

                        if (parms.Length == 2)
                        {
                            Boolean isInt = false;
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                                isInt = parms[i].All(char.IsDigit);
                                if (!isInt)
                                {
                                    //if it isnot variable then invalid
                                    Boolean isVariable = variable.Contains(parms[i].ToLower());
                                    if (!isVariable)
                                    {
                                        isValidCommand = false;
                                    }
                                }
                            }
                        }
                        else
                        {
                            isValidCommand = false;
                        }
                    }
                    else if (words[0].ToLower().Equals("triangle"))
                    {
                        String args = lineOfCommand.Substring(8, (lineOfCommand.Length - 8));
                        String[] parms = args.Split(',');

                        if (parms.Length == 3)
                        {
                            Boolean isInt = false;
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                                isInt = parms[i].All(char.IsDigit);
                                if (!isInt)
                                {
                                    isValidCommand = false;
                                }
                            }
                        }
                        else
                        {
                            isValidCommand = false;
                        }
                    }
                    else if (words[0].ToLower().Equals("polygon"))
                    {
                        String args = lineOfCommand.Substring(7, (lineOfCommand.Length - 7));
                        String[] parms = args.Split(',');

                        if (parms.Length == 8 || parms.Length == 10)
                        {
                            Boolean isInt = false;
                            for (int i = 0; i < parms.Length; i++)
                            {
                                parms[i] = parms[i].Trim();
                                isInt = parms[i].All(char.IsDigit);
                                if (!isInt)
                                {
                                    isValidCommand = false;
                                }
                            }
                        }
                        else
                        {
                            isValidCommand = false;
                        }
                    }
                    else { }
                }
                else if (firstWord.Equals("loop"))
                {
                    if (words.Length == 2)
                    {
                        Boolean isInt = words[1].All(char.IsDigit);
                        if (!isInt)
                        {
                            isValidCommand = false;
                        }
                    }
                    else
                    {
                        isValidCommand = false;
                    }
                }
                else if (firstWord.Equals("end"))
                {
                    if (words.Length == 2)
                    {
                        if (!words[1].Equals("loop"))
                        {
                            isValidCommand = false;
                        }
                    }
                    else
                    {
                        isValidCommand = false;
                    }
                }
                else if (firstWord.Equals("repeat"))
                {
                    if (words.Length >= 4 && words.Length <= 6)
                    {
                        Boolean isInt = words[1].All(char.IsDigit);
                        if (isInt)
                        {
                            if (shapes.Contains(words[2].ToLower()))
                            {

                                Boolean hasPlus = words[3].Contains('+');
                                if (hasPlus)
                                {
                                    string[] words2 = words[3].Split('+');
                                    for (int i = 0; i < words2.Length; i++)
                                    {
                                        words2[i] = words2[i].Trim();
                                    }
                                    Boolean firstWordIsVariable = variable.Contains(words2[0].ToLower());
                                    if (!firstWordIsVariable)
                                    {
                                        isValidCommand = false;
                                    }
                                    else
                                    {
                                        if (words2.Length != 2)
                                        {
                                            isValidCommand = false;
                                        }
                                        else
                                        {
                                            //third char should be int to be valid
                                            Boolean isInt2 = words2[1].All(char.IsDigit);
                                            if (!isInt2)
                                            {
                                                isValidCommand = false;
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (variable.Contains(words[3].ToLower()))
                                    {
                                        if (words[4].Trim().Equals("+"))
                                        {
                                            Boolean isInt3 = words[5].All(char.IsDigit);
                                            if (!isInt3)
                                            {
                                                isValidCommand = false;
                                            }
                                        }
                                        else
                                        {
                                            Boolean hasPlus2 = words[4].Contains('+');
                                            if (hasPlus2)
                                            {
                                                string[] words2 = words[4].Split('+');
                                                for (int i = 0; i < words2.Length; i++)
                                                {
                                                    words2[i] = words2[i].Trim();
                                                }
                                                if (words2.Length == 2)
                                                {
                                                    Boolean isInt2 = words2[1].All(char.IsDigit);
                                                    if (!isInt2)
                                                    {
                                                        isValidCommand = false;
                                                    }
                                                }
                                                else
                                                {
                                                    isValidCommand = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        isValidCommand = false;
                    }
                }
                else if (firstWord.Equals("if"))
                {
                    if (words.Length == 5)
                    {
                        if (variable.Contains(words[1].ToLower()))
                        {
                            if (words[2].Equals("="))
                            {
                                Boolean isInt = words[3].All(char.IsDigit);
                                if (isInt)
                                {
                                    if (words[4].ToLower().Equals("then"))
                                    {

                                    }
                                    else { isValidCommand = false; }
                                }
                                else { isValidCommand = false; }

                            }
                            else { isValidCommand = false; }
                        }
                        else { isValidCommand = false; }

                    }
                    else
                    {
                        isValidCommand = false;
                    }

                }
                else if (firstWord.Equals("endif"))
                {
                    if (words.Length != 1)
                    {
                        isValidCommand = false;
                    }
                }
                else if (firstWord.Equals("drawto") || firstWord.Equals("moveto"))
                {
                    String args = lineOfCommand.Substring(6, (lineOfCommand.Length - 6));
                    String[] parms = args.Split(',');

                    if (parms.Length == 2)
                    {
                        Boolean isInt = false;
                        for (int i = 0; i < parms.Length; i++)
                        {
                            parms[i] = parms[i].Trim();
                            isInt = parms[i].All(char.IsDigit);
                            if (!isInt)
                            {
                                isValidCommand = false;
                            }
                        }
                    }
                    else
                    {
                        isValidCommand = false;
                    }
                }
            }
            else
            {
                Boolean hasPlus = lineOfCommand.Contains('+');
                Boolean hasEquals = lineOfCommand.Contains("=");
                if (!hasEquals && !hasPlus)
                {
                    isValidCommand = false;
                }
                else
                {
                    if (hasEquals)
                    {
                        string[] words2 = lineOfCommand.Split('=');
                        for (int i = 0; i < words2.Length; i++)
                        {
                            words2[i] = words2[i].Trim();
                        }
                        Boolean firstWordIsVariable = variable.Contains(words2[0].ToLower());
                        if (!firstWordIsVariable)
                        {
                            isValidCommand = false;
                        }
                        else
                        {
                            if (words2.Length != 2)
                            {
                                isValidCommand = false;
                            }
                            else
                            {
                                //third char should be int to be valid                        
                                Boolean isInt = words2[1].All(char.IsDigit);
                                if (!isInt)
                                {
                                    isValidCommand = false;
                                }
                            }
                        }

                    }
                    if (hasPlus)
                    {
                        string[] words2 = lineOfCommand.Split('+');
                        for (int i = 0; i < words2.Length; i++)
                        {
                            words2[i] = words2[i].Trim();
                        }
                        Boolean firstWordIsVariable = variable.Contains(words2[0].ToLower());
                        if (!firstWordIsVariable)
                        {
                            isValidCommand = false;
                        }
                        else
                        {
                            if (words2.Length != 2)
                            {
                                isValidCommand = false;
                            }
                            else
                            {
                                //third char should be int to be valid
                                Boolean isInt = words2[1].All(char.IsDigit);
                                if (!isInt)
                                {
                                    isValidCommand = false;
                                }
                            }
                        }

                    }
                }
            }
            if (!isValidCommand)
            {
                isSomethingInvalid = true;
            }

        }
        /// <summary>
        /// to check if the variable is defined or not
        /// </summary>
        /// <param name="variable"></param>
        public void checkIfVariableDefined(string variable)
        {
            Boolean isVaraibleFound = false;
            if (txtCommand.Lines.Length > 1)
            {
                if (lineNumber > 0)
                {
                    for (int i = 0; i < lineNumber; i++)
                    {
                        String oneLineCommand = txtCommand.Lines[i];
                        oneLineCommand = oneLineCommand.Trim();
                        if (!oneLineCommand.Equals(""))
                        {
                            Boolean isVariableDefined = oneLineCommand.ToLower().Contains(variable.ToLower());
                            if (isVariableDefined)
                            {
                                isVaraibleFound = true;
                            }
                        }

                    }
                    if (!isVaraibleFound)
                    {
                        MessageBox.Show("Variable is not defined");
                        isValidCommand = false;
                    }
                }
                else
                {
                    MessageBox.Show("Variable is not defined");
                    isValidCommand = false;
                }

            }
            else
            {
                MessageBox.Show("Varaible is not defined");
                isValidCommand = false;
            }
        }
    }
}
