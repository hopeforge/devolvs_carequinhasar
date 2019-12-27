using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Arquivos : MonoBehaviour
{
    public static void SalvarArquivo<T>(T objeto, string nome)
    {
        string destination = Application.persistentDataPath + string.Format("/{0}.dat",nome);
        FileStream file;

        if (File.Exists(destination))
            file = File.OpenWrite(destination);
        else
            file = File.Create(destination);

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, objeto);
        file.Close();
    }

    public static T CarregarArquivo<T>(string nome)
    {
        string destination = Application.persistentDataPath + string.Format("/{0}.dat", nome);
        FileStream file;
        try
        {
            if (File.Exists(destination))
            {
                file = File.OpenRead(destination);
                BinaryFormatter bf = new BinaryFormatter();
                T data = (T)bf.Deserialize(file);
                file.Close();

                return data;
            }
        }
        catch (System.Exception ex)
        {
        }
        
        return default(T);
    }
}
