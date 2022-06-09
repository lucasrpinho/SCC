using System.Text.Json;

namespace Entities
{
    public class MockPedido
    {
        private List<Pedidos> LstPedido { get;  set; } = new List<Pedidos>();
        
        public List<Pedidos> MockedArrayOfPedidos()
        {
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 01, 15), 200.99));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 01, 20), 700.00));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 01, 15), 3300.50));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 01, 20), 50.00));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 01, 15), 80.00));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 02, 15), 150.00));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 02, 07), 2000.00));
            LstPedido.Add(new Pedidos(1, new DateTime(2022, 06, 15), 60.00));
            LstPedido.Add(new Pedidos(2, new DateTime(2022, 01, 03), 600.00));
            LstPedido.Add(new Pedidos(2, new DateTime(2022, 01, 15), 1500.30));
            LstPedido.Add(new Pedidos(2, new DateTime(2022, 01, 25), 80.00));
            LstPedido.Add(new Pedidos(2, new DateTime(2022, 01, 15), 80.00));
            LstPedido.Add(new Pedidos(2, new DateTime(2022, 12, 03), 3500.00));

            if (LstPedido.Count > 0)
            {
                if (LstPedido.All(p => p != null))
                {
                    return LstPedido;
                }
            }
            return new List<Pedidos>();
        }
    }
}
