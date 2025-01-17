﻿using NanoTwitchLeafs.Objects;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;

namespace NanoTwitchLeafs
{
	/// <summary>
	/// Helper Methods
	/// </summary>
	public static class HelperClass
	{
		/// <summary>
		/// Returns URI-safe data with a given input length.
		/// </summary>
		/// <param name="length">Input length (nb. output will be longer)</param>
		/// <returns></returns>
		public static string RandomDataBase64Url(uint length)
		{
			RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
			byte[] bytes = new byte[length];
			rng.GetBytes(bytes);
			return Base64UrlEncodeNoPadding(bytes);
		}

		//    /// <summary>
		//    /// Base64url no-padding encodes the given input buffer.
		//    /// </summary>
		//    /// <param name="buffer"></param>
		//    /// <returns></returns>
		public static string Base64UrlEncodeNoPadding(byte[] buffer)
		{
			string base64 = Convert.ToBase64String(buffer);

			//Converts base64 to base64url.
			base64 = base64.Replace("+", "-");
			base64 = base64.Replace("/", "_");
			//Strips padding.
			base64 = base64.Replace("=", "");

			return base64;
		}

		/// <summary>
		/// Formating string into JsonString
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		public static string FormatJson(string json)
		{
			dynamic parsedJson = JsonConvert.DeserializeObject(json);
			return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
		}

		/// <summary>
		/// Returns TwitchApiCredentials depending on AppSetting UseOwnServiceCredentials
		/// </summary>
		/// <param name="appSettings"></param>
		/// <returns></returns>
		public static TwitchApiCredentials GetTwitchApiCredentials(AppSettings appSettings)
		{
			if (appSettings.UseOwnServiceCredentials)
				return new TwitchApiCredentials(appSettings.TwitchClientId, appSettings.TwitchClientSecret);

			return Constants.ServiceCredentials.TwitchApiCredentials;
		}

		/// <summary>
		/// Returns StreamLabsApiCedentials depending on AppSetting UseOwnServiceCredentials
		/// </summary>
		/// <param name="appSettings"></param>
		/// <returns></returns>
		public static StreamLabsApiCedentials GetStreamLabsApiCedentials(AppSettings appSettings)
		{
			if (appSettings.UseOwnServiceCredentials)
				return new StreamLabsApiCedentials(appSettings.TwitchClientId, appSettings.TwitchClientSecret);

			return Constants.ServiceCredentials.StreamLabsApiCedentials;
		}
	}
}