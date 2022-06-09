using Entities;

namespace Utils
{
    public class MetasHelper
    {    
        public List<Meta> GetLst()
        {
            var lst = new List<Meta>();
            lst.Add(new Meta(1, 5));
            lst.Add(new Meta(2, 3));
            lst.Add(new Meta(3, 2));
            lst.Add(new Meta(4, 2));
            lst.Add(new Meta(5, 5));
            lst.Add(new Meta(6, 60));
            lst.Add(new Meta(8, 2));
            lst.Add(new Meta(9, 4));
            lst.Add(new Meta(10, 4));
            lst.Add(new Meta(11, 7));
            lst.Add(new Meta(12, 2));
            if (lst.Count > 0)
                return lst;
            else
                throw new Exception("Erro: a criação da lista constante de metas falhou.");
        }
    }
}