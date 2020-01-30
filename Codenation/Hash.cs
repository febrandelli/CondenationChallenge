using System;
using System.Security.Cryptography;
using System.Text;
class Hash
{
    private HashAlgorithm _algoritmo;
    public Hash(HashAlgorithm algoritmo)
    {
        _algoritmo = algoritmo;
    }

    public string GerarHash(string frase)
    {
        var valorCodificado = Encoding.UTF8.GetBytes(frase);
        var fraseCifrada = _algoritmo.ComputeHash(valorCodificado);
        var sb = new StringBuilder();
        foreach (var caractere in fraseCifrada)
        {
            sb.Append(caractere.ToString("X2"));
        }
        return sb.ToString();
    }
    public bool VerificarHash(string fraseRaiz, string fraseCriptografada)
    {
        if (string.IsNullOrEmpty(fraseCriptografada))
            throw new NullReferenceException("Cadastre uma senha.");
        var fraseDescriptografada = _algoritmo.ComputeHash(Encoding.UTF8.GetBytes(fraseRaiz));
        var sb = new StringBuilder();
        foreach (var caractere in fraseDescriptografada)
        {
            sb.Append(caractere.ToString("X2"));
        }
        return sb.ToString() == fraseCriptografada;
    }
}