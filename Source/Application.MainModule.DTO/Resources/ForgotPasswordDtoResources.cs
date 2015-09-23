using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;
using System;
using System.Globalization;
using System.IO;

namespace Application.MainModule.DTO.Resources
{
    public class ForgotPasswordDtoResources
    {
        private const string Prefix = "ForgotPasswordDto";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\ForgotPasswordDtoResources.xml"));

        public static string Email
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "Email", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailRequerido
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailRequerido", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailFormatoIncorrecto
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailFormatoIncorrecto", CultureInfo.CurrentUICulture.Name);
            }
        }
    }
}
