using System.Diagnostics;
using Caelum.Stella.CSharp.Inwords;

class NumeroPorExtenso
{
    public void Numeros()
    {
          
           double valor = 75;
           string extenso = new Numero(valor).Extenso();
           Debug.WriteLine(extenso);

           valor = 3434343; 
           string extensoBRl = new MoedaBRL(valor).Extenso();
           Debug.WriteLine(extensoBRl);
                    
    }
}