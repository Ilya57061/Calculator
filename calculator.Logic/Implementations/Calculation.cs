
namespace Calculator.Logic.Implementations
{
    public class Calculation
    {
        public string ProcessStatement(string unary, string statement)
        {
            try
            {
                string result = CalculateStatement(GetOperantA(unary, statement), GetOperantB(statement), GetOperation(statement));
                if (result.Length > 9)
                {
                    return "EXCEEDED";
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {

                return "0";
            }

        }
        string GetOperantA(string unary, string statement)
        {

            string[] a = statement.Split('+', '-', '/', '*');
            return unary + a[0];

        }
        string GetOperantB(string statament)
        {
            string[] b = statament.Split('+', '-', '/', '*');
            return b[1];
        }

        string GetOperation(string statament)
        {
            string[] a = statament.Split('+', '-', '/', '*');
            string b = statament.Substring(a[0].Length, 1);
            return b;
        }
        string CalculateStatement(string operantOne, string operantTwo, string operation)
        {
            switch (operation)
            {
                //тут будет выполнено сложение
                case "+":
                    return Sum(operantOne, operantTwo);
                //тут будет выполнено вычитание
                case "-":
                    return Subtract(operantOne, operantTwo);
                //тут будет выполнено умножение
                case "*":
                    return Multiple(operantOne, operantTwo);
                //тут будет выполнено деление
                case "/":
                    return Divide(operantOne, operantTwo);
                default:
                    return "Такой операции не существует";
            }
        }
        string Sum(string operandOne, string operandTwo)
        {
            return (int.Parse(operandOne) + int.Parse(operandTwo)).ToString();
        }
        string Multiple(string operandOne, string operandTwo)
        {
            return (int.Parse(operandOne) * int.Parse(operandTwo)).ToString();
        }
        string Subtract(string operandOne, string operandTwo)
        {
            return (int.Parse(operandOne) - int.Parse(operandTwo)).ToString();
        }
        string Divide(string operandOne, string operandTwo)
        {
            if (operandOne == "0" || operandTwo == "0")
            {
                return "NOT ÷ 0";
            }
            else
            {
                return (int.Parse(operandOne) / int.Parse(operandTwo)).ToString();
            }
        }

    }
}
