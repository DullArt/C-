using System.Diagnostics;
using Caelum.Stella.CSharp.Http;

class Cep
{
    public void C()
    {
          string cep = "01001000";
          string url = "https://viacep.com.br/ws/" + cep + "/json/";
        //   new HttpClient().GetStreamAsync(url).Result;
        //   Debug.WriteLine(result);

          Debug.WriteLine(new ViaCEP().GetEnderecoJsonAsync(cep));
          
          
          var endereco = new ViaCEP().GetEndereco(cep);
          Debug.WriteLine(endereco.Complemento+endereco.CEP);

    }
}