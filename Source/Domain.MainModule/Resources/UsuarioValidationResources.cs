using System;
using System.Globalization;
using System.IO;
using Infrastructure.CrossCutting.Resources;
using Infrastructure.CrossCutting.Resources.Core;

namespace Domain.MainModule.Resources
{
    public class UsuarioValidationResources
    {
        private const string Prefix = "Usuario";

        private static readonly IResourceProvider ResourceProvider =
            new XmlResourceProvider(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Resources\Xml\UsuarioValidation.xml"));


        public static string EmailIsRequired
        {
            get
            {
                return
                    ResourceProvider.GetResource(Prefix, "EmailIsRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailLengthMustBeLowerEqualThan100
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailLengthMustBeLowerEqualThan100", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PasswordIsRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "PasswordIsRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string PasswordLenghtMustBeLowerEqualThan100
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "PasswordLenghtMustBeLowerEqualThan100", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UserNameIsRequired
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameIsRequired", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UserNameLengthMustBeLowerEqualThan100
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameLengthMustBeLowerEqualThan100", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string AgenciaIdMustExist
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "AgenciaIdMustExist", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string UserNameMustBeUnique
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "UserNameMustBeUnique", CultureInfo.CurrentUICulture.Name);
            }
        }

        public static string EmailMustBeUniqueSpec
        {
            get
            {
                return ResourceProvider.GetResource(Prefix, "EmailMustBeUniqueSpec", CultureInfo.CurrentUICulture.Name);
            }
        }        
    }
}