namespace CompreAqui
{
    class Produto
    {
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override string ToString()
        {
            return $"[Nome: {Nome}, Preço: {Preco}, Quantidade: {Quantidade}]";
        }
    }
}