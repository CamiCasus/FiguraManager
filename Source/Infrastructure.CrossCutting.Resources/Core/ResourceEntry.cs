namespace Infrastructure.CrossCutting.Resources.Core
{
    public class ResourceEntry
    {
        public string Codigo { get; set; }
        public string Valor { get; set; }
        public string Idioma { get; set; }
        public string Tipo { get; set; }

        public ResourceEntry()
        {
            Tipo = "string";
        }
    }
}