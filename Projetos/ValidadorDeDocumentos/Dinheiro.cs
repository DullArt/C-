using System.Diagnostics;
using Caelum.Stella.CSharp.Vault;

class Dinheiro
{
    public void M()
    {
          Money money = 10.00;
          Debug.WriteLine(money);

          Money euro = new Money(Currency.EUR, 1000);
          Debug.WriteLine(euro);
    }
}