using System.Security.Cryptography;

namespace KHM.Helpers;
/// <summary>
/// Generate random codes
/// </summary>
public static class Codes
{
	#region Generate a random character code
	/// <summary>
	/// Generate a random character code.
	/// </summary>
	/// <param name="_numberOfCharacters">The number of characters.</param>
	/// <returns>A string</returns>
	public static string GenerateCharacterCode( int _numberOfCharacters )
	{
		// Karakterset van hoofdletters A-Z
		string charset = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		using RandomNumberGenerator rng = RandomNumberGenerator.Create();
		byte[] randomBytes = new byte[_numberOfCharacters];
		rng.GetBytes( randomBytes );

		string[] _unique = new string[_numberOfCharacters];
		StringBuilder _uniqueCode = new();

		for ( var i = 1; i <= _numberOfCharacters; i++ )
		{
			_unique [ i - 1 ] = charset [ randomBytes [ i - 1 ] % charset.Length ].ToString();
			_uniqueCode.Append( _unique [ i - 1 ] );
		}

		return _uniqueCode.ToString();
	}
	#endregion

	#region Generate a random number code.
	/// <summary>
	/// Generate a random number code.
	/// </summary>
	/// <param name="_numberOfCharacters">The number of characters.</param>
	/// <returns>A string</returns>
	public static string GenerateNumberCode( int _numberOfCharacters )
	{
		string charset = "3054172968";

		using RandomNumberGenerator rng = RandomNumberGenerator.Create();
		byte[] randomBytes = new byte[_numberOfCharacters];
		rng.GetBytes( randomBytes );

		string[] _unique = new string[_numberOfCharacters];
		StringBuilder _uniqueCode = new();

		for ( var i = 1; i <= _numberOfCharacters; i++ )
		{
			_unique [ i - 1 ] = charset [ randomBytes [ i - 1 ] % charset.Length ].ToString();
			_uniqueCode.Append( _unique [ i - 1 ] );
		}

		return _uniqueCode.ToString();
	}
	#endregion
}
