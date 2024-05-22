namespace CompreAqui
{
    class Produto
    {
        public string Nome { get; private set; }
        public double Preco { get; private set; }
        public int Estoque { get; private set; }
        public int Id { get; }
        private static int proximoId = 1;

        public Produto(string nome, double preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Estoque = quantidade;
            Id = proximoId;
            proximoId++;
        }

        public bool VenderProduto(int quantidade)
        {
            Estoque -= quantidade;
            return true;
        }

        public bool CancelarVenda(int quantidade)
        {
            Estoque += quantidade;
            return true;
        }

        public override string ToString()
        {
            return $"{Id}- Nome: {Nome}, Preço: {Preco:c}, Quantidade: {Estoque}";
        }
    }
}