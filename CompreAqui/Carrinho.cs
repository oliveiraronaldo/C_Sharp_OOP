using System.Reflection.Metadata;
using System.Text;

namespace CompreAqui
{
    class Carrinho
    {
        public Cliente Cliente { get; }
        Dictionary<Produto, int> ListaProdutos = new Dictionary<Produto, int>();
        public double Valor { get; private set; } = 0;

        public Carrinho(Cliente cliente)
        {
            Cliente = cliente;
        }

        public bool AdicionarProduto(Produto produto, int quantidade)
        {
            if (produto.Estoque >= quantidade)
            {

                if (ListaProdutos.ContainsKey(produto))
                {
                    ListaProdutos[produto] += quantidade;
                    produto.VenderProduto(quantidade);
                    Valor += produto.Preco * quantidade;
                    return true;
                }
                else
                {
                    ListaProdutos.Add(produto, quantidade);
                    produto.VenderProduto(quantidade);
                    Valor += produto.Preco * quantidade;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool RemoverProduto(int id)
        {
            Produto? produto = null;
            int quantidade;
            var produtos = ListaProdutos.Keys;
            foreach (var prod in produtos)
            {
                if (prod.Id == id)
                {
                    produto = prod;
                }
            }
            if (produto != null)
            {
                quantidade = ListaProdutos[produto];
                produto.CancelarVenda(quantidade);
                ListaProdutos.Remove(produto);
                return true;
            }
            return false;
        }

        public bool CarrinhoVazio()
        {
            if (ListaProdutos.Count() == 0) return true;
            else return false;
        }

        public override string ToString()
        {
            if (CarrinhoVazio())
            {
                return "====================== Carrinho Vazio ======================";
            }
            else
            {
                var texto = new StringBuilder();
                var valorTotal = 0.0;
                texto.Append("====================== CARRINHO ======================sss\n");
                foreach (var prod in ListaProdutos.Keys)
                {
                    var quantidade = ListaProdutos[prod];
                    texto.Append($"{prod.Id}- {prod.Nome} Quantidade: {quantidade}  --Valor unitário: {prod.Preco:c}\n");
                    valorTotal += prod.Preco * quantidade;
                }

                texto.Append($"Total: {valorTotal:c}\n============================================");


                return texto.ToString();
            }
        }


    }

}