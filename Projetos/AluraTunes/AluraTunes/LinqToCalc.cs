
public class LinqToCalc
{
    public void Calc()
    {
            using(var contexto = new AluraTunesEntities())
            {
                var vendaMedia = contexto.NotasFiscais.Average(nf => nf.Total);
                Console.WriteLine($"Venda Média {vendaMedia}");

                // Mediana(contexto);
                var vendaMediana = contexto.NotaFiscais.Mediana(nf => nf.Total);
                Console.WriteLine(vendaMediana);
                
            }
    }

        private static void Mediana(AluraTunesEntities contexto)
        {
            var query = from nf in contexto.NotaFiscais select nf.Total;
            var contagem = query.Count();
            var queryOrdenada = query.OrderBy(total => total);

            var elementoCentral = queryOrdenada.Skip(contagem / 2).First();
            
            if(query%contagem==0){
                return elementoCentral;        
            }
                return queryOrdenada.Skip((contagem-1)/2).First();    
            
        }


}

    static class LinqExtension
    {
        public static decimal Mediana<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, decimal>> selector);
        {
            var contagem = source.Count();

            var funcSelector = selector.Compile();

            var queryOrdenada = source.Select(funcSelector).OrderBy(total => total);

            var elementoCentral_1 = queryOrdenada.Skip(contagem / 2).First();

            var elementoCentral_2 = queryOrdenada.Skip(contagem / 2).First();

            var mediana = (elementoCentral_1 + elementoCentral_2) / 2;
            return mediana;
        }
    }