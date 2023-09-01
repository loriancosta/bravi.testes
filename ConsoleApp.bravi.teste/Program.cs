
class Program
{

    static void Main(string[] args)
    {
        Console.WriteLine("VALIDA APENAS OS COLCHETES DA STRING, NÃO ADIANTA COLOCAR OUTRO TIPO DE CARACTER POIS SERÁ IGNORADO\n");
        string instrucoes =
                    "Uso uma pilha para rastrear os colchetes abertos.\n" +
                    "Quando encontro um colchete aberto, empilho.\n" +
                    "Quando encontro um colchete fechado, verifico se ele corresponde ao colchete no topo da pilha.\n" +
                    "Se correspondem, desempilho o colchete aberto.\n" +
                    "Se não correspondem ou a pilha estiver vazia, a sequência não é válida.\n" +
                    "Ao final, se a pilha estiver vazia, a sequência é válida.";

        Console.WriteLine(instrucoes + "\n");
        //
        Console.WriteLine("RESULTADOS ENCONTRADOS\n");
        Console.WriteLine(tradutor("()"));
        Console.WriteLine(tradutor("{[()]}"));
        Console.WriteLine(tradutor("{[(])}"));
        Console.WriteLine(tradutor("["));
    }

    static string tradutor(string s)
    {
        //var teste = IsColchetesValidos(s);
        var teste = IsSuportesBalanceados(s);
        return teste
            ? $"{s.PadRight(8)} é válido."
            : $"{s.PadRight(8)} não é válido.";
    }


    /// <summary>
    /// Uso uma pilha para rastrear os colchetes abertos.
    /// Quando encontro um colchete aberto, empilho.
    /// Quando encontro um colchete fechado, verifico se ele corresponde ao colchete no topo da pilha.
    /// Se correspondem, desempilho o colchete aberto.
    /// Se não correspondem ou a pilha estiver vazia, a sequência não é válida.
    /// Ao final, se a pilha estiver vazia, a sequência é válida.
    /// </summary>
    /// <param name="item">String de colchetes</param>
    /// <returns>Frase de validação</returns>
    static bool IsColchetesValidos(string item)
    {
        Stack<char> pilha = new Stack<char>();

        Dictionary<char, char> colchetesValidos = new Dictionary<char, char> { { '(', ')' }, { '{', '}' }, { '[', ']' } };

        foreach (char caractere in item)
        {
            
            if (colchetesValidos.ContainsKey(caractere)) // É um key?
                pilha.Push(caractere);
            else if (colchetesValidos.ContainsValue(caractere)) // É um value?
            {
                if (pilha.Count == 0)
                    return false;

                char desempilhado = pilha.Pop();
                if (colchetesValidos[desempilhado] != caractere)
                    return false;
            }
        }

        return pilha.Count == 0;
    }


    static bool IsSuportesBalanceados(string s)
    {
        int aparentesesAbre = 0;
        int parenteseFecha = 0;
        int chaveAbre = 0;
        int chaveFecha = 0;
        int colcheteAbre = 0;
        int colcheteFecha = 0;

        foreach (char c in s)
        {
            switch (c)
            {
                case '(': aparentesesAbre++; break;
                case ')': parenteseFecha++; break;
                case '{': chaveAbre++; break;
                case '}': chaveFecha++; break;
                case '[': colcheteAbre++; break; 
                case ']': colcheteFecha++; break;
                default: break;
            }

            if (parenteseFecha > aparentesesAbre || chaveFecha > chaveAbre || colcheteFecha > colcheteAbre)
                return false;
        }

        return aparentesesAbre == parenteseFecha && chaveAbre == chaveFecha && colcheteAbre == colcheteFecha;
    }
}