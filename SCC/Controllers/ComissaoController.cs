using Microsoft.AspNetCore.Mvc;
using Entities;
using Newtonsoft.Json;
using Utils;


namespace SCC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComissaoController : Controller
    {    
        [HttpPost]
        public string calculaComissao([FromBody] List<Pedidos> pedidos)
        {
            var lstOrderedBySeller = new List<List<Pedidos>>();
            //if json from body is empty then use mocked data (MOQ was not used)
            if (pedidos.First().vendedor == 0)
            {
                var fakeData = new MockPedido();
                var localLst = fakeData.MockedArrayOfPedidos();
                lstOrderedBySeller = localLst.OrderBy(l => l.vendedor).ThenBy(m => m.data.Month).GroupBy(v => v.vendedor)
                .Select(p => p.ToList())
                .ToList();              
            }
            else
            {
                lstOrderedBySeller = pedidos.GroupBy(v => v.vendedor)
                    .Select(p => p.ToList())
                    .ToList();
            }


            var lstResult = new List<Comissao>();

            for (var i = 0; i < lstOrderedBySeller.Count(); i++)
            {
                lstResult.AddRange(calcHelper(lstOrderedBySeller[i]));
            }


           
            var json = JsonConvert.SerializeObject(lstResult, new JsonDecimalOutput());
            if (!String.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine(json);
                return json;
            }
            else
                throw new Exception("Erro: json vazio");
        }    
        
        private List<Comissao> calcHelper(List<Pedidos> ped)
        {
            var lstComissao = new List<Comissao>();
            double val = 0;
            int lastMes = 0;           
            bool flag = false;           
            var c = new Comissao();
            int meta = 0;
            var mh = new MetasHelper();
            var lstMeta = mh.GetLst();
            bool alreadyEarned = false;
            for (var i = 0; i < ped.Count(); i++)
            {                              
                //if last month is equal to current month of the object just increment the value of comission without creating a new object
                //won't have a problem with months out of order because it was grouped through LINQ in asc order
                if (lastMes == ped[i].data.Month || lastMes == 0)
                {
                    meta++;
                    lastMes = ped[i].data.Month;
                    val = val + percentageHelper(ped[i].valor);
                    c.vendedor = ped[i].vendedor;
                    c.mes = ped[i].data.Month;
                    c.valor = val;                
                    if (meta >= lstMeta.Find(m => m.mes == c.mes).qtd && !alreadyEarned)
                    {
                        c.valor = val + (val * 0.03);
                        alreadyEarned = true;
                    }                        
                    else
                    {
                        lstComissao.Find(c => c.mes == lastMes);
                    }
                    if (!flag)
                    {
                        lstComissao.Add(c);
                    }
                    flag = true;                    
                }                
                else
                //if current month is different than last month than create new object of comission to put in the json result
                {
                    meta = 0;
                    alreadyEarned = false;
                    c = new Comissao(ped[i].vendedor, ped[i].data.Month, ped[i].valor);                    
                    lastMes = ped[i].data.Month;
                    val = percentageHelper(ped[i].valor);
                    c.valor = val;
                    lstComissao.Add(c);
                }                
            }
            return lstComissao;
        }

        private double percentageHelper(double val)
        {
            double result = 0;
            if (val < 300)
                result = val * 0.01;
            else if (val >= 300 && val <= 1000)
                result = val * 0.03;
            else if (val > 1000)
                result = val * 0.05;
            else
                result = val;

            return result;
        }      
    }
}
