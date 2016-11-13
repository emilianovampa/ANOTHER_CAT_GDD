using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

public class Password
{
    public static string encriptarPassword(string contrasenia)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(contrasenia);
        SHA256 shaM = new SHA256Managed();

        byte[] hash = shaM.ComputeHash(bytes);


        string contraseniaEncriptada = string.Empty;
        foreach (byte x in hash)
        {
            contraseniaEncriptada += String.Format("{0:x2}", x);
        }

        return contraseniaEncriptada;

    }
}