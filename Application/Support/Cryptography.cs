using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Support
{
	public static class Cryptography
	{
		#region Settings

		private static int _iterations = 2;
		private static int _keySize = 256;

		private static string _hash = "SHA1";
		private static string _salt = "aselrias38490a32"; // Random
		private static string _vector = "8947az34awl34kjq"; // Random

		#endregion

		public static string Encrypt(string value, string password)
		{
			return Encrypt<AesManaged>(value, password);
		}
		public static string Encrypt<T>(string value, string password)
				where T : SymmetricAlgorithm, new()
		{
			byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
			byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
			byte[] valueBytes = Encoding.UTF8.GetBytes(value);

			byte[] encrypted;
			using (T cipher = new())
			{
				PasswordDeriveBytes _passwordBytes =
					new(password, saltBytes, _hash, _iterations);
				byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

				cipher.Mode = CipherMode.CBC;

				using (ICryptoTransform encryptor = cipher.CreateEncryptor(keyBytes, vectorBytes))
				{
					using MemoryStream to = new();
					using CryptoStream writer = new CryptoStream(to, encryptor, CryptoStreamMode.Write);
					writer.Write(valueBytes, 0, valueBytes.Length);
					writer.FlushFinalBlock();
					encrypted = to.ToArray();
				}
				cipher.Clear();
			}
			return Convert.ToBase64String(encrypted);
		}

		public static string Decrypt(string value, string password)
		{
			return Decrypt<AesManaged>(value, password);
		}
		public static string Decrypt<T>(string value, string password) where T : SymmetricAlgorithm, new()
		{
			byte[] vectorBytes = Encoding.ASCII.GetBytes(_vector);
			byte[] saltBytes = Encoding.ASCII.GetBytes(_salt);
			byte[] valueBytes = Convert.FromBase64String(value);

			byte[] decrypted;
			int decryptedByteCount = 0;

			using (T cipher = new())
			{
				PasswordDeriveBytes _passwordBytes = new PasswordDeriveBytes(password, saltBytes, _hash, _iterations);
				byte[] keyBytes = _passwordBytes.GetBytes(_keySize / 8);

				cipher.Mode = CipherMode.CBC;

				try
				{
					using ICryptoTransform decryptor = cipher.CreateDecryptor(keyBytes, vectorBytes);
					using MemoryStream from = new MemoryStream(valueBytes);
					using CryptoStream reader = new CryptoStream(from, decryptor, CryptoStreamMode.Read);
					decrypted = new byte[valueBytes.Length];
					decryptedByteCount = reader.Read(decrypted, 0, decrypted.Length);
				}
				catch (Exception)
				{
					return String.Empty;
				}

				cipher.Clear();
			}
			return Encoding.UTF8.GetString(decrypted, 0, decryptedByteCount);
		}
		public static string EncryptString(string key, string plainText)
		{
			byte[] iv = new byte[16];
			byte[] array;

			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(key);
				aes.IV = iv;
				aes.Padding = PaddingMode.PKCS7;
				aes.Mode = CipherMode.CBC;

				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
						{
							streamWriter.Write(plainText);
						}

						array = memoryStream.ToArray();
					}
				}
			}

			return Convert.ToBase64String(array);
		}
		public static string EncryptStringSolicitudes(string key, string plainText)
		{
			byte[] iv = Encoding.UTF8.GetBytes(key);
			byte[] array;

			using (Aes aes = Aes.Create())
			{
				aes.Key = Encoding.UTF8.GetBytes(key);
				aes.IV = iv;
				aes.Padding = PaddingMode.PKCS7;
				aes.Mode = CipherMode.CBC;

				ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

				using (MemoryStream memoryStream = new MemoryStream())
				{
					using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
					{
						using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
						{
							streamWriter.Write(plainText);
						}

						array = memoryStream.ToArray();
					}
				}
			}
			return System.Net.WebUtility.UrlEncode(Convert.ToBase64String(array));
		}


		public static string ComputeMD5(string value)
		{

			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(value);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				return Convert.ToHexString(hashBytes); // .NET 5 +
			}

		}

	}
}
