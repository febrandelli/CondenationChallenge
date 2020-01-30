using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Codenation
{
    
    class Descodificacao
    {
        static private List<char> _letras = new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        static private List<char> _letrasAlternativa = new List<char> { 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd' };
        public string Descriptografa(string frase, int numeroDeCasa)
        {            
            int i = 0;
            StringBuilder fraseDescriptografada = new StringBuilder();
            foreach (var caracter in frase)
            {
                char letra;
                if (caracter == ' ' || caracter == '.' || caracter == ',')
                {
                    letra = caracter;
                }
                else if (_letras.IndexOf(caracter) >= numeroDeCasa)
                {
                    letra = _letras[(_letras.IndexOf(caracter)) - numeroDeCasa];
                }
                else
                {
                    letra = _letrasAlternativa[(_letrasAlternativa.IndexOf(caracter)) - numeroDeCasa];
                }
                fraseDescriptografada.Append(letra);
                i += 1;
            }
            return fraseDescriptografada.ToString();
        }
        
    }
}
