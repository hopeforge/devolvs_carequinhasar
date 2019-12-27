using UnityEngine;
using System.Text;

public class HashingData : MonoBehaviour {

	public static string Md5Sum(string input)
	{
		System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
		byte[] hash = md5.ComputeHash(inputBytes);
		
		StringBuilder sb = new StringBuilder();
		
		for (int i = 0; i < hash.Length; i++)
		{
			sb.Append(hash[i].ToString("X2"));
		}
		
		return sb.ToString();
	}
}
