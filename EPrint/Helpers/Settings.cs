// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace EPrint.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string IsLoginKey = "login_key";
		private static readonly bool IsLoginDefault = false;

        #endregion


        public static bool IsLogin
		{
			get
			{
				return AppSettings.GetValueOrDefault(IsLoginKey, IsLoginDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(IsLoginKey, value);
			}
		}

	}
}