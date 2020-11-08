namespace TheUltimateCalculator
{
    class Program
    {
        public static bool inEnglish = false;
        public static string[] Dictionary = new string[10];
        public static int aa = 0;
        static void Main(string[] args)
        {
            Dictionary[0] = "Bienvenido a 'The Ultimate calculator', la última calculadora que vas a necesitar";
            Dictionary[1] = "Welcome to 'The ultimate calculator', the last calculator you will need";
            string[] SpanishDictionary = new string[10];


            Console.Title = "The Ultimate Calculator";
            //Console.ForegroundColor = ConsoleColor.Blue;
            MainMenu();
        }
        static void MainMenu() //Interfaz principal
        {
            if (Program.inEnglish == true)
            {
                aa = 1;
            }
            else
            {
                aa = 0;
            }
            Console.WriteLine(Dictionary[0 + aa]);
            Console.WriteLine(aa);
            //Print("Bienvenido a 'The Ultimate calculator', la última calculadora que vas a necesitar");
            Print("[1] Operaciones básicas");
            Print("[2] Teorema de pitágoras");
            Print("[3] No implementado");
            Print("[4] Opciones");
            Selector();

            static void Selector() //Opcion de interfaz
            {
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.Clear();
                        BasicOperator();
                        break;

                    case "2":
                        Console.Clear();
                        Print("Usted eligió 2");
                        break;

                    case "3":
                        Console.Clear();
                        Print("Usted eligió 3");
                        break;

                    case "4":
                        Console.Clear();
                        OptionsMenu();
                        break;

                    default:
                        Console.Clear();
                        MainMenu();
                        Print("No se reconoció la respuesta");
                        break;
                }
            }
        }
        static void BasicOperator() // [1]
        {
            bool onMethod = true;
            Print("--Operaciones básicas--");
            /*Print("[+] Suma");
            Print("[-] Resta");
            Print("[/] División");
            Print("[*] Multiplicación");*/
            Print("[back] Volver al menú");
            do
            {
                var input = Console.ReadLine();
                ConsoleCommands(input);
                decimal firstNumber;
                char logicOperator; // + - / * //char
                decimal secondNumber;

                if (Decimal.TryParse(input, out firstNumber)) //Si pones un valor numerico
                {
                    Print("The first number is ", Convert.ToString(firstNumber));

                    var logicOperatorTEMP = Console.ReadLine(); //var logicOperatorTEMP = Convert.ToChar(Console.ReadLine());
                    if (Char.TryParse(logicOperatorTEMP, out logicOperator))
                    {
                        ConsoleCommands(Convert.ToString(logicOperator));
                        Print("The operator is ", Convert.ToString(logicOperator));

                        secondNumber = Convert.ToDecimal(Console.ReadLine());
                        ConsoleCommands(Convert.ToString(logicOperator));
                        Print("The second number is ", Convert.ToString(secondNumber));

                        MathOperation(ref firstNumber, logicOperator, ref secondNumber);
                        Console.WriteLine("La respuesta es " + MathOperation(ref firstNumber, logicOperator, ref secondNumber));
                    }
                    else
                    {
                        Print("Error");
                    }
                }
                else
                {
                    Print("No se reconoció el comando");
                }
            } while (onMethod);

            void ConsoleCommands(string input) // back - clear
            {
                if (input.ToLower() == "back") //Si escribes "back"
                {
                    Console.Clear();
                    onMethod = false;
                    MainMenu();
                }
                else if (input.ToLower() == "clear")
                {
                    Console.Clear();
                    BasicOperator();
                }
                else{return;}
            } 
        }

        static decimal MathOperation(ref decimal firstNumber, char logicOperator, ref decimal secondNumber)
        {
            if (logicOperator == '+')
            {
                return firstNumber + secondNumber;
            }
            else if (logicOperator == '-')
            {
                return firstNumber - secondNumber;
            }
            else if (logicOperator == '/')
            {
                return firstNumber / secondNumber;
            }
            else if (logicOperator == '*')
            {
                return firstNumber * secondNumber;
            }
            else
            {
                return firstNumber;
            }
        }

        static void OptionsMenu()
        {
            Print("Usted se encuentra en las opciones");
            Print("[1] Cambiar idioma");
            Print("");
            Print("");
            Selector();

            static void Selector()
            {
                var input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Print("[1] English");
                        Print("[2] Español");
                        var languageInput = Convert.ToInt32(Console.ReadLine());
                        switch (languageInput)
                        {
                            case 1:
                                Program.inEnglish = true;
                                Console.Clear();
                                MainMenu();
                                break;
                            case 2:
                                Program.inEnglish = false;
                                Console.Clear();
                                MainMenu();
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        Print("Codigo no reconocido");
                        break;
                }
            }
        }

        static void Print(string text, string extraText = "") // Para pintar valores
        {
            Console.WriteLine(text + extraText);
        }

    }
}
