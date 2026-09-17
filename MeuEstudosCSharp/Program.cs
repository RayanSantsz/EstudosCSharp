//variaveis
string prato = "macarrão";
decimal preco = 60.90m;
bool pedidoEntregue = false;

Console.Write($"Prato: {prato}, valor: {preco}, Foi entregue: {pedidoEntregue}");

// metodos
// parametros: o que sera passado dentro dos parenteses para o metodo funcionar
// retorno ↓
// return -> devolve algo pronto
// void -> faz algo sem devolver nada pra quem chamou
void ExibirPedido(string prato, decimal preco)
{
    Console.WriteLine($"Prato: {prato}, Preco: {preco}");
}

decimal soma(decimal preco, int quantidade)
{
    decimal valor = preco * quantidade;
    return valor;
}

ExibirPedido(prato, preco);
Console.WriteLine($"Valor: {soma(preco, 10)}");

/*
operadores e comparação: 
==	igual a
!=	diferente de
> , <	maior que, menor que
>= , <=	maior ou igual, menor ou igual
&&	"e" (as duas condições precisam ser verdadeiras)
||	"ou" (pelo menos uma precisa ser verdadeira)  
*/
void verificarPedido (decimal preco, bool pedidoEntregue)
{
    if (!pedidoEntregue && preco > 50)
    {
        Console.WriteLine("Pedido de alto valor, priorizar entrega");
    }
    else if (pedidoEntregue)
    {
        Console.WriteLine("Pedido entregue");
    }
    else
    {
        Console.WriteLine("Pedido em andamento");
    }
}

verificarPedido(preco, pedidoEntregue);

// arrays e list<t>
/*
list<t>:
.Add(item) — adiciona um item no fim
.Remove(item) — remove um item específico
.Count — quantos itens tem na lista (repare: é uma propriedade, sem parênteses — não é .Count())
*/
string[] pratos = { "Macarrão", "Parmegiana", "Lasanha" };
List<string> prats = new List<string>();
prats.Add("Macarrao");
prats.Add("frango");
prats.Add("lasanha");
Console.WriteLine(prats.Count);
foreach (var item in prats)
{
    Console.WriteLine(item);
}

// orientação a objetos 1: classes,objetos, construtores, encapsulamento
/*
classe:
class NomeDaClasse
{
    // propriedades (características)
    // construtor (como o objeto nasce)
    // métodos (o que o objeto sabe fazer)
}
*/

Pedido pedido = new Pedido("Pizza", 30.0m);
pedido.Apresentar();
PratoEspecial pratoEspecial = new PratoEspecial("Macarrao", 30.0m, "Rayan");
pratoEspecial.Apresentar();
public class Pedido
{
    public string Prato { get; private set; }
    public decimal Preco { get; private set; }

    public Pedido (string prato, decimal preco)
    {
        if (preco < 0)
        {
            throw new Exception("O preço é menor que zero");
        }

        Prato = prato;
        Preco = preco;

    }
    
    public virtual void Apresentar ()
    {
        Console.WriteLine($"Pedido: {Prato}, R${Preco}");
    }
}


//orientação 2: herança, polimorfismo, interfaces
public class PratoEspecial : Pedido
{   
    public string Chefe {  get; private set; }
    public PratoEspecial(string prato, decimal preco, string chef) : base (prato, preco)
    {
        Chefe = chef;
    }

    public override void Apresentar()
    {
        base.Apresentar();
        Console.Write($"Chefe: {Chefe}");
    }
}

// polimorfismo com virtaul/override
// virtual -> na classe mãe, marca um método como "pode ser reescrito pelas filhas, se elas quiserem".
// override -> na classe filha, diz "estou reescrevendo esse método específico que a mãe deixou aberto".