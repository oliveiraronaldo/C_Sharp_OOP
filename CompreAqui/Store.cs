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

        public bool CadastrarProduto(string nome, double preco, int quantidade)
        {
            produtos.Add(nome, new Produto(nome, preco, quantidade));
            return true;
        }

        public Cliente? BuscarCliente(string value)
        {
            if (clientes.ContainsKey(value)) return clientes[value];
            else
            {
                foreach (var cliente in clientes.Values)
                {
                    if (cliente.Nome.Contains(value, StringComparison.OrdinalIgnoreCase))
                    {
                        return cliente;
                    }
                }
            }
            return null;
        }

        public Produto? BuscarProduto(int id)
        {

            foreach (var produto in produtos.Values)
            {
                if (produto.Id == id)
                {
                    return produto;
                }
            }
            return null;
        }


    }
}