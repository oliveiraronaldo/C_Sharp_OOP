using System.Text;

namespace CompreAqui
{
    class Store
    {
        private Dictionary<string, Cliente> clientes = new Dictionary<string, Cliente>();
        private Dictionary<string, Produto> produtos = new Dictionary<string, Produto>();
        public void CadastrarCliente(string nome, string email, string cpf, string endereco)
        {
            clientes.Add(cpf, new Cliente(nome, email, cpf, endereco));
        }

        public void CadastrarProduto(string nome, double preco, int quantidade)
        {
            produtos.Add(nome, new Produto(nome, preco, quantidade));
        }

        public string BuscarCliente(string value)
        {
            if (clientes.ContainsKey(value)) return clientes[value].ToString();
            else
            {
                foreach (var key in clientes.Keys)
                {
                    if (clientes[key].Nome.Contains(value, StringComparison.OrdinalIgnoreCase))
                    {
                        return clientes[key].ToString();
                    }
                }
            }
            return "Cliente não Encontrado";
        }

        public string BuscarProduto(string value)
        {
            if (produtos.ContainsKey(value)) return produtos[value].ToString();
            else
            {
                foreach (var key in produtos.Keys)
                {
                    if (produtos[key].Nome.Contains(value, StringComparison.OrdinalIgnoreCase))
                    {
                        return produtos[key].ToString();
                    }
                }
            }

            return "Produto não encontrado";
        }


    }
}