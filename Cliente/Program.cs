// See https://aka.ms/new-console-template for more information
using Cliente;

Console.Clear();
var cliente = new Client("Ronaldo", "Rua 2", "12654856584", 26);

List<Client> Lista = new List<Client>{
    new Client("Ronaldo", "Rua 2", "12654856584", 26),
    new Client("Ronaldo", "Rua 2", "12654856584", 26),
    new Client("Ronaldo", "Rua 2", "12654856584", 26),
    new Client("Ronaldo", "Rua 2", "12654856584", 26),
    new Client("Ronaldo", "Rua 2", "12654856584", 26)
};

string retornar()
{
    return $"[{Lista.ForEach}]";
}

Console.WriteLine(retornar);