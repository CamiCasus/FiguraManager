using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Application.MainModule.DTO.Resources
{
    public abstract class LoginDtoResources
    {
        private const string Prefix = "LoginDto";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\LoginDtoResources.xml"));

        public static string Username
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Username", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UsernameRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UsernameRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string Password
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Password", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PasswordRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "PasswordRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }
    }
}
