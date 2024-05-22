
using System.Text;

namespace CompreAqui
{
    class Cliente
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public string Endereco { get; private set; }
        public Carrinho Carrinho { get; }

        public Cliente(string nome, string email, string cpf, string endereco)
        {
            Nome = nome;
            Email = email;
            Cpf = cpf;
            Endereco = endereco;
            Carrinho = new Carrinho(this);
        }


        public bool AdicionarProduto(Produto produto, int quantidade)
        {
            var produtoAdicionado = Carrinho.AdicionarProduto(produto, quantidade);
            return produtoAdicionado;
        }

        public bool ExcluirProduto(int id)
        {
            var produtoExcluido = Carrinho.RemoverProduto(id);
            return produtoExcluido;
        }

        public override string ToString()
        {
            Console.Clear();
            return $"Nome: {Nome} \nEmail: {Email} \nCpf: {Cpf} \nEndereço: {Endereco}";
        }
    }
}