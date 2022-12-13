using System;

namespace Calculator;

class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Calculadora.Start();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

}

public struct Calculadora
{
    public static decimal memory = 0;
    public static string memoryText = "0";
    public static EOpcoes modo = 0;
    public static void Start()
    {
        Menu();
    }

    public static void Menu()
    {
        Console.Clear();
        Console.WriteLine("************************************************");
        Console.WriteLine("*                  Calculadora                 *");
        Console.WriteLine("* 1 - Soma                                     *");
        Console.WriteLine("* 2 - Subtração                                *");
        Console.WriteLine("* 3 - Multiplicação                            *");
        Console.WriteLine("* 4 - Divisão                                  *");
        Console.WriteLine("* 5 - Sair                                     *");
        Console.WriteLine("*                                              *");
        Console.WriteLine("************************************************");
        Opcoes();
    }

    public static void Opcoes()
    {
        int.TryParse(Console.ReadLine(), out int opcao);

        switch ((EOpcoes)opcao)
        {
            case EOpcoes.Soma:
                {
                    var result = Soma(x: ReadValue("Digite o Primeiro Valor: "), y: ReadValue("Digite o Segundo Valor: "));
                    Resultado(result);
                    break;
                }
            case EOpcoes.Subtracao:
                {
                    var result = Subtracao(x: ReadValue("Digite o Primeiro Valor: "), y: ReadValue("Digite o Segundo Valor: "));
                    Resultado(result);
                    break;
                }
            case EOpcoes.Multiplicacao:
                {
                    var result = Multiplicacao(x: ReadValue("Digite o Primeiro Valor: "), y: ReadValue("Digite o Segundo Valor: "));
                    Resultado(result);
                    break;
                }
            case EOpcoes.Divisao:
                {
                    var result = Divisao(x: ReadValue("Digite o Primeiro Valor: "), y: ReadValue("Digite o Segundo Valor: "));
                    Resultado(result);
                    break;
                }
            case EOpcoes.Sair:
                {
                    System.Environment.Exit(0);
                    break;
                }
            default:
                Menu();
                break;
        }

        Menu();

    }

    public static decimal ReadValue(string msg)
    {
        Console.Write(msg);
        decimal.TryParse(Console.ReadLine(), out decimal value);

        return value;
    }

    public static decimal Soma(decimal x, decimal y)
    {
        var result = x + y;
        return result;
    }
    public static decimal Subtracao(decimal x, decimal y)
    {
        var result = x - y;
        return result;
    }
    public static decimal Multiplicacao(decimal x, decimal y)
    {
        var result = x * y;
        return result;
    }
    public static decimal Divisao(decimal x, decimal y)
    {
        var result = x / y;
        return result;
    }

    public static void Resultado(decimal result)
    {
        Console.WriteLine("************************************************");
        Console.WriteLine($"Resultado: {(decimal.IsInteger(result) ? decimal.Truncate(result) : result)}");
        Console.WriteLine("************************************************");
        Console.ReadKey();
    }
}

public enum EOpcoes
{
    Soma = 1,
    Subtracao = 2,
    Multiplicacao = 3,
    Divisao = 4,
    Sair = 5,
};